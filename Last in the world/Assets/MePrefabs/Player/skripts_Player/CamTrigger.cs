using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CamTrigger : MonoBehaviour
{
    private GameObject Trigger;
    void OnTriggerEnter(Collider Player)
    {
        if (Player.gameObject.tag == "Player")
        {
            if (this.tag == "SmalRoom")
                CameraController.CameraTrigger = false;
            else if (this.tag == "BigRoom")
                CameraController.CameraTrigger = true;
        }
    }
    
}
