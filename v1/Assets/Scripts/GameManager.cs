using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int level = 1;
    public double hp = 100;
    public Stage selectStage;
    public int score = 0;
    public double timeRemaining;
    public int gameState;

    private bool isStartState = false;

    private void Awake()
    {
        Instance = this;
        RestartGame();
    }

    void Update()
    {
        if (hp <= 0) {
            gameState = GameConstant.gameOverState;
        }
        switch (gameState) {
            case GameConstant.playingState: {
                if (timeRemaining > 0) {
                    timeRemaining -= Time.deltaTime;
                }
                else {
                    gameState = GameConstant.gameOverState;
                }
                break;
            }
            case GameConstant.winState: {
                if (!isStartState) {
                    StartCoroutine(GoToInitState());
                }
                break;
            }
        }
    }

    private IEnumerator GoToInitState() {
        isStartState = true;
        if (selectStage.level >= level) {
            level = selectStage.level + 1;
        }
        yield return new WaitForSeconds(3f);
        isStartState = false;
        gameState = GameConstant.initState;
        selectStage = null;
    }

    public void RestartGame() {
        gameState = GameConstant.initState;
        score = 0;
        hp = 100;
    }
}
