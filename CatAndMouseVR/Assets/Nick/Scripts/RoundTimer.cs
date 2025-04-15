using System;
using TMPro;
using UnityEngine;

public class RoundTimer : MonoBehaviour
{
    bool active = false;

    [SerializeField]
    float time;

    public float timerSpeed = 1.0f;

    public TextMeshProUGUI tmpro;

    private c_GameManager gameManaga;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManaga = GameObject.Find("GameManager").GetComponent<c_GameManager>();
    }

    public void StartTimer()
    {
        active = true;
    }
    public void PauseTimer()
    {
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            time -= Time.deltaTime * timerSpeed;

            if (tmpro != null)
            {
                tmpro.text = calctime(time);
            }
            //Debug.Log(calctime(time));
            if (time < 0)
            {
                active = false;
                Debug.Log("Mouse Wins!");
                gameManaga.LoseGame();

                //change scene to win
            }
        }
        
    }

    private string calctime(float timeleft)
    {
        string DisplayTime;

        int min = (int) timeleft / 60;
        
        int sec = (int) timeleft % 60;

        if (sec < 10)
        {
            DisplayTime = min + ":0" + sec;
        }
        else
        {
            DisplayTime = min + ":" + sec;
        }
        return DisplayTime;
    }

}
