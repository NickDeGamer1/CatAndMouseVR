using System;
using TMPro;
using UnityEngine;

public class RoundTimer : MonoBehaviour
{

    [SerializeField]
    float startTime = 10;

    [SerializeField]
    float time;

    [SerializeField]
    GameObject volume;

    [SerializeField]
    GameObject StartingPlace;

    private bool startTimerActive = false;
    private bool active = false;

    public float timerSpeed = 1.0f;

    [SerializeField]
    public GameObject tmpproObject;
    private Animator tmproAnim;
    public TextMeshProUGUI tmpro;
    public TextMeshPro playerTimeDisplay;

    [SerializeField]
    Animator mouseTimer;

    [SerializeField]
    AudioSource countdownNoise;

    [SerializeField]
    GameObject vrStartArea;

    [SerializeField]
    public GameObject mouseDisplay;
    private Animator mouseDisplayAnim;

    private c_GameManager gameManaga;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManaga = GameObject.Find("GameManager").GetComponent<c_GameManager>();
        tmproAnim = tmpproObject.GetComponent<Animator>();
        mouseDisplayAnim = mouseDisplay.GetComponent<Animator>();
    }

    public void StartCountdownTimer()
    {
        playerTimeDisplay.enabled = true;
        startTimerActive = true;
        tmproAnim.SetBool("countDown", true);
        mouseDisplayAnim.SetBool("timerGoing", true);
        mouseTimer.SetTrigger("Active");
        countdownNoise.Play();
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
        if (startTimerActive)
        {

            startTime -= Time.deltaTime;
            
            if (startTime > 1)
            {
                tmpro.text = ((int)startTime).ToString();
            }else{
                tmpro.text = "CHASE!";
            }

            playerTimeDisplay.text = ((int)startTime).ToString();

            
            

            if (startTime < 4 && !volume.activeSelf)
            {
                volume.SetActive(true);
                playerTimeDisplay.color = Color.red;
            }
            
            if (startTime < 1)
            {
                playerTimeDisplay.text = "RUN!";
            }

            
            if (startTime < 0)
            {
                startTimerActive = false;
                active = true;
                playerTimeDisplay.enabled = false;
                gameManaga.tpCats();
                tmproAnim.SetBool("countDown", false);
                mouseDisplayAnim.SetBool("timerGoing", true);
                mouseDisplay.SetActive(false);
                int count = GameObject.FindAnyObjectByType<c_PlayerManager>().playerList.Count;

                switch (count)
                {
                    case 2:
                    case 3:
                        GameObject.FindAnyObjectByType<VRPlayer>().speed = 7.5f;
                        break;
                    default:
                        GameObject.FindAnyObjectByType<VRPlayer>().speed = 10f;
                        break;
                }


                GameObject.FindAnyObjectByType<AmbinetNoise>().active = true;
                GameObject.FindAnyObjectByType<CheeseManager>().SpawnCheese();
                Destroy(vrStartArea);
            }
        }

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
                //Debug.Log("Mouse Wins!");
                gameManaga.LoseGame();
                playerTimeDisplay.enabled = true;
                playerTimeDisplay.color = Color.green;
                playerTimeDisplay.text = "You Win!";
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
