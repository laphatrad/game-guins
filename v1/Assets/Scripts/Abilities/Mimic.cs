using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mimic : MonoBehaviour
{
    public Penguin penguin;
    private Penguin createdPenguin;
    // Start is called before the first frame update
    void Start()
    {
        Weapon weapon = gameObject.GetComponent<Monster>().weapon;
        penguin.weapon = weapon;
        createdPenguin = Instantiate(penguin, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.gameState != GameConstant.playingState) {
            DestroyPenguin();
        }
    }

    void DestroyPenguin() {
        Destroy(createdPenguin);
    }
}
