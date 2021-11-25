using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int level = 1;
    public int score = 0;
    public double timeRemaining;
    public bool isPlaying = false;
    public bool isGameOver = false;

    public Button shootButton;
    public Button resetButton;

    public GameObject aim;
    public GameObject scan;
    public GameObject msgDied;

    public TMPro.TextMeshProUGUI txtScore;
    public TMPro.TextMeshProUGUI txtTime;

    

    private void Awake()
    {
        Instance = this;
        StartGame();
    }

    void Update()
    {
        txtScore.text = "Score: " + score.ToString();
        if (isPlaying) {
            SetActiveScene(true);
            scan.gameObject.SetActive(false);
            txtTime.text = timeRemaining.ToString("0.00");
            if (timeRemaining > 0) {
                timeRemaining -= Time.deltaTime;
            }
            else {
                isPlaying = false;
                isGameOver = true;
                GameOver();
                SetActiveScene(isPlaying);
            }
        } else {
            txtTime.text = "Not start";
        }
    }

    public void GameOver(){
        msgDied.gameObject.SetActive(isGameOver);
        resetButton.gameObject.SetActive(isGameOver);
    }

    public void SetActiveScene(bool status){
        shootButton.gameObject.SetActive(status);
        txtTime.gameObject.SetActive(status);
        txtScore.gameObject.SetActive(status);
        aim.gameObject.SetActive(status);
    }

    public void StartGame(){
        score = 0;
        isGameOver = false;
        scan.gameObject.SetActive(true);
        GameOver();
        SetActiveScene(false);
    }
}
