using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

//Adds the character controller automatically when the script is added
[RequireComponent(typeof(CharacterController))]

public class c_CatController : MonoBehaviour
{

    //AUDIO
    public TCPClient audioserver;

    //CAT MOVEMENT
    public Vector2 movementInput = Vector2.zero;
    public Vector2 turnInput = Vector2.zero;
    [SerializeField]
    public CharacterController controller;
    [SerializeField]
    private float playerSpeed = 15f;
    [SerializeField]
    private float playerRotate = 100f;
    [SerializeField]
    public float jumpForce = 4f;
    [SerializeField]
    public float SENSI = 0.5f;
    
    //GRAVITY AND SHIZZ
    public Vector3 playerVelocity;
    public bool groundedPlayer;
    [SerializeField]
    public float gravityValue = -9.81f;
    public float jumpReset = 1.1f;
    public bool canJump = true;
    private bool timerActive = false;

    //ANIMS
    [SerializeField]
    GameObject catModel;
    [SerializeField]
    GameObject catCreepyModel;
    public Animator anim;
    public Animator animCreep;

    //POUNCING
    public bool hasJumped = false;

    //STATES
    public c_ctSt_Class currentState;
    public c_ctSt_Idle idleState = new c_ctSt_Idle();
    public c_ctSt_Walk walkState = new c_ctSt_Walk();
    public c_ctSt_Jump jumpState = new c_ctSt_Jump();
    public c_ctSt_Landed landedState = new c_ctSt_Landed();
    public c_ctSt_GettingUp gettingUpState = new c_ctSt_GettingUp();
    public c_ctSt_Start startState = new c_ctSt_Start();

    //CAMERA
    public c_CatCameras catCams;
    [SerializeField]
    public PlayerInput playaInput;
    public c_PlayerManager playaManaga;

    //Management
    public bool hasStarted = false;
    public c_GameManager gameManaga;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Cute Cat Animator
        anim = catModel.GetComponent<Animator>();
        //Creepy Cat Animator
        animCreep = catCreepyModel.GetComponent<Animator>();
        //Character Controller
        controller = gameObject.GetComponent<CharacterController>();
        //The camera controller
        catCams = GameObject.Find("PlayerManager").GetComponent<c_CatCameras>();
        //The player manager
        playaManaga = GameObject.Find("PlayerManager").GetComponent<c_PlayerManager>();
        //PlayerInput
        playaInput = gameObject.GetComponent<PlayerInput>();
        //Audio
        audioserver = GameObject.FindGameObjectWithTag("AudioServer").GetComponent<TCPClient>();
        //The game controller
        gameManaga = GameObject.Find("GameManager").GetComponent<c_GameManager>();

        controller.enabled = false;
        transform.position = GameObject.Find("CatSpawnPoint " + playaInput.playerIndex).transform.position;
        controller.enabled = true;

        //StartCams
        switch (playaInput.playerIndex -1){
        
        case 0:

            gameManaga.roundStartCams[0].enabled = true;
            break;

        case 1:
            gameManaga.roundStartCams[1].enabled = true;
            gameManaga.roundStartCams[1].rect = new Rect(0.5f, 0, 0.5f, 0.5f);
            break;

        case 2:
            gameManaga.roundStartCams[2].enabled = true;
            gameManaga.roundStartCams[1].rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
            break;

        case 3:
            gameManaga.roundStartCams[3].enabled = true;
            break;
        }

        jumpReset = 1.1f;

        SwitchState(startState);

        catCams.catCams[playaInput.playerIndex - 1] = playaInput.camera;

        catCams.UpdateCams(playaInput.playerIndex);
    }

    public void OnMove(InputAction.CallbackContext context) 
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        hasJumped = context.action.triggered;
    }
    public void OnTurn(InputAction.CallbackContext context)
    {
        turnInput = context.ReadValue<Vector2>();
    }
    public void OnStart(InputAction.CallbackContext context)
    {
        gameManaga.StartGame();
    }

    public void JumpStart()
    {
        Vector3 playerForward = transform.forward;
        
        //jump
        playerVelocity.y += Mathf.Sqrt(1f * -2.0f * gravityValue);

        //dash
        playerVelocity += playerForward * (Mathf.Sqrt(jumpForce * -2.0f * gravityValue));

        //play Cat noise
        //audioserver.PlayAudioTV("BabaBoohey.wav");
    }

    public void Move()
    {
        //moving and shizz
        if ((SENSI < movementInput.y) || ((-1 * SENSI) > movementInput.y)){
            controller.Move(transform.forward * movementInput.y * playerSpeed * Time.deltaTime);
        }
    }

    public void EnsureGrounded()
    {
        //Makes sure the player is grounded
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        
        //anim
        if ((SENSI < movementInput.y) || ((-1 * SENSI) > movementInput.y) && currentState != jumpState){
            anim.SetBool("isMoving", true);
            animCreep.SetBool("isMoving", true);
        }else{
            anim.SetBool("isMoving", false);
            animCreep.SetBool("isMoving", false);
        }
        
        if (timerActive){

            jumpReset -= Time.deltaTime;
        }
        
        if (jumpReset <= 0.0f){
            canJump = true;
            timerActive = false;
            jumpReset = 1.1f;
        }

        //ROTATING AND SHIZZ WE SO UP RN (RIGHT NOW)!!!!
        if (((SENSI < turnInput.x) || ((-1 * SENSI) > turnInput.x)) && (currentState != jumpState) && (currentState != landedState)){
            transform.Rotate(transform.up, playerRotate * turnInput.x * Time.deltaTime);
        }

    }

    public void JumpCountDown()
    {
        timerActive = true;
    }

    public void SwitchState(c_ctSt_Class newState)
    {
        currentState = newState;

        currentState.EnterState(this);
    }

    public c_ctSt_Class GetState()
    {
        return currentState;
    }
}
