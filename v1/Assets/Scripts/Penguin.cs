using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguin : MonoBehaviour
{
    public double hp = 20;
    public Weapon weapon;
    public float movementSpeed = 5f;

    public ParticleSystem blood;
    private ParticleSystem initiatedBlood;

    public AudioSource DeathSound;

    private Vector3 lastPosition;
    private Vector3 movementDirection;
    // Start is called before the first frame update
    void Start() {
        movementDirection = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        initiatedBlood = Instantiate(blood, transform.position, transform.rotation);
        initiatedBlood.transform.parent = transform;
    }

    // Update is called once per frame
    void Update() {
        Move();
        if (hp <= 0) {
            Die();
        }
    }

    void Move() {
        var wpn = weapon.GetComponent<Weapon>();
        transform.LookAt(wpn.transform);
        var newPosition = transform.position + (movementDirection * movementSpeed * Time.deltaTime);
        var farther = Vector3.Distance(lastPosition, wpn.transform.position) < Vector3.Distance(newPosition, wpn.transform.position);
        if (farther && Vector3.Distance(newPosition, wpn.transform.position) >= 20f) {
            movementDirection = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
            if (Vector3.Dot(transform.forward, movementDirection) < 0) {
                movementDirection = movementDirection * -1;
            }
        } else {
            lastPosition = transform.position;
            transform.position = newPosition;
        }
    }

    public void TakeDamage(double damage) {
        GameManager.Instance.hp -= damage;
        hp -= damage;
        initiatedBlood.Play();
    }

    void Die() {
        this.gameObject.SetActive(false);
    }
}
