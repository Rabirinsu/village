using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSkillExplosion : MonoBehaviour
{
    [SerializeField] private FireBall fireball;
    [SerializeField] private ParticleSystem FireExplosion;
    public static bool isDamaged; 
    private float damage; // get damage from fireball
    private void Awake()
    {
        damage = fireball.damage;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            Instantiate(FireExplosion, collision.gameObject.transform.position, Quaternion.identity);
            collision.gameObject.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
          
          
        }
        else if (!collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject); Debug.Log("HITTED " + collision.gameObject.name);
        }
            
    }


   
}
