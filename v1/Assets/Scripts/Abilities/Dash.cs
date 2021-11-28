using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public double cooldown = 8;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        if (cooldown <= 0) {
            StartCoroutine(UseDash());
            cooldown = 13;
        }
    }

    private IEnumerator UseDash()
    {
        Debug.Log("Use Dash");
        Monster monster = gameObject.GetComponent<Monster>();
        monster.movementSpeed = monster.movementSpeed * 4;
        Debug.Log(monster.movementSpeed);
        yield return new WaitForSeconds(3f);
        monster.movementSpeed = monster.movementSpeed / 4;
        Debug.Log(monster.movementSpeed);
    }
}
