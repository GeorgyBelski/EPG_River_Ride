using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText;
    private int currentScore;
    private bool updateScore;
    public float updateAnimationTime = 0.5f;
    private float halfAnimationTime;
    private float commonScoreTextScale;
    private float deltaScale;
    void Start()
    {
        currentScore = Player.score;
        updateScore = false;
        scoreText.text = "0";
        halfAnimationTime = updateAnimationTime / 2;
        commonScoreTextScale = scoreText.transform.localScale.x;
        deltaScale = commonScoreTextScale / (halfAnimationTime * 50);
    }

    private void UpdateScoreUI()
    {
        updateScore = true;
        currentScore = Player.score;
        scoreText.text = "" + currentScore;
        
    }

    private void Update()
    {
        if (currentScore != Player.score)
        {
            UpdateScoreUI();
            updateAnimationTime = 2 * halfAnimationTime;
        }

        if (updateScore) {
            updateAnimationTime -= Time.deltaTime;
            if (updateAnimationTime > halfAnimationTime)
            {
                scoreText.transform.localScale += new Vector3(deltaScale, deltaScale, 0);
            }
            else
            {
                scoreText.transform.localScale -= new Vector3(deltaScale, deltaScale, 0); 
            }
            if(updateAnimationTime <= 0)
            {
                updateAnimationTime = 2 * halfAnimationTime;
                scoreText.transform.localScale = new Vector3(commonScoreTextScale, commonScoreTextScale, 1);
                updateScore = false;
            }
            
        }
    }
}
