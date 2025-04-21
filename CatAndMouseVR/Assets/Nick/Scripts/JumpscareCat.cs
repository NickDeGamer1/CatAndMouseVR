using JetBrains.Annotations;
using UnityEngine;

public class JumpscareCat : MonoBehaviour
{

    [SerializeField]
    GameObject[] JumpCats;

    [SerializeField]
    AudioSource jumpSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartJump(int playnum)
    {
        playnum--;
        GameObject activejump = JumpCats[playnum];
        activejump.SetActive(true);
        activejump.GetComponent<Animator>().SetTrigger("Active");
        jumpSound.Play();
    }
}
