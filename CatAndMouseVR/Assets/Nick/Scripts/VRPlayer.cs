using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.Rendering;
using UnityEngine.XR;
using UnityEngine.XR.OpenXR.Input;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Readers;

public class VRPlayer : MonoBehaviour
{
    public float speed = 10f;
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
    VolumeProfile vp;


    public bool isMove = false;
    public Vector3 moveDir = new Vector3();

    [SerializeField]
    TextMeshPro TMP;


    [SerializeField]
    GameObject DebugObj;

    GameObject[] fsPlayers;


    private CharacterController cc;
    private XRNode rightHand = XRNode.RightHand;
    private XRNode leftHand = XRNode.LeftHand;
    private float FSReset = 1f;
    private bool MovingIsAct = true;
    public float timer = 10f;

    TCPClient audioserver;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cc = GetComponent<CharacterController>();
        LeftHand = LeftHandObject.GetComponent<VRHand>();
        RightHand = RightHandObject.GetComponent<VRHand>();
        fsPlayers = GameObject.FindGameObjectsWithTag("Player");


        audioserver = GameObject.FindGameObjectWithTag("AudioServer").GetComponent<TCPClient>();
    }


    public void FSPlayersUpdate()
    {
        fsPlayers = GameObject.FindGameObjectsWithTag("Player");
        gameObject.GetComponent<PlayerInput>().ActivateInput();
    }

    // Update is called once per frame
    void Update()
    {
        if (MovingIsAct)
        {
            float movement = (LeftHand.movementNum + RightHand.movementNum) / 2;
            if (movement > .01f)
            {
                isMove = true;
                moveDir = -RightHand.GameObject().transform.up + -LeftHand.GameObject().transform.up; //(LeftHand.GameObject().transform.up + RightHand.GameObject().transform.up) / 2;
                moveDir = moveDir.normalized;
                moveDir = Vector3.Scale(moveDir, new Vector3(speed * Time.deltaTime, 0, speed * Time.deltaTime));
                cc.Move(moveDir);
            }
            else
            {
                isMove = false;
            }
        }
        else
        {
            if (timer < 0)
                MovingIsAct = true;
            else
                timer -= Time.deltaTime;
        }


        FSReset -= Time.deltaTime;
        if (FSReset < 0)
        {
            FSPlayersUpdate();
            FSReset = 1;
        }

        UnityEngine.XR.InputDevice device = InputDevices.GetDeviceAtXRNode(rightHand);

        if (device.isValid)
        {
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue))
            {
                //Debug.Log(primary2DAxisValue.ToString());
                if (primary2DAxisValue.x > .05f || primary2DAxisValue.x < -.05f)
                    LookVR(primary2DAxisValue.x);
            }
        }

        cc.center = new Vector3(head.transform.localPosition.x, head.transform.localPosition.y / 2, head.transform.localPosition.z);
        cc.height = head.transform.localPosition.y;


        float dist = vibCutoff + 1;

        foreach(GameObject i in fsPlayers) {
            if (Vector3.Distance(transform.position, i.transform.position) < vibCutoff)
            {
                dist = Vector3.Distance(transform.position, i.transform.position);
                break;
            }
        }

        if (dist < vibCutoff)
        {
            float Strength = 1 - (dist / vibCutoff);
            SendFeedback(Strength, Time.deltaTime);
        }

        if (TMP != null)
        {
            TMP.text = dist.ToString();
        }
    }

    void SendFeedback(float amplitude, float duration)
    {
        UnityEngine.XR.InputDevice LeftHand = InputDevices.GetDeviceAtXRNode(leftHand);
        UnityEngine.XR.InputDevice RightHand = InputDevices.GetDeviceAtXRNode(rightHand);
        if (LeftHand.isValid && RightHand.isValid)
        {
            LeftHand.SendHapticImpulse(0, amplitude, duration);
            RightHand.SendHapticImpulse(0,amplitude, duration);
        }
    }


    public void LookVR(float movex)
    {
        transform.Rotate(0, movex * 1.5f, 0);
    }
}
