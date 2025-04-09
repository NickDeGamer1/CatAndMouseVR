using UnityEngine;

public class c_CatCollider : MonoBehaviour
{

    public c_CatController catAttatched;

    void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.GetComponent<MousePuppet>() != null && catAttatched.currentState == jumpState){
        //    Debug.Log("CAT WIN!");
        //}
    }
}
