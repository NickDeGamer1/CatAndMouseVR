using UnityEngine;
using UnityEngine.InputSystem;

//Adds the character controller automatically when the script is added
[RequireComponent(typeof(CharacterController))]

public class c_CatController : MonoBehaviour
{
    //Store cat input
    private Vector2 movementInput = Vector2.zero;
    [SerializeField]
    CharacterController controller;
    [SerializeField]
    private float playerSpeed = 3f;
    [SerializeField]
    private float playerRotate = 40f;
    [SerializeField]
    const float SENSI = 0.5f;

    [SerializeField]
    GameObject catModel;
    private Animator anim;

    private int jumpStage = 0; // 0 = not pouncing; 1 = readying to pounce; 2 = pouncing; 3 = getting back up;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = catModel.GetComponent<Animator>();
        controller = gameObject.GetComponent<CharacterController>();
    }

    public void OnMove(InputAction.CallbackContext context) 
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        hasJumped = context.action.triggered;
    }


    public void Move()
    {
        //moving and shizz
        if ((SENSI < movementInput.y) || ((-1 * SENSI) > movementInput.y)){
            anim.SetBool("isMoving", true);
            controller.Move(transform.forward * movementInput.y * playerSpeed * Time.deltaTime);
        }else{
            anim.SetBool("isMoving", false);
        }

        //ROTATING AND SHIZZ WE SO UP RN (RIGHT NOW)!!!!
        if ((SENSI < movementInput.x) || ((-1 * SENSI) > movementInput.x)){
            transform.Rotate(transform.up, playerRotate * movementInput.x * Time.deltaTime);
        }
    }

    public void Jump()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (jumpStage > 0){
            Jump();
        }else{
            Move();
        }
        
    }
}
