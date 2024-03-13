using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField] float walkSpeed;
    [SerializeField] float Upness;
    [SerializeField] Collider2D groundCheck;

    bool isGrounded;
    bool isWalking;
    bool isIdle;

    Animator myAnimator;
    PlayerInteraction playerInteraction;
    Rigidbody2D myRigidBody;
    SpriteRenderer mySpriteRenderer;

    void Start()
    {
        playerInteraction = GetComponent<PlayerInteraction>();
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Walk();
        Jump();
        CheckForGround();
        StopMovingWhenDead();
        SetIdle();
        SetAnimatorBools();
    }

    void Walk()
    {
       if(playerInteraction.isAlive)
       {
            Vector2 walkVelocity =  new Vector2(walkSpeed*Input.GetAxis("Horizontal"), myRigidBody.velocity.y);
            myRigidBody.velocity = walkVelocity;
            if(Mathf.Sign(Input.GetAxis("Horizontal")) == -1 )
            {
                mySpriteRenderer.flipX = true;
            }
            else if(Mathf.Sign(Input.GetAxis("Horizontal")) == 1 )
            {
                mySpriteRenderer.flipX = false;
            }


            if(walkVelocity.x != 0 && isGrounded)
            {
                isWalking = true;
            }
            else
            {
                isWalking = false;
            }
       }
    }
    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            myRigidBody.velocity += new Vector2 (0, Upness);
            myAnimator.SetTrigger("JumpTransition");
        }
        else
        {
            myAnimator.ResetTrigger("JumpTransition");
        }


    }

    void CheckForGround()
    {
        if(groundCheck.IsTouchingLayers(LayerMask.GetMask("Ground")) || groundCheck.IsTouchingLayers(LayerMask.GetMask("Red")) || groundCheck.IsTouchingLayers(LayerMask.GetMask("Green")) || groundCheck.IsTouchingLayers(LayerMask.GetMask("Blue")))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

    }

    void StopMovingWhenDead()
    {
        if(!playerInteraction.isAlive)
        {
            myRigidBody.bodyType = RigidbodyType2D.Static;
        }
    }

    void SetAnimatorBools()
    {
        myAnimator.SetBool("isAlive", playerInteraction.isAlive);
        myAnimator.SetBool("isIdle", isIdle);
        myAnimator.SetBool("isWalking", isWalking);
        myAnimator.SetBool("isGrounded", isGrounded);
    }
    void SetIdle()
    {
        isIdle = !isWalking && isGrounded && playerInteraction.isAlive;
    }

}
