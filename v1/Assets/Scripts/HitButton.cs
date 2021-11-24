using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitButton : MonoBehaviour
{
    public Button button;
    public Weapon weapon;
    public AudioSource shootSound;
    // Start is called before the first frame update
    void Start()
    {
        var btn = button.GetComponent<Button>();
        var wpn = weapon.GetComponent<Weapon>();
        btn.onClick.AddListener(wpn.Hit);
        shootSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
