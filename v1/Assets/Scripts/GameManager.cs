using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int score = 0;
    public double timeRemaining;
    public bool isPlaying = false;

    public TMPro.TextMeshProUGUI txtScore;
    public TMPro.TextMeshProUGUI txtTime;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        txtScore.text = "Score: " + score.ToString();
        if (isPlaying) {
            txtTime.text = timeRemaining.ToString("0.00");
            if (timeRemaining > 0) {
                timeRemaining -= Time.deltaTime;
            }
            else {
                isPlaying = false;
            }
        } else {
            txtTime.text = "Not start";
        }
    }
}
