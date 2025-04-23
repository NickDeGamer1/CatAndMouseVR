using UnityEngine;

public class AmbinetNoise : MonoBehaviour
{
    public bool active = false;

    [SerializeField]
    AudioSource[] sources;
    float rand;

    [SerializeField]
    AudioClip[] clips;

    private void Start()
    {
        SetRand();
    }

    private void Update()
    {
        if (active)
        {
            rand -= Time.deltaTime;
            if (rand < 0)
            {
                Debug.Log(true);
                int r1 = Random.Range(0, sources.Length - 1);
                int r2 = Random.Range(0, clips.Length - 1);
                float rx = Random.Range(-1f, 1f);
                float ry = Random.Range(0f, 2f);
                float rz = Random.Range(-1f, 1f);
                Vector3 v3 = new Vector3(rx, ry, rz);
                sources[r1].gameObject.transform.localPosition = v3;
                sources[r1].resource = clips[r2];
                sources[r1].Play();
                SetRand();
            }
        }
    }

    void SetRand()
    {
        rand = (float)Random.Range(45f, 75f);
    }
}
