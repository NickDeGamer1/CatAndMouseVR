using UnityEngine;

public class MousePuppet : MonoBehaviour
{
    [SerializeField]
    GameObject VRPlayer;
    [SerializeField]
    GameObject Cam;
    [SerializeField]
    Vector3 distance;


    // Update is called once per frame
    void Update()
    {
        transform.position = VRPlayer.transform.position + distance;
        transform.rotation = Cam.transform.rotation;
    }
}
