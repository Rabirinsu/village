using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character/States/Attack")]

public class AttackS : CharState
{
    public override bool ExitState(CharStateController PlayerStateController)
    {
        if(!PlayerStateController.animator.GetCurrentAnimatorStateInfo(0).IsName("IceAttack") && !PlayerStateController.animator.GetCurrentAnimatorStateInfo(0).IsName("FireAttack"))        // (!(PlayerStateController.animator.GetCurrentAnimatorStateInfo(0).IsName("IceAttack") || PlayerStateController.animator.GetCurrentAnimatorStateInfo(0).IsName("FireAttack")))
            return true;
        return false;
    }
    public override void ExecuteState(CharStateController PlayerStateController) 
    {
        PlayerStateController.animator.SetBool("Walk", false);
        PlayerStateController.animator.SetBool("Idle", false);
        Debug.Log("ICE SKILL ATTACKING");
    }
    public override bool CheckRules(CharStateController PlayerStateController)
    {
        if (PlayerStateController.animator.GetCurrentAnimatorStateInfo(0).IsName("IceAttack") || PlayerStateController.animator.GetCurrentAnimatorStateInfo(0).IsName("FireAttack"))
            return true;

         else   return false;
    }
}
