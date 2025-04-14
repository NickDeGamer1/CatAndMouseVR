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
        float movement = (LeftHand.movementNum + RightHand.movementNum) / 2;
        if (movement > .01f)
        {
            isMove = true;
            moveDir = -RightHand.GameObject().transform.up + -LeftHand.GameObject().transform.up; //(LeftHand.GameObject().transform.up + RightHand.GameObject().transform.up) / 2;
            moveDir = moveDir.normalized;
            moveDir = Vector3.Scale(moveDir, new Vector3(speed, 0, speed));
            cc.Move(moveDir);
        }
        else
        {
            isMove = false;
        }

        FSReset -= Time.deltaTime;
        if (FSReset < 0)
        {
            FSPlayersUpdate();
            FSReset = 1;
        }

        //SendHapticFeedback(1, Time.deltaTime);
        //SendHapticFeedback(1, Time.deltaTime);

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


    public void OnVRLook(InputValue inv)
    {
        transform.Rotate(0, inv.Get<Vector2>().x, 0);
    }
}
