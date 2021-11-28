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
    private bool isReset = false;
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
        if (GameManager.Instance.gameState != GameConstant.playingState) {
            Destroy(gameObject);
        }
    }

    void Move() {
        var wpn = weapon.GetComponent<Weapon>();
        transform.LookAt(wpn.transform);
        var newPosition = transform.position + (movementDirection * movementSpeed * Time.deltaTime);
        var farther = Vector3.Dot(transform.forward, movementDirection) < 0;
        if (farther && Vector3.Distance(newPosition, wpn.transform.position) >= 18f) {
            transform.position = lastPosition;
            movementDirection = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
            if (Vector3.Dot(transform.forward, movementDirection) < 0) {
                movementDirection = movementDirection * -1.0f;
            }
        }
        else if (!isReset && Vector3.Distance(newPosition, wpn.transform.position) >= 25f) {
            Debug.Log(movementDirection);
            StartCoroutine(ResetMove());
        }
        else if (Vector3.Distance(newPosition, wpn.transform.position) >= 30f) {
            transform.position = wpn.transform.position + Random.insideUnitSphere * 10;
        }
        else {
            lastPosition = transform.position;
            transform.position = newPosition;
        }
    }

    private IEnumerator ResetMove() {
        isReset = true;
        transform.position = lastPosition;
        movementDirection = weapon.transform.position - transform.position;
        transform.position += (movementDirection * movementSpeed * Time.deltaTime);
        yield return new WaitForSeconds(3f);
        movementDirection = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        isReset = false;
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
