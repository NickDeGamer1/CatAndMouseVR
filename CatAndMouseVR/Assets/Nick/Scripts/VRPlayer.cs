using Unity.VisualScripting;
using UnityEngine;

public class VRPlayer : MonoBehaviour
{
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
            Vector3 moveDir = head.GameObject().transform.forward;//(LeftHand.GameObject().transform.up + RightHand.GameObject().transform.up) / 2;
            moveDir = Vector3.Scale(moveDir, new Vector3(1, 0, 1));
            cc.Move(moveDir);
        }
    }
}
