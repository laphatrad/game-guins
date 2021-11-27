using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Badge : MonoBehaviour
{
    public Sprite level1;
    public Sprite level2;
    public Sprite level3;

    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameManager.Instance.level) {
            case 1: {
                image.sprite = level1;
                break;
            }
            case 2: {
                image.sprite = level2;
                break;
            }
            case 3: {
                image.sprite = level3;
                break;
            }
        }
    }
}
