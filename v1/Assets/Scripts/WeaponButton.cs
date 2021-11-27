using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponButton : MonoBehaviour
{
    // Start is called before the first frame update
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        var btn = button.GetComponent<Button>();
        btn.onClick.AddListener(SelectButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SelectButton() {
        Debug.Log("Click");
        GameManager.Instance.SetNewWeapon();
    }
}
