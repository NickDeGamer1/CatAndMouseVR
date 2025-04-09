using UnityEngine;

public class c_CatCollider : MonoBehaviour
{

    public c_CatController catAttatched;

    void OnTriggerEnter(Collider other)
    {
<<<<<<< Updated upstream
        //if (other.gameObject.GetComponent<MousePuppet>() != null && catAttatched.currentState == jumpState){
        //    Debug.Log("CAT WIN!");
        //}
=======
        if (other.gameObject.GetComponent<MousePuppet>() != null && catAttatched.currentState == catAttatched.jumpState){
            Debug.Log("CAT WIN!");
        }
>>>>>>> Stashed changes
    }
}
