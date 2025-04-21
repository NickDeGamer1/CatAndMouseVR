using UnityEngine;
using UnityEngine.InputSystem;

public class c_ctSt_Idle : c_ctSt_Class
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void EnterState(c_CatController player)
    {

    }

    // Update is called once per frame
    public override void UpdateState(c_CatController player)
    {
        //Water we doing?
        //Debug.Log("idling");
        player.EnsureGrounded();

        //Move when we move
        if ((player.SENSI < player.movementInput.magnitude) || ((-1 * player.SENSI) > player.movementInput.magnitude))
        {
            player.SwitchState(player.walkState);
        }

        //pounce when we pounce.
        if (player.hasJumped == true)
        {
            if (player.canJump)
            {
                player.SwitchState(player.jumpState);
            }else{
                player.hasJumped = false;
            }
        }
           
        }

}
