using UnityEngine;
using UnityEngine.InputSystem;

//Adds the character controller automatically when the script is added
[RequireComponent(typeof(CharacterController))]

public class c_CatController : MonoBehaviour
{
    //CAT MOVEMENT
    public Vector2 movementInput = Vector2.zero;
    [SerializeField]
    public CharacterController controller;
    [SerializeField]
    private float playerSpeed = 3f;
    [SerializeField]
    private float playerRotate = 40f;
    [SerializeField]
    public float SENSI = 0.5f;
    
    //GRAVITY AND SHIZZ
    public Vector3 playerVelocity;
    public bool groundedPlayer;
    [SerializeField]
    public float gravityValue = -9.81f;
    public float jumpReset = 1.2f;
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
    private int jumpStage = 0; // 0 = not pouncing; 1 = readying to pounce; 2 = pouncing; 3 = getting back up;
    public bool hasJumped = false;

    //STATES
    public c_ctSt_Class currentState;
    public c_ctSt_Idle idleState = new c_ctSt_Idle();
    public c_ctSt_Walk walkState = new c_ctSt_Walk();
    public c_ctSt_Jump jumpState = new c_ctSt_Jump();
    public c_ctSt_Landed landedState = new c_ctSt_Landed();
    
    public c_ctSt_GettingUp gettingUpState = new c_ctSt_GettingUp();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = catModel.GetComponent<Animator>();
        animCreep = catCreepyModel.GetComponent<Animator>();
        controller = gameObject.GetComponent<CharacterController>();

        SwitchState(idleState);
    }

    public void OnMove(InputAction.CallbackContext context) 
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        hasJumped = context.action.triggered;
    }

    public void JumpStart()
    {
        Vector3 playerForward = transform.forward;
        
        //jump
        playerVelocity.y += Mathf.Sqrt(2f * -2.0f * gravityValue);

        //dash
        playerVelocity += playerForward * (Mathf.Sqrt(8f * -2.0f * gravityValue));
    }

    public void Move()
    {
        //moving and shizz
        if ((SENSI < movementInput.y) || ((-1 * SENSI) > movementInput.y)){
            controller.Move(transform.forward * movementInput.y * playerSpeed * Time.deltaTime);
        }

        //ROTATING AND SHIZZ WE SO UP RN (RIGHT NOW)!!!!
        if ((SENSI < movementInput.x) || ((-1 * SENSI) > movementInput.x)){
            transform.Rotate(transform.up, playerRotate * movementInput.x * Time.deltaTime);
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
}
