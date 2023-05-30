using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public int roomIndex;

    private CameraManager cameraManager;

    // Start is called before the first frame update
    void Start()
    {
        cameraManager = FindObjectOfType<CameraManager>();    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            cameraManager.ActivateRoomCamera(roomIndex);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
       if(other.CompareTag("Player"))
        {
            cameraManager.ActivateFollowCamera();
        }
    }
}
