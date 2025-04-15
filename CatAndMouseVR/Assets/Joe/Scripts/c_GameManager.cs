using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class c_GameManager : MonoBehaviour
{

    [SerializeField]
    private RoundTimer roundTimer;
    [SerializeField]
    public Camera[] roundStartCams;
    [SerializeField]
    public GameObject[] catTeleports;
    [SerializeField]
    private RawImage bkgImg;
    [SerializeField]
    private GameObject[] pressStartText;
    [SerializeField]
    private Color darkerColor; //828282
    public GameObject[] cats;
    [SerializeField]
    public TextMeshProUGUI[] catNames;
    [SerializeField]
    private GameObject timerText;
    [SerializeField]
    private GameObject timerBox;
    [SerializeField]
    private GameObject dividers;
    [SerializeField]
    private GameObject controlsBox;

    [SerializeField]
    private GameObject catWinPopup;
    private Animator catWinAnim;

    private float gameEndingTimer = 4f;
    private bool gameEnding = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        catWinAnim = catWinPopup.GetComponent<Animator>();

        roundStartCams[0].enabled = false;
        roundStartCams[1].enabled = false;
        roundStartCams[2].enabled = false;
        roundStartCams[3].enabled = false;

        timerText.SetActive(false);

        catNames[0] = GameObject.Find("Name1").GetComponent<TextMeshProUGUI>();
        catNames[1] = GameObject.Find("Name2").GetComponent<TextMeshProUGUI>();
        catNames[2] = GameObject.Find("Name3").GetComponent<TextMeshProUGUI>();
        catNames[3] = GameObject.Find("Name4").GetComponent<TextMeshProUGUI>();

        catNames[0].text = "";
        catNames[1].text = "";
        catNames[2].text = "";
        catNames[3].text = "";

        roundTimer = GameObject.Find("RoundTimer").GetComponent<RoundTimer>();

        //StartGame();
    }

    public void StartGame()
    {
        roundStartCams[0].enabled = false;
        roundStartCams[1].enabled = false;
        roundStartCams[2].enabled = false;
        roundStartCams[3].enabled = false;

        timerText.SetActive(true);

        controlsBox.SetActive(false);

        catNames[0].text = "";
        catNames[1].text = "";
        catNames[2].text = "";
        catNames[3].text = "";
        
        bkgImg.CrossFadeColor(darkerColor, 4, true, false);

        pressStartText[0].SetActive(false);
        pressStartText[1].SetActive(false);
        pressStartText[2].SetActive(false);
        pressStartText[3].SetActive(false);

        cats = GameObject.FindGameObjectsWithTag("PlayerPrefab");

        for (int i = 0; i < cats.Length; i++) 
        {
            cats[i].GetComponent<CharacterController>().enabled = false;
            cats[i].transform.position = catTeleports[i].transform.position;
            cats[i].GetComponent<CharacterController>().enabled = true;
            cats[i].GetComponent<c_CatController>().SwitchState(cats[i].GetComponent<c_CatController>().idleState);
        }

        roundTimer.StartTimer();
    }

    public void WinGame(GameObject catID)
    {
        timerText.SetActive(false);
        timerBox.SetActive(false);
        dividers.SetActive(false);
        roundTimer.PauseTimer();

        //The camera controller
        c_CatCameras catCams = GameObject.Find("PlayerManager").GetComponent<c_CatCameras>();

        //Set cat that won to full screeen
        catCams.catCams[catID.GetComponent<PlayerInput>().playerIndex-1].rect = new Rect(0, 0, 1, 1);
    
        catWinAnim.SetTrigger("CatWin");

        gameEnding = true;

    }

    // Update is called once per frame
    void Update()
    {

        if (gameEnding){
            gameEndingTimer -= Time.deltaTime;
        }
        
        if (gameEndingTimer <= 0){

            //SceneManager.LoadScene(SceneManager.GetActiveScene());
        }
        
    }
}
