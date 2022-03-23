using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;


[CreateAssetMenu(menuName = "Monster/States/Death")]
public class Death : State
{ 
    public override bool ExitState(StateController monsterController)
    {

        return false;
    }
    public override void ExecuteState(StateController monsterController)
    { 
        monsterController.animator.SetBool("Death", true);
      //  Destroy(monsterController.monsterGameObject.GetComponent<NavMeshAgent>());
        Destroy(monsterController.monsterGameObject.GetComponent<SphereCollider>());
        if (monsterController.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > monsterController.deathDelay)
        {
            if (!monsterController.isDead)
            {
                monsterController.StartCoins();
            }
           
       
        }
            
        }
    public override bool CheckRules(StateController monsterController)
    {
        if (monsterController.monsterHP.isDead)
            return true;
        else return false;
    }
}
