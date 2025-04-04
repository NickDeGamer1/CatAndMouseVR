using UnityEngine;
using UnityEngine.InputSystem;

public class c_ctSt_GettingUp : c_ctSt_Class
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void EnterState(c_CatController player)
    {
       player.anim.SetBool("hasLanded", true);
       player.hasJumped = false;
       //jump
        player.playerVelocity.y += Mathf.Sqrt(0.5f * -2.0f * player.gravityValue);
    }

    // Update is called once per frame
    public override void UpdateState(c_CatController player)
    {
        //Water we doing?
        Debug.Log("gettingUp");

        //When do we gtfo?
        //If play the idle animation then we done
        if (!player.anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            //reset trigger
            //player.anim.ResetTrigger("gettingUp");
            //prevent jumping again
            player.hasJumped = false;
            //revert to idle
            player.SwitchState(player.idleState);
        }
           
    }

}
