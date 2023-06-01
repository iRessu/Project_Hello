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

    public GameObject activateObject;
    public float stillTimeThreshold;
    private float stillTimer = 0f;
    private bool objectIsActive = false;
   

    private bool isFacingleft;

    private StaminaBar stamBar;

    private float drainRate = 0.5f / 100;
    private float timer = 0f;

    //Animations

    private Animator animator;

    public string currentAnimation;
    public string currentState;

    //Animation states

    const string PLAYER_WALK = "Player_WalkAN;";
    const string PLAYER_IDLE = "Player_IdleAN";

    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        stamBar = FindObjectOfType<StaminaBar>();
       
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(Input.GetKey(KeyCode.LeftShift) && stamBar.currentStamina > 0.2f && !isSprinting)
        {
            isSprinting = true;
            timer += Time.deltaTime;
            while(timer >= drainRate)
            {
                stamBar.UseStamina(0.5f);
                timer -= drainRate;
            }
        }
        else
        {
            isSprinting = false;
            stamBar.StopCoroutine(stamBar.RegenStamina());
        }
        Flip();


        if(movement.x == 0 && movement.y == 0)
        {
            stillTimer += Time.deltaTime;

            if(stillTimer >= stillTimeThreshold && !objectIsActive)
            {
                objectIsActive = true;
                activateObject.SetActive(true);
            }
        }
        else
        {
            stillTimer = 0f;
            if(objectIsActive)
            {
                objectIsActive = false;
                activateObject.SetActive(false);
            }
        }
        
    }

    private void FixedUpdate()
    {
        currentMoveSpeed = isSprinting && stamBar.currentStamina > 0.2f ? sprintMoveSpeed : moveSpeed;
        rb.MovePosition(rb.position + movement * currentMoveSpeed * Time.fixedDeltaTime);

        if (movement.x != 0 || movement.y != 0)
        {
            ChangeAnimationState(PLAYER_WALK);
        }
        else
        {
            ChangeAnimationState(PLAYER_IDLE);
        }
    }

    private void ChangeAnimationState(string newState)
    {
        if (currentAnimation == newState) return;
        animator.Play(newState);
    }

    void Flip()
    {
        if(!isFacingleft && movement.x > 0f || isFacingleft && movement.x < 0f)
        {
            isFacingleft = !isFacingleft;
            Vector3 localscale = transform.localScale;
            localscale.x *= -1;
            transform.localScale = localscale;
        }
    }
}
