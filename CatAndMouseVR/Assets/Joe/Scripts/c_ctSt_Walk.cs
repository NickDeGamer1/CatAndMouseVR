using UnityEngine;
using UnityEngine.InputSystem;

public class c_ctSt_Walk : c_ctSt_Class
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void EnterState(c_CatController player)
    {
        
    }

    // Update is called once per frame
    public override void UpdateState(c_CatController player)
    {
        //Water we doing?
        player.Move();
        player.EnsureGrounded();

        //When do we gtfo?
        Debug.Log("walking");

        //walk when we walk
        if ((player.SENSI > player.movementInput.magnitude) || ((-1 * player.SENSI) < player.movementInput.magnitude))
        {
            player.SwitchState(player.idleState);
        }

        //pounce when we pounce
        if (player.hasJumped == true)
        {
            player.SwitchState(player.jumpState);
        }
           
    }

}
