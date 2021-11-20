using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PrevScene : MonoBehaviour
{
    // Start is called before the first frame update
    // using UnityEngine.UI;
    // using UnityEngine.SceneManagement;
    private int nextSceneToLoad;

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(NextSence);
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex - 1;
    }

    public void NextSence(){
        SceneManager.LoadScene(nextSceneToLoad);
    }

}
