using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Monster/States/Damaged")]
public class Damaged : State
{
    public override bool ExitState(StateController monsterController)
    {
       
        if (!monsterController.isDamaged)
        {
            monsterController.animator.SetBool("Damaged", false);
            monsterController.animator.SetBool("Attack", false);
            return true;
        }
   
      else  return false;
    }
    public override void ExecuteState(StateController monsterController) 
    {

        monsterController.animator.SetBool("Damaged", true);
        monsterController.animator.SetBool("Attack", false);
        monsterController.animator.SetBool("Walk", false);
    }
    public override bool CheckRules(StateController monsterController)
    {
     
        if (!monsterController.monsterHP.isDead && monsterController.isDamaged)
        {
            return true;
        }   
     else   return false;   
    }
   
}
