using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score;
    public static int allScore;
    
    
    [SerializeField] private Text allScoreText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text scoreTextGameOver;
    [SerializeField] private GameObject _soldGO;

    private void Start()
    {
        score = PlayerPrefs.GetInt("score");
        allScore = PlayerPrefs.GetInt("allScore");
        item.itemStatus = PlayerPrefs.GetInt("itemStatus");
        PlayerPrefs.SetInt("score", score = 0);
    }

    private void Update()
    {
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.SetInt("allScore", allScore);
        PlayerPrefs.SetInt("itemStatus", item.itemStatus);

        scoreText.text = "Score: " + score;
        scoreTextGameOver.text = "Score: " + score;
        allScoreText.text = "Score: " + allScore;
        if (item.itemStatus == 1)
        {
            _soldGO.SetActive(true);
        }
        else
        {
            _soldGO.SetActive(false);
        }
    }

    public void Buy()
    {
        
        if (allScore>= 300)
        {
            allScore -= 300;
            item.itemStatus = 1;
            
        }
    }
}
