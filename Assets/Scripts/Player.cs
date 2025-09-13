using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private Animator animator;
    private Transform camera;

    public AudioSource WalkSound;
    public AudioSource jumpSound;
    public AudioSource landSound;
    public AudioSource Run;

    [SerializeField] private float speedWalk = 3f;
    [SerializeField] private float speedRun = 5f;
    
    private float VerticalVelocity = 0;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float gravity = -5f;

    private bool isWalk = false;
    private bool isRun = false;
    private bool isJump = false;
    public bool isIdle = true;
    private bool PickUp = false;

    float currentSpeed = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        camera = Camera.main.transform;
    }

    void Update()
    {
        float LR = Input.GetAxis("Horizontal");
        float SN = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(LR , 0 , SN);
        bool isMoving = move.magnitude > 0.1f;

        if (!isJump && !isRun && !isWalk)
            isIdle = true;
        else
            isIdle = false;
            

        if (isMoving) 
        {
            if (Input.GetKey(KeyCode.LeftShift)) 
            {
                EnterRunMode();
                currentSpeed = speedRun;
                ExitWalkMode();
            }
            else {
                ExitRunMode();
                EnterWalkMode();
                currentSpeed = speedWalk;
            }
            if(isJump){
                WalkSound.enabled = false;
                Run.enabled = false;
            }
        }
        else {
            ExitWalkMode();
            ExitRunMode();
            WalkSound.enabled = false;
        }

        if(controller.isGrounded)
        {
            if(isJump){
                ExitJumpMode();
            }

            if(Input.GetKeyDown(KeyCode.Space))
            {
                EnterJumpMode();
                VerticalVelocity = jumpHeight;
            }
        }

        else {
            VerticalVelocity += gravity * Time.deltaTime;
        }

        if(isMoving) {
            float Angle = Mathf.Atan2(move.x , move.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0 , Angle , 0);
        }

        move = camera.TransformDirection(move);
        move = new Vector3(move.x * currentSpeed , VerticalVelocity , move.z * currentSpeed);
        controller.Move(move * Time.deltaTime);
    }

    void EnterWalkMode()
    {
        isWalk = true;
        animator.SetBool("Walk", isWalk);
        WalkSound.enabled = true;
    }

    void ExitWalkMode()
    {
        isWalk = false;
        animator.SetBool("Walk", isWalk);
        WalkSound.enabled = false;
    }

    void EnterRunMode()
    {
        isRun = true;
        animator.SetBool("Run", isRun);
        Run.enabled = true;
    }

    void ExitRunMode()
    {
        isRun = false;
        animator.SetBool("Run", isRun);
        Run.enabled = false;
    }

    void EnterJumpMode()
    {
        isJump = true;
        animator.SetBool("jump", isJump);
        jumpSound.enabled = true;
    }

    void ExitJumpMode()
    {
        isJump = false;
        animator.SetBool("jump", isJump);
        jumpSound.enabled = false;
        landSound.Play();
    }

    public void PickUpItemMode() {
        PickUp = true;
        animator.SetBool("PickUp", PickUp);
    }

    public void ExitPickUpItemMode() {
        PickUp = false;
        animator.SetBool("PickUp", PickUp);
    }
}