using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public double hp = 20;
    public Weapon weapon;
    public GameObject bullet;

    private double firingRate = 2;
    private double remainingFiringRate = 0;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        var wpn = weapon.GetComponent<Weapon>();
        transform.LookAt(wpn.transform);

        if (hp <= 0) {
            Die();
        }

        if (remainingFiringRate <= 0) {
            GameObject bulletObj = Instantiate(bullet, transform.position, transform.rotation);
            bullet.transform.forward = transform.forward;
            remainingFiringRate = firingRate;
        }
        remainingFiringRate -= Time.deltaTime;
    }

    public void TakeDamage(double damage) {
        hp -= damage;
    }

    void Die() {
        Destroy(this.gameObject);
    }
}
