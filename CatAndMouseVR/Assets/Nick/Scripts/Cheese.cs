using UnityEngine;

public class Cheese : MonoBehaviour
{
    [SerializeField]
    GameObject Model;
    [SerializeField]
    ParticleSystem Part;
    
    private c_GameManager gameManaga;

    bool active = true;
    public bool Starting = false;

    RoundTimer timer;


    float num = 0;
    float killnum = .25f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = FindAnyObjectByType<RoundTimer>();
        gameManaga = GameObject.Find("GameManager").GetComponent<c_GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        num += Time.deltaTime;
        if (num > 2 * Mathf.PI)
            num = 0;
        Model.transform.Rotate(0, 40 * Time.deltaTime, 0);
        Model.transform.localPosition = new Vector3(0, (Mathf.Sin(num) * .25f) - .75f, 0);

        if (!active)
        {
            killnum -= Time.deltaTime;
            if (killnum < 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!Starting)
        {
            if (active)
            {
                timer.timerSpeed = timer.timerSpeed * 1.25f;
                Model.GetComponent<MeshRenderer>().enabled = false;
                //GameObject.FindAnyObjectByType<CheeseManager>().CheeseActive = false;
                active = false;
            }
        }
        else
        {
            if (GameObject.FindFirstObjectByType<c_PlayerManager>().playerList.Count > 1)
            {
                gameManaga.StartGame();
                Destroy(GameObject.FindGameObjectWithTag("ToDelete"));
                Destroy(gameObject);
            }
        }
    }
}
