using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameSession : MonoBehaviour
{
    [SerializeField] int score = 0;
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] TextMeshProUGUI playerScore;
    [SerializeField] bool isAutoPlayEnabled = false;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        playerScore.text = "Player Score: " + score;
    }

    internal void resetScore()
    {
        score = 0;
        updateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void updateScore(int points)
    {
        score += points;
        playerScore.text = "Player Score: " + score;
    }
    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }

}
