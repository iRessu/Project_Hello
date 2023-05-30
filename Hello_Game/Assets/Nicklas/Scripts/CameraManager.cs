using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public CinemachineVirtualCamera[] roomCameras;
    public CinemachineVirtualCamera followCamera;

    private CinemachineVirtualCamera activeCamera;
    private CinemachineBrain cinemachineBrain;
    void Start()
    {

        foreach(CinemachineVirtualCamera roomCamera in roomCameras)
        {
            roomCamera.gameObject.SetActive(false);
        }
        
        cinemachineBrain = FindObjectOfType<CinemachineBrain>();
        

        ActivateFollowCamera();
    }

    public void ActivateRoomCamera(int roomIndex)
    {
        if(activeCamera != null)
        {
            activeCamera.gameObject.SetActive(false);
        }
       
        if(roomIndex >= 0 && roomIndex < roomCameras.Length)
        {
            CinemachineVirtualCamera roomCamera = roomCameras[roomIndex];
            roomCamera.gameObject.SetActive(true);
            activeCamera = roomCamera;
        }
        StartCoroutine(DisableEnableCinemachineBrain());
    }

    public void ActivateFollowCamera()
    {
        if(activeCamera != null)
        {
            activeCamera.gameObject.SetActive(false);
        }
        

        followCamera.gameObject.SetActive(true);
        activeCamera = followCamera;

        StartCoroutine(DisableEnableCinemachineBrain());
    }

    private IEnumerator DisableEnableCinemachineBrain()
    {
        if(cinemachineBrain != null)
        {
            cinemachineBrain.enabled = false;
            yield return null;
            cinemachineBrain.enabled = true;
        }
    }
}
