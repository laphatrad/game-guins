using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public double score;
    public int stage;
    public double highestScore;

    void StartGame() {
        score = 0;
        stage = 1;
    }

    void StartStage(int stage) {
        stage = stage;
        // get Stage
    }

    void EndGame() {
        //End the game
    }
}
