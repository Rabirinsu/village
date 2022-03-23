using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell : ScriptableObject
{
    public  string spellName = "New Ability";
    public Sprite spellSprite;
    public AudioClip spellPrepareSound;
    public AudioClip spellSound;
    public float spellCoolDown = 1f;
    public int spellRange;
    public float skillshotSpeed;
    public float spellDuration;
    public float DelayTime;
    public string animationName;
    public ParticleSystem spellFX;
    public int damage;
    public float damageMultiply;
    public float UpgradePrice;
    public float priceMultiply;
    public abstract void Initialize(GameObject weapon);
   public abstract void TriggerSpell();
}
