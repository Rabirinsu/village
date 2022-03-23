using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character/States/Idle")]

public class IdleS : CharState
{
    public override bool ExitState(CharStateController PlayerStateController)
    {
        if (Input.touchCount > 0 || (PlayerStateController.animator.GetCurrentAnimatorStateInfo(0).IsName("IceAttack") || PlayerStateController.animator.GetCurrentAnimatorStateInfo(0).IsName("FireAttack")))
        {
            return true;
        }
     else   return false;
    }
    public override void ExecuteState(CharStateController PlayerStateController)
    {
        PlayerStateController.animator.SetBool("Walk", false);
        PlayerStateController.animator.SetBool("Idle", true);
       


    }
    public override bool CheckRules(CharStateController PlayerStateController)
    {
        if ( Input.touchCount <= 0 || (PlayerStateController.animator.GetCurrentAnimatorStateInfo(0).IsName("Idle01")))
            return true;

        else    return false;   
    }
}
