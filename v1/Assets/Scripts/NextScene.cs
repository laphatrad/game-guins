using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    // Start is called before the first frame update
    private int nextSceneToLoad;

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(NextSence);
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void NextSence(){
        SceneManager.LoadScene(nextSceneToLoad);
    }

}
