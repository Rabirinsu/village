using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    [SerializeField] private  ParticleSystem HitDamageFX;
    private StateController monsterController;

    private void Awake()
    {
        monsterController = GetComponent<StateController>();
    }
    public void HitDamage()
    {
      
            monsterController.CastleGameObject.SendMessage("CastleTakeDamage", monsterController.monster.Damage, SendMessageOptions.DontRequireReceiver);   // Hit damage sawed gameObject.
          Instantiate(HitDamageFX, monsterController.monsterEyes.position, Quaternion.identity);
    }
}
