using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    [SerializeField]
    DatabaseAccessor _databaseAccessor;

    [SerializeField]
    TMPro.TextMeshProUGUI _score;

    [SerializeField]
    TMPro.TextMeshProUGUI _totalScore;

    [SerializeField]
    TMPro.TextMeshProUGUI _successCount;

    [SerializeField]
    TMPro.TextMeshProUGUI _successLabel;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void Setup(string user_id, string music, int difficulty, float score, float quota)
    {
        _databaseAccessor.AddLog(user_id, music, difficulty, score);
        float totalScore = _databaseAccessor.GetTotalScore(user_id);
        int successCount = _databaseAccessor.GetSuccessCount(user_id, music, difficulty, quota);
        _databaseAccessor.ShowLogs(100);

        _score.text = $"{(int)score}";
        _totalScore.text = $"{(int)totalScore}";
        _successCount.text = $"{successCount}";
        _successLabel.text = "失敗";
        if(score >= quota)
        {
            _successLabel.text = "成功";
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
