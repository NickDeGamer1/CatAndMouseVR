using UnityEngine;
using UnityEngine.InputSystem;

public class c_ctSt_Start : c_ctSt_Class
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void EnterState(c_CatController player)
    {

    }

    // Update is called once per frame
    public override void UpdateState(c_CatController player)
    {
        player.EnsureGrounded();
    }

}
