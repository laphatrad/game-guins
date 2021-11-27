using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        var btn = button.GetComponent<Button>();
        btn.onClick.AddListener(StartStage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartStage() {
        GameManager.Instance.selectStage.StartStage();
    }
}
