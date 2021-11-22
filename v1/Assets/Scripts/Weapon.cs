using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public Rigidbody boxRigid;
    public Transform gunEnd;
    public double hp = 100;

    public TMPro.TextMeshProUGUI txtHp;

    private double firingRate = 0.25;
    private double remainingFiringRate = 0;
    private double damage = 5;
    private LineRenderer laserLine;
    private Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        camera = GetComponentInParent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        txtHp.text = hp.ToString();
        remainingFiringRate -= Time.deltaTime;
    }

    public void Hit() {
        if (remainingFiringRate <= 0) {
            // Vector3 lineOrigin = camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
            // Debug.DrawRay(lineOrigin, camera.transform.forward * 100f, Color.green);
            // RaycastHit hit;
            // laserLine.SetPosition(0, gunEnd.position);
            // StartCoroutine(ShotEffect());
            // if (Physics.Raycast(lineOrigin, camera.transform.forward, out hit, 100f)) {
            //     laserLine.SetPosition (1, hit.point);
            //     Monster monster = hit.collider.GetComponent<Monster>();

            //     if (monster != null) {
            //         monster.TakeDamage(damage);
            //     }
            // }
            // else {
            //     laserLine.SetPosition (1, lineOrigin + (camera.transform.forward * 100f));
            // }
            GameObject bulletObj = Instantiate(bullet, transform.position, transform.rotation);
            bullet.transform.forward = transform.forward;
            remainingFiringRate = firingRate;
        }
    }

    public void TakeDamage(double damage) {
        hp -= damage;
    }

    private IEnumerator ShotEffect()
    {
        laserLine.enabled = true;
        yield return new WaitForSeconds(0.07f);
        laserLine.enabled = false;
    }
}
