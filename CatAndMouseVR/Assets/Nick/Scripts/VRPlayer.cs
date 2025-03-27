using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR;
using UnityEngine.XR.OpenXR.Input;

public class VRPlayer : MonoBehaviour
{
    public float speed = 1f;
    [SerializeField]
    GameObject LeftHandObject;
    VRHand LeftHand;
    [SerializeField]
    GameObject RightHandObject;
    VRHand RightHand;
    [SerializeField]
    Camera head;
    [SerializeField, Range(1, 100)]
    float vibCutoff = 1f;

    [SerializeField]
    TextMeshPro TMP;


    [SerializeField]
    GameObject DebugObj;

    private CharacterController cc;
    private XRNode rightHand = XRNode.RightHand;
    private XRNode leftHand = XRNode.LeftHand;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cc = GetComponent<CharacterController>();
        LeftHand = LeftHandObject.GetComponent<VRHand>();
        RightHand = RightHandObject.GetComponent<VRHand>();
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


        //SendHapticFeedback(1, Time.deltaTime);
        //SendHapticFeedback(1, Time.deltaTime);

        float dist = Vector3.Distance(transform.position, DebugObj.transform.position);

        if (TMP != null)
        {
            TMP.text = dist.ToString();
        }

        if (dist < vibCutoff && dist >= (vibCutoff * .6666))
        {
            SendHapticFeedback(0.33f, Time.deltaTime);
        }
        else if (dist < (vibCutoff * .6666) && dist >= (vibCutoff * .3333))
        {
            SendHapticFeedback(0.66f, Time.deltaTime);
        }
        else if (dist < (vibCutoff * .3333))
        {
            SendHapticFeedback(1, Time.deltaTime);
        }

    }

    void SendHapticFeedback(float amplitude, float duration)
    {
        UnityEngine.XR.InputDevice LeftHand = InputDevices.GetDeviceAtXRNode(leftHand);
        UnityEngine.XR.InputDevice RightHand = InputDevices.GetDeviceAtXRNode(rightHand);
        if (LeftHand.isValid && RightHand.isValid)
        {
            LeftHand.SendHapticImpulse(0, amplitude, duration);
            RightHand.SendHapticImpulse(0,amplitude, duration);
        }
    }

    void OnVRLook(InputValue inv)
    {
        transform.Rotate(0, inv.Get<Vector2>().x, 0);
    }
}
