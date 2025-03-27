using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class VRPlayer : MonoBehaviour
{
    [Range(1f, 10f)]
    float speed = 1f;
    [SerializeField]
    VRHand LeftHand;
    [SerializeField]
    VRHand RightHand;
    [SerializeField]
    Camera head;
    private CharacterController cc;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float movement = (LeftHand.movementNum + RightHand.movementNum) / 2;
        if (movement > .01f)
        {

            Vector3 moveDir = -RightHand.GameObject().transform.up + -LeftHand.GameObject().transform.up; //(LeftHand.GameObject().transform.up + RightHand.GameObject().transform.up) / 2;
            moveDir = moveDir.normalized;
            moveDir = Vector3.Scale(moveDir, new Vector3(speed, 0, speed));
            cc.Move(moveDir);
        }
    }

    void OnVRLook(InputValue inv)
    {
        transform.Rotate(0, inv.Get<Vector2>().x, 0);
    }
}
