using TMPro;
using UnityEngine;

public class DisplayGameOver : MonoBehaviour
{
    [SerializeField]
    TextMeshPro tmp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void DisGameOver()
    {
        gameObject.SetActive(false);
        tmp.enabled = true;
    }
}
