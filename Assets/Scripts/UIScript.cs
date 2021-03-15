using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    //public Text time;
    public Text points;
    public Text UIHighScore;
    //public int timeLeft;
    //double timeShow;

    //private DateTime start;
    //private DateTime now;
    //private bool timesUp;
    private int score;
    private int highScore;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        highScore = 0;
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/

    public void scorePoints(int change, int coinsAdded)
    {
        score += change;
        //coinCount += coinsAdded;
        points.text = "Score\n" + String.Format("{0:0000}", score);
        //coins.text = "Hi-Score:\n" + highScore;
    }
    public void resetGame() {
        if (highScore < score) {
            highScore = score;
            UIHighScore.text = "Hi-Score\n" + String.Format("{0:0000}", highScore);
        }
        score = 0;
    }

    public int getScore() {
        return score;
    }
}
