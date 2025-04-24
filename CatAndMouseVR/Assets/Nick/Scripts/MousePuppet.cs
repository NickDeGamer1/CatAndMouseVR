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
        Debug.Log(other);
        other.gameObject.GetComponent<c_CatController>().CatCatch();
        if (other.gameObject.GetComponent<c_CatController>() == null){
            other.gameObject.transform.parent.GetComponent<c_CatController>().CatCatch();
        }
    }
}
