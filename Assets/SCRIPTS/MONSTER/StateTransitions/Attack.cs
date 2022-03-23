using System.Collections;
using UnityEngine;
using UnityEngine.AI;
[CreateAssetMenu(menuName = "Monster/States/Attack")]
public class Attack : State
{
  
 
    private void Awake()
    {
      
    }
    public override bool ExitState(StateController monsterController)
    {
        if (monsterController.isDamaged || monsterController.monsterHP.isDead)
        {
            monsterController.animator.SetBool("Attack", false);
            return true;
        }
        
        return false;
       
    }
    public override void ExecuteState(StateController monsterController) 
    {
        monsterController.animator.SetBool("Attack", true);
        monsterController.monsterGameObject.GetComponent<NavMeshAgent>().enabled = false;      
    }
    public override bool CheckRules(StateController monsterController) 
    {
     
         var layerMask = 1 << 7;
         Debug.DrawRay(monsterController.monsterEyes.position, Vector3.back * monsterController.monster.sphereRadius, Color.green);

        if (Physics.SphereCast(monsterController.monsterEyes.position, monsterController.monster.sphereRadius, Vector3.back, out var hit, monsterController.monster.atakRange, layerMask, QueryTriggerInteraction.UseGlobal)
           && !monsterController.isDamaged && !monsterController.monsterHP.isDead )
        {
            monsterController.CastleGameObject = hit.transform.gameObject; // Get name of monster hitted object. 
            Debug.Log("IM CASTLE and see " + hit.transform.name);
            return true;
        } 
        else return false;          
    }
}
