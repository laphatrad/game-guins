using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public Rigidbody boxRigid;
    private double firingRate = 0.25;
    private double remainingFiringRate = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) {
            boxRigid.AddForce(new Vector3(-3f, 0f, 0f));
        }
        if (Input.GetKey(KeyCode.D)) {
            boxRigid.AddForce(new Vector3(3f, 0f, 0f));
        }
        if (Input.GetKey(KeyCode.W)) {
            boxRigid.AddForce(new Vector3(0f, 0f, 3f));
        }
        if (Input.GetKey(KeyCode.S)) {
            boxRigid.AddForce(new Vector3(0f, 0f, -3f));
        }
        if (Input.GetKey(KeyCode.Space)) {
            boxRigid.AddForce(new Vector3(0f, 3f, 0f));
        }
        if (Input.GetKey(KeyCode.E)) {
            if (remainingFiringRate <= 0) {
                GameObject bulletObj = Instantiate(bullet, boxRigid.transform.position, boxRigid.transform.rotation);
                bullet.transform.forward = boxRigid.transform.forward;
                remainingFiringRate = firingRate;
            }
            remainingFiringRate -= Time.deltaTime;
        }
    }
}
