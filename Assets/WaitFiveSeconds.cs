using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class WaitFiveSeconds : MonoBehaviour
{
    public Text YourScore;
    private float time;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (time < 5)
        {
            time += Time.deltaTime;
        }
        else {
            SceneManager.LoadScene("main");
        }
    }

    public void updateScore(int newScore) {
        YourScore.text = "Your score:\n" + String.Format("{0:0000}", newScore);
    }
}
