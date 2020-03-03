using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public float distance;
    private float globalScore;
    public Text scoreText;

    [SerializeField]
    private Cat cat = null;

    void Start()
    {
        distance = 0;
        globalScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!cat.IsDead)
        {
            distance += Time.deltaTime;
            globalScore += Time.deltaTime * 10;
            scoreText.text = "SCORE: " + globalScore.ToString("0");
        }
    }

    public void UpdateScore(float score)
    {
        globalScore *= score;
    }

    public float getDistance()
    {
        return distance;
    }

    public float getScore()
    {
        return globalScore;
    }

}
