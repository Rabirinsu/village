using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Spells/FireBall")]
public class FireBall : Spell
{
   
    public GameObject fireBallObject;
    private raycastSpell rayspell;
   
    public override void Initialize(GameObject weapon)
    {
        rayspell = weapon.GetComponent<raycastSpell>();
        rayspell.Damage = damage; 
        rayspell.spellRange = spellRange;
        rayspell.fireBallObject = fireBallObject;
        rayspell.skillshotspeed = skillshotSpeed;
        rayspell.spellDurationTime = spellDuration;

    }
    public override void TriggerSpell()
    {
        rayspell.LaunchFireBall(); // call fireball
      
    }
}
