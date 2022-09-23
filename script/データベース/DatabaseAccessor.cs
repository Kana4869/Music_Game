using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data;               // MySQL関連
using MySql.Data.MySqlClient;   // MySQL関連

public class DatabaseAccessor : MonoBehaviour
{
    private string connCmd =
                "server=127.0.0.1;" +        // 接続先サーバ
                "database=db_music_game;" +                // 接続先データベース
                "port=3306;" +                    // 接続ポート
                "userid=root;" +                // 接続ユーザーID
                "password=develop24748465124354311";              // 接続パスワード
    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        
    }

    internal void AddLog(string user_id, string music, int difficulty, float score)
    {
        Debug.Log("MySQLと接続中...");
        using (var conn = new MySqlConnection(connCmd))
        {
            try
            {
                string query = $"INSERT INTO tbl_game_log VALUES ('{DateTime.UtcNow.ToString()}', '{user_id}', '{music}', {difficulty}, {score});";
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // 順番に結果をログに出力
                            Debug.Log(dr[0] + "," + dr[1] + "," + dr[2] + "," + dr[3]);
                        }
                        dr.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.Log(ex.ToString());
            }
            finally
            {
                try
                {
                    conn.Close();
                    Debug.Log("接続を終了しました");
                }
                catch
                {
                    Debug.Log("Close Error");
                }
            }
        }
    }

    internal float GetTotalScore(string user_id)
    {
        Debug.Log("MySQLと接続中...");
        float ret = 0.0f; 
        using (var conn = new MySqlConnection(connCmd))
        {
            try
            {
                string query = $@"
SELECT SUM(max_score) FROM (
    SELECT music, difficulty, MAX(score) AS max_score
    FROM tbl_game_log
    WHERE user_id='{user_id}'
    GROUP BY music, difficulty
) AS max_list;
";
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        Debug.Log($"Total Score: {dr[0]}");
                        ret = float.Parse(dr[0].ToString()); 
                        dr.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.Log(ex.ToString());
            }
            finally
            {
                try
                {
                    conn.Close();
                    Debug.Log("接続を終了しました");
                }
                catch
                {
                    Debug.Log("Close Error");
                }
            }
            return ret; 
        }
    }

    internal int GetSuccessCount(string user_id, string music, int difficulty, float threshold)
    {
        Debug.Log("MySQLと接続中...");
        int ret = 0;
        using (var conn = new MySqlConnection(connCmd))
        {
            try
            {
                string query = $@"
SELECT count(user_id) AS count
FROM tbl_game_log
WHERE user_id='{user_id}' AND music='{music}' AND difficulty={difficulty} AND score>={threshold};

";
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        Debug.Log($"Success Count: {dr[0]}");
                        ret = int.Parse(dr[0].ToString());
                        dr.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.Log(ex.ToString());
            }
            finally
            {
                try
                {
                    conn.Close();
                    Debug.Log("接続を終了しました");
                }
                catch
                {
                    Debug.Log("Close Error");
                }
            }
            return ret;
        }
    }


    internal void ShowLogs(int limit)
    { 
        Debug.Log("MySQLと接続中...");
        using (var conn = new MySqlConnection(connCmd))
        {
            try
            {
                string query = "SELECT * FROM tbl_game_log LIMIT {limit};"; 
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // 順番に結果をログに出力
                            Debug.Log($"{dr[0]},{dr[1]},{dr[2]},{dr[3]},{dr[4]}");
                        }
                        dr.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.Log(ex.ToString());
            }
            finally
            {
                try
                {
                    conn.Close();
                    Debug.Log("接続を終了しました");
                }
                catch
                {
                    Debug.Log("Close Error");
                }
            }
        }
    }
}
