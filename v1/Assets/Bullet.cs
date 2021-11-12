using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 16f;
    public double damage = 5;
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
        if (collider.gameObject.tag == "Monster") {
            Monster monster = collider.gameObject.GetComponent<Monster>();
            monster.TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
