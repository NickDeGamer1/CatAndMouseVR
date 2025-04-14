using UnityEngine;

public class c_GameManager : MonoBehaviour
{

    [SerializeField]
    private RoundTimer roundTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        roundTimer = GameObject.Find("RoundTimer").GetComponent<RoundTimer>();

        StartGame();
    }

    void StartGame()
    {
        roundTimer.StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
