using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetButton : MonoBehaviour
{
    // Start is called before the first frame update
    public Button button;
    public Stage stage;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        var btn = button.GetComponent<Button>();
        btn.onClick.AddListener(clickReset);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void clickReset(){
        Debug.Log("Click");
        var stg = stage.GetComponent<Stage>();
        stg.StartStage();
    }
}
