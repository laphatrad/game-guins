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
        var newPosition = transform.position + movementDirection * movementSpeed * Time.deltaTime;
        Debug.Log(Vector3.Distance(transform.position, wpn.transform.position));
        var farther = Vector3.Distance(lastPosition, wpn.transform.position) < Vector3.Distance(newPosition, wpn.transform.position);
        if (farther && Vector3.Distance(newPosition, wpn.transform.position) >= 10f) {
            // Transform newDirection = transform;
            // newDirection.Rotate(Random.Range(0, 90.0f), Random.Range(0, 90.0f), Random.Range(0, 90.0f));
            // movementDirection = newDirection.position;
            while (Vector3.Angle(transform.forward, movementDirection) >= 90.0f) {
                movementDirection = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
            }
            // movementDirection = transform.forward;
        } else {
            lastPosition = transform.position;
            transform.position = newPosition;
        }
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
