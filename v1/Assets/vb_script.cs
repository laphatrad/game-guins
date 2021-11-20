using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class vb_script : MonoBehaviour
{
    public GameObject vbBtnObj;
    public GameObject bullet;
    public Rigidbody boxRigid;
    private double firingRate = 0.25;
    private double remainingFiringRate = 0;
    // Start is called before the first frame update
    void Start()
    {
        // vbBtnObj = GameObject.Find("action");
        // vbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed); 
        // vbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(OnButtonReleased);
 
    }

    // public void OnButtonPressed(VirtualButtonBehaviour vb){
    //     GameObject bulletObj = Instantiate(bullet, boxRigid.transform.position, boxRigid.transform.rotation);
    //     bullet.transform.forward = boxRigid.transform.forward;
    // }

    // public void OnButtonPressed(VirtualButtonBehaviour vb)
    // {
    //     // cubeAni.Play("cube_animation");
    //     GameObject bulletObj = Instantiate(bullet, boxRigid.transform.position, boxRigid.transform.rotation);
    //     bullet.transform.forward = boxRigid.transform.forward;
    //     Debug.Log("Button pressed");
    // }
 
    // public void OnButtonReleased(VirtualButtonBehaviour vb)
    // {
    //     // cubeAni.Play("none");
    //     Debug.Log("Button released");
    // }

    // Update is called once per frame
    void Update()
    {

    }

}
