using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Timers;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public enum state
{
    Pre,
    Play,
    Post
}

public class GameManager : MonoBehaviour
{

    public static GameManager instance { get; private set; }
    DateTime currentTimer;
    public state gameState { get; private set; } = state.Pre;

    [SerializeField] float PreGameTimer = 2;
    [SerializeField] float GameTimer = 10;
    [SerializeField] float PostGameTimer = 2;

    [SerializeField] TMPro.TextMeshProUGUI TextFieldTop;


    // Start is called before the first frame update
    void Start()
    {
        if (instance)
        {
            GameObject.Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        StartCoroutine(GameFlow());
    }

    IEnumerator GameFlow()
    {
        while (true)
        {
            //PreGame time
            {
                currentTimer = DateTime.Now;
                gameState = state.Pre;

                while ((DateTime.Now - currentTimer).Seconds < PreGameTimer)
                {
                    yield return new WaitForEndOfFrame();

                    TextFieldTop.text = "Starting in: " + (PreGameTimer - ((float)(DateTime.Now - currentTimer).Seconds)).ToString();
                }
            }

            //Game time
            {
                currentTimer = DateTime.Now;
                gameState = state.Play;

                while ((DateTime.Now - currentTimer).Seconds < GameTimer)
                {
                    yield return new WaitForEndOfFrame();

                    TextFieldTop.text = (GameTimer - ((float)(DateTime.Now - currentTimer).Seconds)).ToString();
                }

            }

            //PostGameTimer
            {
                currentTimer = DateTime.Now;
                gameState = state.Post;

                //Calculate player score

                scores score = TileLevelGenerator.instance.CalculateScores();



                while ((DateTime.Now - currentTimer).Seconds < PostGameTimer)
                {
                    yield return new WaitForEndOfFrame();

                    string text = score.a > score.b ? "Player 1 Won" : "Player 2 Won";
                    text += " \n Claimed: " + (((score.a > score.b ? score.a : score.b) / (score.UnClaimed + score.b + score.a) )* 100).ToString("0.") + "%";


                    TextFieldTop.text = text;
                }


            }
            SceneManager.LoadScene(0);
            yield return new WaitForEndOfFrame();
        }
    }
}
