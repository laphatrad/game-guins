using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public Rigidbody boxRigid;
    public Transform gunEnd;    

    public TMPro.TextMeshProUGUI txtHp;

    public string name;
    public double firingRate;
    private double remainingFiringRate = 0;
    public double damage;
    public int minimumLevel;    
    private Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponentInParent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        txtHp.text = GameManager.Instance.hp.ToString();
        remainingFiringRate -= Time.deltaTime;
    }

    public void Hit() {
        if (remainingFiringRate <= 0) {
            GameObject bulletObj = Instantiate(bullet, transform.position, transform.rotation);
            bullet.transform.forward = transform.forward;
            bullet.transform.rotation = transform.rotation;
            remainingFiringRate = firingRate;
        }
    }

    public void TakeDamage(double damage) {
        GameManager.Instance.hp -= damage;
    }

    public void ShowWeaponDetail() {
        if (GameManager.Instance.gameState == GameConstant.initState) {
            GameManager.Instance.gameState = GameConstant.selectWeaponState;
            GameManager.Instance.selectWeapon = gameObject.GetComponent<Weapon>();
        }
    }

    public void HideWeaponDetail() {
        if (GameManager.Instance.gameState == GameConstant.selectWeaponState) {
            GameManager.Instance.gameState = GameConstant.initState;
            GameManager.Instance.selectWeapon = null;
        }
    }
}
