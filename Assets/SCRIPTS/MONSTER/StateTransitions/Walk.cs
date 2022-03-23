using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[CreateAssetMenu(menuName = "Monster/States/Walk")]
public class Walk : State
{ 
    public override bool ExitState(StateController monsterController)
    {
        var layerMask = 1 << 7;
        if (monsterController.animator.GetCurrentAnimatorStateInfo(0).IsName("Attack01") || monsterController.isDamaged || monsterController.monsterHP.isDead || Physics.SphereCast(monsterController.monsterEyes.position, monsterController.monster.sphereRadius, Vector3.back, out var hit, monsterController.monster.atakRange, layerMask, QueryTriggerInteraction.UseGlobal))
            return true;
        else return false;
    }
    public override void ExecuteState(StateController monsterController)
    {
        monsterController.animator.SetBool("Walk", true);
    }
    public override bool CheckRules(StateController monsterController)
    {
        if (!monsterController.animator.GetCurrentAnimatorStateInfo(0).IsName("Attack01") && !monsterController.isDamaged && !monsterController.monsterHP.isDead)
        {
            Debug.Log("IM WALKING ");
            return true;
        }
      
        else return false;
    }
}
