using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;

    private double firingRate = 2;
    private double remainingFiringRate = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (remainingFiringRate <= 0) {
            GameObject bulletObj = Instantiate(bullet, transform.position, transform.rotation);
            bullet.transform.forward = transform.forward;
            remainingFiringRate = firingRate;
        }
        remainingFiringRate -= Time.deltaTime;
    }
}
