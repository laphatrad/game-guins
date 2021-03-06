using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 100f;
    public double damage = 20;
    private Vector3 firstPosition;
    // Start is called before the first frame update
    void Start()
    {
        firstPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        if (Vector3.Distance(transform.position, firstPosition) > 100) {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider collider) {
        Debug.Log("Tag"+collider.gameObject.tag);
        if (collider.gameObject.tag == "Monster") {
            Monster monster = collider.gameObject.GetComponent<Monster>();
            monster.TakeDamage(damage);
            Destroy(this.gameObject);
        }
        if (collider.gameObject.tag == "Penguin") {
            Penguin penguin = collider.gameObject.GetComponent<Penguin>();
            penguin.TakeDamage(damage);
            Destroy(this.gameObject);
        }
        if (collider.gameObject.tag == "Bullet") {
            Bullet bullet = collider.gameObject.GetComponent<Bullet>();
            Destroy(bullet.gameObject);
            Destroy(this.gameObject);
        }
    }
}
