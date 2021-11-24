using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public double hp = 20;
    public Weapon weapon;
    public GameObject bullet;
    public AudioSource DeathSound;

    private double firingRate = 2;
    private double remainingFiringRate = 0;
    private float movementSpeed = 5f;
    private Vector3 lastPosition;
    private Vector3 movementDirection;
    // Start is called before the first frame update
    void Start() {
        movementDirection = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
    }

    // Update is called once per frame
    void Update() {
        var wpn = weapon.GetComponent<Weapon>();
        transform.LookAt(wpn.transform);
        var newPosition = transform.position + (movementDirection * movementSpeed * Time.deltaTime);
        var farther = Vector3.Distance(lastPosition, wpn.transform.position) < Vector3.Distance(newPosition, wpn.transform.position);
        if (farther && Vector3.Distance(newPosition, wpn.transform.position) >= 20f) {
            // Transform newDirection = transform;
            // newDirection.Rotate(Random.Range(0, 90.0f), Random.Range(0, 90.0f), Random.Range(0, 90.0f));
            // movementDirection = newDirection.position;
            movementDirection = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
            // Debug.Log(Vector3.Dot(transform.forward, movementDirection));
            if (Vector3.Dot(transform.forward, movementDirection) < 0) {
                movementDirection = movementDirection * -1;
            }
            // movementDirection = transform.forward;
        } else {
            lastPosition = transform.position;
            transform.position = newPosition;
        }
        if (hp <= 0) {
            DeathSound.Play();
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
        Debug.Log("Monster Die");
        GameManager.Instance.score += score;
        this.gameObject.SetActive(false);
    }
}
