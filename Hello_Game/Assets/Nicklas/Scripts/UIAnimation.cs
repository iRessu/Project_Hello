using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(DestroyUI());
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(this.gameObject);
        }
    }

    private IEnumerator DestroyUI()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}
