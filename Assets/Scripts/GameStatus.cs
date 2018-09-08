using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour {
    [Range(0.1f,10f)][SerializeField] float gameSpeed=1f;
    [SerializeField]int pointsPerAsteroid=83;
    [SerializeField] int currentScore=0;
    [SerializeField] TextMeshProUGUI scoreText;


    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount>1)
        {
            Destroy(gameObject);
            scoreText.text = currentScore.ToString();
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update ()
    {
        Time.timeScale = gameSpeed;
       
    }

    public void AddToScore()
    {
        currentScore += pointsPerAsteroid;
        scoreText.text = currentScore.ToString();
    }

}
