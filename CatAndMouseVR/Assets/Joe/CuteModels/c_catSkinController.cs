using UnityEngine;
using UnityEngine.InputSystem;

public class c_catSkinController : MonoBehaviour
{
    public int catSkin = 1;

    [SerializeField]
    Material[] headMat;
    [SerializeField]
    Material[] bodyMat;
    [SerializeField]
    Material[] collarMat;
    [SerializeField]
    Material[] outlineMat;

    [SerializeField]
    Material[] creepyHeadMat;
    [SerializeField]
    Material[] creepyEyeMat;
    [SerializeField]
    Material[] creepyBodyMat;
    [SerializeField]
    Material[] creepyCollarMat;
    [SerializeField]
    Material creepyTeethMat;
    
    //cute cat
    [SerializeField]
    GameObject cuteHeadObj;
    [SerializeField]
    GameObject cuteBodyObj;
    [SerializeField]
    GameObject cuteCollarObj;

    //creepy cat
    [SerializeField]
    GameObject creepyHeadObj;
    [SerializeField]
    GameObject creepyBodyObj;
    [SerializeField]
    GameObject creepyCollarObj;

    [SerializeField]
    public PlayerInput playaInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetSkin(playaInput.playerIndex);
    }

    // Update is called once per frame
    public void SetSkin(int skinNum)
    {
        cuteHeadObj.GetComponent<SkinnedMeshRenderer>().materials = new Material[] {headMat[skinNum-1], outlineMat[skinNum-1]};
        cuteCollarObj.GetComponent<SkinnedMeshRenderer>().materials = new Material[] {collarMat[skinNum-1], outlineMat[skinNum-1]};
        cuteBodyObj.GetComponent<SkinnedMeshRenderer>().materials = new Material[] {bodyMat[skinNum-1], outlineMat[skinNum-1]};

        creepyHeadObj.GetComponent<SkinnedMeshRenderer>().materials = new Material[] {creepyHeadMat[skinNum-1], creepyTeethMat, creepyEyeMat[skinNum-1]};
        creepyCollarObj.GetComponent<SkinnedMeshRenderer>().materials = new Material[] {creepyCollarMat[skinNum-1]};
        creepyBodyObj.GetComponent<SkinnedMeshRenderer>().materials = new Material[] {creepyBodyMat[skinNum-1]};
    }
}
