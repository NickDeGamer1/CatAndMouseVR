using UnityEngine;

public class c_Phycics : MonoBehaviour
{
    [SerializeField]
    CharacterController cc;

    public float PushForce = 4f;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rb = hit.collider.attachedRigidbody;
        if (rb == null || rb.isKinematic)
            return;
        if (hit.moveDirection.y < -.3f)
            return;

        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        rb.linearVelocity = pushDir * PushForce;
    }
}
