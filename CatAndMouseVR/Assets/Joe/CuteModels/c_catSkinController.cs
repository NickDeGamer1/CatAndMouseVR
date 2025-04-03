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
    Material[] outlineMat;
    
    [SerializeField]
    GameObject headObj;
    [SerializeField]
    GameObject bodyObj;
    [SerializeField]
    GameObject collarObj;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetSkin(catSkin);
    }

    // Update is called once per frame
    public void SetSkin(int skinNum)
    {
        headObj.GetComponent<SkinnedMeshRenderer>().materials = new Material[] {headMat[skinNum], outlineMat[skinNum]};
        collarObj.GetComponent<SkinnedMeshRenderer>().materials = new Material[] {collarMat[skinNum], outlineMat[skinNum]};
        bodyObj.GetComponent<SkinnedMeshRenderer>().materials = new Material[] {bodyMat[skinNum], outlineMat[skinNum]};
    }
}
