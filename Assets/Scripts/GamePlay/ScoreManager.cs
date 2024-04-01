using System;
using System.IO;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    public static ScoreManager instance;
    private int score = 0;
    private string pathHighScore = Application.streamingAssetsPath + "/highScore.txt";

    private void Awake()
    {
        if (instance == null)
            instance = this;
        GetHighScore();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == Tag.CUBE_TAG)
        {
            score++;
            scoreText.text = score.ToString();
        }
    }
    public void SetHighScore()
    {
        if (score > Rank.RANK_SCORE1)
        {
            Rank.RANK_SCORE2 = Rank.RANK_SCORE1;
            Rank.RANK_SCORE3 = Rank.RANK_SCORE2;
            Rank.RANK_SCORE1 = score;
        } 
        else if (score > Rank.RANK_SCORE2)
        {
            Rank.RANK_SCORE3 = Rank.RANK_SCORE2;
            Rank.RANK_SCORE2 = score;
        }
        else if (score > Rank.RANK_SCORE3)
        {
            Rank.RANK_SCORE3 = score;
        }
    }
    public void GetHighScore()
    {
        try
        {
            string[] arr = File.ReadAllLines(pathHighScore);
            Rank.RANK_SCORE1 = int.Parse(arr[0]);
            Rank.RANK_SCORE2 = int.Parse(arr[1]);
            Rank.RANK_SCORE3 = int.Parse(arr[2]);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }
    public void SaveHighScore()
    {
        string[] arr = { Rank.RANK_SCORE1.ToString(), Rank.RANK_SCORE2.ToString(), Rank.RANK_SCORE3.ToString() };
        File.WriteAllLines(pathHighScore, arr);
    }
}
