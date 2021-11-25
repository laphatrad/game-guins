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
    private TMPro.TextMeshProUGUI stageDetail;

    // Start is called before the first frame update
    void Start()
    {
        stageDetail = gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        HideDetail();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isPlaying && isSpawn) {
            int monsterRemaining = GetMonsterRemaining();
            if (monsterRemaining == 0) {
                FinishStage();
                ClearStage();
            }
        }
        if(GameManager.Instance.isGameOver){
            ClearStage();
        }
    }

    void SetRespawningPoint(Vector3 point) {
        monsters = new GameObject[monsterAmount];
        for (int i = 0; i < monsterAmount; i++) {
            monsters[i] = Instantiate(monster, new Vector3(point.x + Random.Range(-5f, 5f), point.y + Random.Range(0, 10f), point.z + Random.Range(-5f, 5f)), monster.transform.rotation);
            monsters[i].SetActive(false);
        }
        GameManager.Instance.timeRemaining = time;
        isSpawn = false;
    }

    public void ShowDetail() {
        stageDetail.gameObject.SetActive(true);
    }

    public void HideDetail() {
        stageDetail.gameObject.SetActive(false);
    }

    public void StartStage() {
        Debug.Log(isSpawn);
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

            if (GameManager.Instance.level >= level) {
                isSpawn = true;
                SetRespawningPoint(transform.position);
                StartCoroutine(SpawnMonsters());
                GameManager.Instance.isPlaying = true;
                GameManager.Instance.StartGame();
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
        GameManager.Instance.isPlaying = true;
    }

    int GetMonsterRemaining() {
        int remaining = 0;
        for (int i = 0; i < monsterAmount; i++) {
            if (monsters[i].activeSelf) {
                remaining += 1;
            }
        }
        Debug.Log("Remaining" + remaining);
        return remaining;
    }

    void FinishStage() {
        GameManager.Instance.level = level + 1;    
    }

    void ClearStage() {
        GameManager.Instance.isPlaying = false;
        GameManager.Instance.timeRemaining = 0;
        totalMonsters = monsters.Length;
        if(totalMonsters >0){
            for (int i = 0; i < monsterAmount; i++) {
                Destroy(monsters[i]);
            }
        }  
    }
}
