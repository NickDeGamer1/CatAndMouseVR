using UnityEngine;
using UnityEngine.InputSystem;

public class c_ctSt_Landed : c_ctSt_Class
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void EnterState(c_CatController player)
    {
       player.anim.SetBool("hasLanded", true);
       player.hasJumped = false;
    }

    // Update is called once per frame
    public override void UpdateState(c_CatController player)
    {
        //Water we doing?
        Debug.Log("landed");

        //When do we gtfo?
        if (player.hasJumped == true)
        {
            
            //change anim
            player.anim.SetTrigger("gettingUp");
            //remove has jumped
            player.hasJumped = false;
            //switch to anim
            player.SwitchState(player.gettingUpState);
        }
           
    }

}
