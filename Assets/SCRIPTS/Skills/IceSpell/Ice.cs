using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Spells/Ice")]
public class Ice : Spell
{

    private IceCaster IceCast;
     public GameObject IceSpellObject;

     
   
    public override void Initialize(GameObject weapon)
    {
        
        IceCast = weapon.GetComponent<IceCaster>();
      
        IceCast.Damage = damage;
        IceCast.IceObject = IceSpellObject;
        IceCast.spellDurationTime = spellDuration;
        IceCast.spellDelay = DelayTime;


    }
    public override void TriggerSpell()
    {
        IceCast.LaunchIce();
      
    }
}
