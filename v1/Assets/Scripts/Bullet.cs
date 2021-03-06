using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 16f;
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
        Debug.Log("Weapon Tag"+collider.gameObject.tag);
        if (collider.gameObject.tag == "Weapon") {
            Weapon weapon = collider.gameObject.GetComponent<Weapon>();
            weapon.TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
