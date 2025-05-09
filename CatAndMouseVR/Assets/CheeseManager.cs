using System;
using UnityEngine;

public class CheeseManager : MonoBehaviour
{
    public bool CheeseActive = false;
    public float CheeseTime = 45f;
    private float CheeseReset;


    [SerializeField]
    GameObject cheesePrefab;

    GameObject[] CheeseSpawns;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CheeseSpawns = GameObject.FindGameObjectsWithTag("CheeseSpawnPoint");
        CheeseReset = CheeseTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (CheeseActive)
        {
            CheeseTime -= Time.deltaTime;

            if (CheeseTime < 0)
            {
                SpawnCheese();
            }
        }
    }

    public void SpawnCheese()
    {
        int num = UnityEngine.Random.Range(0, CheeseSpawns.Length-1);
        GameObject go = GameObject.Instantiate(cheesePrefab);
        go.transform.position = CheeseSpawns[num].transform.position;
        CheeseTime = CheeseReset;
        CheeseActive = true;
    }
}
