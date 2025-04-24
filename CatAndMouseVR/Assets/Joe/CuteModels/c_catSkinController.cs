using UnityEngine;
using UnityEngine.InputSystem;

public class c_catSkinController : MonoBehaviour
{
    public int catSkin = 1;

    [Header("Cute Materials")]
    [SerializeField]
    Material[] headMat;
    [SerializeField]
    Material[] bodyMat;
    [SerializeField]
    Material[] collarMat;
    [SerializeField]
    Material[] outlineMat;

    [Header("Creepy Materials")]
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
    
    [Header("Cute Cat Objs")]
    //cute cat
    [SerializeField]
    GameObject cuteHeadObj;
    [SerializeField]
    GameObject cuteBodyObj;
    [SerializeField]
    GameObject cuteCollarObj;

    [Header("Creepy Cat Objs")]
    //creepy cat
    [SerializeField]
    GameObject creepyHeadObj;
    [SerializeField]
    GameObject creepyBodyObj;
    [SerializeField]
    GameObject creepyCollarObj;

    [Header("Misc.")]
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
        skinNum--;

        cuteHeadObj.GetComponent<SkinnedMeshRenderer>().materials = new Material[] {headMat[skinNum], outlineMat[skinNum]};
        cuteCollarObj.GetComponent<SkinnedMeshRenderer>().materials = new Material[] {collarMat[skinNum], outlineMat[skinNum]};
        cuteBodyObj.GetComponent<SkinnedMeshRenderer>().materials = new Material[] {bodyMat[skinNum], outlineMat[skinNum]};

        creepyHeadObj.GetComponent<SkinnedMeshRenderer>().materials = new Material[] {creepyHeadMat[skinNum], creepyTeethMat, creepyEyeMat[skinNum]};
        creepyCollarObj.GetComponent<SkinnedMeshRenderer>().materials = new Material[] {creepyCollarMat[skinNum]};
        creepyBodyObj.GetComponent<SkinnedMeshRenderer>().materials = new Material[] {creepyBodyMat[skinNum]};
    }
}
