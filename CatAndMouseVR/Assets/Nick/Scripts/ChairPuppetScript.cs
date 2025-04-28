using UnityEngine;

public class ChairPuppetScript : MonoBehaviour
{
    [SerializeField]
    GameObject Chair;

    // Update is called once per frame
    void Update()
    {
        Chair.transform.position = new Vector3(transform.position.x, transform.position.y - 25, transform.position.z);
        Chair.transform.rotation = transform.rotation;
    }
}
