using TMPro;
using UnityEngine;
using UnityEngine.XR;

public class VRHand : MonoBehaviour
{
    public float movementNum = 0.0f;
    public TextMeshPro textMeshPro;
    private Vector3 bufferPos = new Vector3(0,0,0);


    private void FixedUpdate()
    {
        float moveX = transform.localPosition.x - bufferPos.x;
        float moveY = transform.localPosition.y - bufferPos.y;
        float moveZ = transform.localPosition.z - bufferPos.z;

        movementNum = (Mathf.Abs(moveX) + Mathf.Abs(moveY) + Mathf.Abs(moveZ)) / 3;

        if (textMeshPro != null )
        {
            textMeshPro.text = movementNum.ToString();
        }
        bufferPos = transform.localPosition;
    }


}
