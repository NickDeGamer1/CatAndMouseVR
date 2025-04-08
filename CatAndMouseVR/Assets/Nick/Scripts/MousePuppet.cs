using System;
using UnityEngine;

public class MousePuppet : MonoBehaviour
{
    [SerializeField]
    GameObject VRPlayer;
    VRPlayer vp;
    [SerializeField]
    GameObject Cam;
    //[SerializeField]
    //Vector3 distance;

    private void Start()
    {
        vp = VRPlayer.GetComponent<VRPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = VRPlayer.transform.position + distance;
        if (vp.isMove)
        {
            transform.rotation = Quaternion.LookRotation(VRPlayer.GetComponent<VRPlayer>().moveDir);
        }
        else
        {
            Quaternion lookdir = Cam.transform.rotation;
            transform.rotation = lookdir;
        }

    }
}
