using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceAction : MonoBehaviour
{
    [SerializeField] private Ice IceSpell;
    private float damage;

    private void Awake()
    {
        damage = IceSpell.damage;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Monster"))
        {
            other.gameObject.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
        }
    }
  
}
