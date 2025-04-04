using UnityEngine;
using UnityEngine.InputSystem;

public class c_ctSt_Jump : c_ctSt_Class
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void EnterState(c_CatController player)
    {
        //Do initial jump action
       player.JumpStart();
       //set is pounce
       player.anim.SetBool("isPouncing", true);
    }

    // Update is called once per frame
    public override void UpdateState(c_CatController player)
    {
        //Water we doing?
        Debug.Log("jumping");

        //If we're on the ground
        if (player.controller.isGrounded){
            //stop all velocity
            player.playerVelocity.z = 0f;
            player.playerVelocity.x = 0f;
            //turn off pouncing
            player.anim.SetBool("isPouncing", false);
            //switch to landed state
            player.SwitchState(player.landedState);
        }

        //When do we gtfo?
           
    }

}
