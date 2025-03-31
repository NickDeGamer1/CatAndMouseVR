using UnityEngine;

public class c_catSkinController : MonoBehaviour
{
    public int catSkin = 0;

    [SerializeField]
    Material[] headMat;
    [SerializeField]
    Material[] bodyMat;
    [SerializeField]
    Material[] collarMat;
    
    [SerializeField]
    GameObject headObj;
    [SerializeField]
    GameObject bodyObj;
    [SerializeField]
    GameObject collarObj;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        headObj.GetComponent<SkinnedMeshRenderer>().material =  headMat[catSkin];
        collarObj.GetComponent<SkinnedMeshRenderer>().material =  collarMat[catSkin];
        bodyObj.GetComponent<SkinnedMeshRenderer>().material =  bodyMat[catSkin];
        //headObj.GetComponent<Renderer>().material[1] =  outlineMat[catSkin];



        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
