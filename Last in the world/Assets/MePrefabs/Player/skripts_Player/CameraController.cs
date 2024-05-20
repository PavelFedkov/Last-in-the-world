using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    public float CameraY = 5f;
    public float CameraZ = 3f;
    public float camPositionSpeed = 5f;
    public static bool CameraTrigger;
    
    void Start()
    {
        CameraTrigger = true;
    }

    
    void FixedUpdate()
    {
        if (CameraTrigger == true)
        {
            Vector3 newCamPosition = new Vector3(10.5f, playerTransform.position.y + CameraY, playerTransform.position.z + CameraZ);
            transform.position = Vector3.Lerp(transform.position, newCamPosition, camPositionSpeed * Time.deltaTime);
            
        }
        else if (CameraTrigger == false)
        {
            
            Vector3 newCamPosition = new Vector3(7.5f, playerTransform.position.y + CameraY, playerTransform.position.z + CameraZ);
            transform.position = Vector3.Lerp(transform.position, newCamPosition, camPositionSpeed * Time.deltaTime);
        }
        
        
    }

    

    
}
