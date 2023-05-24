using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTransparent : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Material originalMaterial;
    public Material transparentMaterial;
    public LayerMask collisionLayer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            spriteRenderer.material = transparentMaterial;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            spriteRenderer.material = originalMaterial;
        }
    }
}
