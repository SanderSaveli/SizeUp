using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreCoins : MonoBehaviour
{
    public GameObject player;
    public Text TotalScoretxt;
    public Text scoretxt;
    public Text Crystaltxt;
    public Text BestScore;
    public bool isGameStart;
    public bool animete;
    private int score = 0;
    private int TotalScore = 0;

    private void Start()
    {
        Crystaltxt.text = PlayerPrefs.GetInt("Crystal").ToString();
        BestScore.text = "Best\n"+PlayerPrefs.GetInt("BestScore").ToString();
    }

    void FixedUpdate()
    {
        isGameStart = GameObject.Find("PlayButton").GetComponent<PlayButton>().gameStart;
        if (player.activeSelf == false)
        { 
            if (TotalScore > PlayerPrefs.GetInt("BestScore"))
                PlayerPrefs.SetInt("BestScore", TotalScore);
            isGameStart = false;
        }
        if (isGameStart)
        {
            TotalScoretxt.gameObject.SetActive(true);
            scoretxt.gameObject.SetActive(true);
            if (animete)    // присваиваем animate буливое значение в зависимости от нажатия на экран и при true увеличиваем размер
                score++;
        }
    }
    void ScoreShow(int score)
    {
        scoretxt.GetComponent<Animation>().Stop();
        scoretxt.text = score.ToString();
        scoretxt.GetComponent<Animation>().Play();
    }

    
    void OnMouseDown()
    {
        if (isGameStart)
        {
            animete = true;
        }
    }
    void OnMouseUp()
    {
        if (isGameStart)
        {
            animete = false;
            score /= 10;
            ScoreShow(score);
            PlayerPrefs.SetInt("Crystal", PlayerPrefs.GetInt("Crystal") + score/2);
            Crystaltxt.text = PlayerPrefs.GetInt("Crystal").ToString();
            TotalScore += score;
            TotalScoretxt.text = TotalScore.ToString();
            score = 0;
        }

    }
}
