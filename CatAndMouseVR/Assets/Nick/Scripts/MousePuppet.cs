using System;
using UnityEngine;

public class MousePuppet : MonoBehaviour
{
    [SerializeField]
    GameObject Cam;
    void Update()
    {
        Quaternion lookdir = Cam.transform.rotation;
        lookdir.x = 0;
        lookdir.z = 0;
        transform.rotation = lookdir;
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.GetComponent<c_CatController>() != null){
            other.gameObject.GetComponent<c_CatController>().CatCatch();
        //}
    }
}
