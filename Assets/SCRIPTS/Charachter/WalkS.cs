using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character/States/Walk")]

public class WalkS : CharState
{
    public override bool ExitState(CharStateController PlayerStateController)
    {
        if ( Input.touchCount <= 0 || (PlayerStateController.animator.GetCurrentAnimatorStateInfo(0).IsName("IceAttack") || PlayerStateController.animator.GetCurrentAnimatorStateInfo(0).IsName("FireAttack")))
        {
            PlayerStateController.animator.SetBool("Walk", false);
            return true;
        }
        else return false;
    }
    public override void ExecuteState(CharStateController PlayerStateController) 
    {
        PlayerStateController.animator.SetBool("Idle", false);
        PlayerStateController.animator.SetBool("Walk", true);
    }
    public override bool CheckRules(CharStateController PlayerStateController)
    {
        if (Input.touchCount > 0 && PlayerStateController.CharController.isMove && (!PlayerStateController.animator.GetCurrentAnimatorStateInfo(0).IsName("IceAttack") || !PlayerStateController.animator.GetCurrentAnimatorStateInfo(0).IsName("FireAttack")))
        {
            return true;
        }
         
       else return false;
    }
}
