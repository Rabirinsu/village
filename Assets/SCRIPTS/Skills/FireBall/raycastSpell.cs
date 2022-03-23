using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycastSpell : MonoBehaviour
{

    [HideInInspector] public GameObject fireBallObject;
    [HideInInspector] public int Damage;
    [HideInInspector] public float skillshotspeed;
    [HideInInspector] public int spellRange;
    [HideInInspector] public ParticleSystem hitFX;
    [HideInInspector] public AudioClip hitSound;
    [HideInInspector]public float spellDurationTime;
    public Transform fireballspawnPosition;
    private float spellShotYposition = -100;
   


    public void LaunchFireBall()
    {
        var spellcopy =  Instantiate(fireBallObject, fireballspawnPosition.position, Quaternion.Euler(-90,0,0)); 
        Debug.Log("POS ! " + fireballspawnPosition.position);
        
       spellcopy.GetComponent<Rigidbody>().velocity = fireballspawnPosition.rotation * new Vector3(0, spellShotYposition, fireballspawnPosition.position.y) * skillshotspeed;
       
          StartCoroutine(DestroyInTime(spellcopy));
    }
    public IEnumerator DestroyInTime(GameObject fireballClone)
    {
        yield return new WaitForSeconds(spellDurationTime);
       DestroyImmediate(fireballClone);
    }


}
