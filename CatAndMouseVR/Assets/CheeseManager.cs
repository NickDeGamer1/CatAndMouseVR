using UnityEngine;

public class CheeseManager : MonoBehaviour
{
    public bool CheeseActive = true;
    float CheeseTime = 45f;


    [SerializeField]
    GameObject cheesePrefab;

    GameObject[] CheeseSpawns;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CheeseSpawns = GameObject.FindGameObjectsWithTag("CheeseSpawnPoint");
        SpawnCheese();
    }

    // Update is called once per frame
    void Update()
    {
        if (!CheeseActive)
        {
            CheeseTime -= Time.deltaTime;

            if (CheeseTime < 0)
            {
                SpawnCheese();
            }
        }
    }

    void SpawnCheese()
    {
        int num = Random.Range(0, CheeseSpawns.Length-1);
        GameObject go = GameObject.Instantiate(cheesePrefab);
        go.transform.position = CheeseSpawns[num].transform.position;
        CheeseActive=true;
    }
}
