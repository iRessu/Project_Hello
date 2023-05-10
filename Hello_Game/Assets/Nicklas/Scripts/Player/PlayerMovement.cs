using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float currentMoveSpeed;
    public float moveSpeed = 5f;
    public float sprintMoveSpeed = 10f;
    private bool isSprinting;
    private Rigidbody2D rb;

    private StaminaBar stamBar;

    private float drainRate = 0.5f / 100;
    private float timer = 0f;

    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stamBar = FindObjectOfType<StaminaBar>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(Input.GetKey(KeyCode.Space) && stamBar.currentStamina > 0.003f && !isSprinting)
        {
            isSprinting = true;
            timer += Time.deltaTime;
            while(timer >= drainRate)
            {
                stamBar.UseStamina(0.2f);
                timer -= drainRate;
            }
        }
        else
        {
            isSprinting = false;
            stamBar.StopCoroutine(stamBar.regen);
            stamBar.regen = null;
        }
       
        
    }

    private void FixedUpdate()
    {
        currentMoveSpeed = isSprinting && stamBar.currentStamina > 0.003f ? sprintMoveSpeed : moveSpeed;
        rb.MovePosition(rb.position + movement * currentMoveSpeed * Time.fixedDeltaTime);
    }
}
