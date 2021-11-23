using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public bool isPlaying;
    public int level;
    public Vector3 respawningPoint;
    public GameObject[] monsters;
    public double timeRemaining;

    public double time;
    public GameObject monster;
    public int monsterAmount;

    private bool isSpawn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlaying) {
            if (timeRemaining > 0) {
                timeRemaining -= Time.deltaTime;
            }
            else {
                isPlaying = false;
            }
        } else {
            Debug.Log("monsterAmount -> "+monsterAmount);
        }
    }

    void SetRespawningPoint(Vector3 point) {
        monsters = new GameObject[monsterAmount];
        for (int i = 0; i < monsterAmount; i++) {
            monsters[i] = Instantiate(monster, new Vector3(point.x + Random.Range(-5f, 5f), point.y + Random.Range(0, 10f), point.z + Random.Range(-5f, 5f)), monster.transform.rotation);
            monsters[i].SetActive(false);
        }
        respawningPoint = point;
        timeRemaining = time;
        isPlaying = false;
    }

    public void StartStage() {
        if (!isSpawn) {
            isSpawn = true;
            SetRespawningPoint(transform.position);
            StartCoroutine(SpawnMonsters());
        }
    }

    private IEnumerator SpawnMonsters()
    {
        for (int i = 0; i < monsterAmount; i++) {
            monsters[i].SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }
        isPlaying = true;
    }
}
