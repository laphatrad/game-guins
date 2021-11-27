using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public int level;
    public string description;

    public double time;
    public GameObject monster;
    public int monsterAmount;
    public Weapon weapon;
    public AudioSource mainTheme;
    public AudioSource bossTheme;

    private GameObject[] monsters;
    private bool isSpawn = false;
    private int totalMonsters ;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (GameManager.Instance.gameState) {
            case GameConstant.playingState: {
                if (isSpawn) {
                    int monsterRemaining = GetMonsterRemaining();
                    if (monsterRemaining == 0) {
                        WinStage();
                        ClearStage();
                    }
                }
                break;
            }
            case GameConstant.gameOverState: {
                ClearStage();
                break;
            }
        }
    }

    void SetRespawningPoint(Vector3 point) {
        monsters = new GameObject[monsterAmount];
        for (int i = 0; i < monsterAmount; i++) {
            monsters[i] = Instantiate(
                monster,
                new Vector3(
                    point.x + Random.Range(-5f, 5f),
                    point.y + Random.Range(0, 10f),
                    point.z + Random.Range(-5f, 5f)), monster.transform.rotation);
            monsters[i].SetActive(false);
        }
        GameManager.Instance.timeRemaining = time;
        isSpawn = true;
    }

    public void ShowStageDetail() {
        if (GameManager.Instance.gameState == GameConstant.initState) {
            GameManager.Instance.gameState = GameConstant.selectStageState;
            GameManager.Instance.selectStage = gameObject.GetComponent<Stage>();
        }
    }

    public void HideStageDetail() {
        if (GameManager.Instance.gameState == GameConstant.selectStageState) {
            GameManager.Instance.gameState = GameConstant.initState;
            GameManager.Instance.selectStage = null;
        }
    }

    public void StartStage() {
        if (!isSpawn) {
            if (GameManager.Instance.level == 1){
                mainTheme.Play();
            }
            if (GameManager.Instance.level == 2){
                mainTheme.Stop();
                mainTheme.Play();
            }
            if (GameManager.Instance.level == 3){
                mainTheme.Stop();
                bossTheme.Play();
            }

            if (GameManager.Instance.level == level) {
                Debug.Log("Level 1");
                isSpawn = true;
                SetRespawningPoint(weapon.transform.position);
                StartCoroutine(SpawnMonsters());
                GameManager.Instance.gameState = GameConstant.playingState;
            } else {

            }
        }
    }

    private IEnumerator SpawnMonsters()
    {
        for (int i = 0; i < monsterAmount; i++) {
            monsters[i].SetActive(true);
            monsters[i].GetComponent<Monster>().weapon = weapon;
            yield return new WaitForSeconds(0.1f);
        }
    }

    int GetMonsterRemaining() {
        int remaining = 0;
        for (int i = 0; i < monsterAmount; i++) {
            if (monsters[i].activeSelf) {
                remaining += 1;
            }
        }
        return remaining;
    }

    void WinStage() {
        GameManager.Instance.gameState = GameConstant.winState; 
    }

    void ClearStage() {
        mainTheme.Stop();
        bossTheme.Stop();
        isSpawn = false;
        GameManager.Instance.timeRemaining = 0;
        totalMonsters = monsters.Length;
        if (totalMonsters > 0) {
            for (int i = 0; i < monsterAmount; i++) {
                Destroy(monsters[i]);
            }
        }  
    }
}
