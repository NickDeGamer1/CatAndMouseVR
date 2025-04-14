using UnityEngine;
using TMPro;
using UnityEngine.UI;

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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        roundStartCams[0].enabled = false;
        roundStartCams[1].enabled = false;
        roundStartCams[2].enabled = false;
        roundStartCams[3].enabled = false;

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
