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
            
        }
    }

    void SetRespawningPoint(Vector3 point) {
        monsters = new GameObject[monsterAmount];
        for (int i = 0; i < monsterAmount; i++) {
            monsters[i] = Instantiate(monster);
        }
        respawningPoint = point;
        timeRemaining = time;
        isPlaying = false;
    }
}
