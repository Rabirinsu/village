using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class MonsterHealth : MonoBehaviour
{

    public MeleeMonster monster;
    public Image healthBar;
    public Canvas monsterCanvas;
    [HideInInspector]public float maxHealth;
    [HideInInspector] public float currentHealth;
    public  bool isDead;


    private void OnEnable()
    {
        isDead = false;
        maxHealth = monster.HealthBonus;
        currentHealth = maxHealth;
        SetHealthUI();
    }
    public void TakeDamage(float damageAmount)
    {
        // TODO Call takedamage anim, sound 
        currentHealth -= damageAmount;
        SetHealthUI();
        if (currentHealth <= 0)
        {
            isDead = true;
            monsterCanvas.enabled = false;
            GetComponent<NavMeshAgent>().enabled = false;
        }
           
      
    }
  
    private void SetHealthUI()
    {
        healthBar.fillAmount = currentHealth / maxHealth;
    }
  


}
