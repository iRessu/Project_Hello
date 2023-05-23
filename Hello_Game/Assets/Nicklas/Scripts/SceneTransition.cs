using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    public GameObject objectToActivate;
    public GameObject objectToDeactivate;
    //public Vector2 playerPosition;
    //public VectorValue playerStorage;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            objectToActivate.SetActive(true);
            objectToDeactivate.SetActive(false);
        }
    }
}
