using UnityEngine;

public class c_CatCollider : MonoBehaviour
{

    public c_CatController catAttatched;
    //private c_ctSt_Class catState;

    void OnTriggerEnter(Collider other)
    {
        //catState = catAttatched.GetState();

        if (other.gameObject.tag == "MousePuppet"){
            Debug.Log("WIN!");
        }
    }
}
