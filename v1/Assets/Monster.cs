using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public double hp = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0) {
            Die();
        }
    }

    public void TakeDamage(double damage) {
        hp -= damage;
    }

    void Die() {
        Destroy(this.gameObject);
    }
}
