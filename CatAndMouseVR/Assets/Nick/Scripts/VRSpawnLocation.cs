using UnityEngine;

public class VRSpawnLocation : MonoBehaviour
{
    BoxCollider bc;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bc = GetComponent<BoxCollider>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("VRPlayer"))
        {
            //Emit Game started
            GameObject.FindAnyObjectByType<RoundTimer>().StartCountdownTimer();

            Destroy(gameObject);
        }
    }
}
