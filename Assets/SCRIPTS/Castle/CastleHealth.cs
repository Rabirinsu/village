using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastleHealth : MonoBehaviour
{
    public Castle castle;
    public Image healthBar;
    [SerializeField] private MainLevelManager mainLevelManager;
    [HideInInspector] public float maxHealth;
    public float castleCurrentHealth;
    [HideInInspector] public bool isDead;

    private void OnEnable()
    {
        mainLevelManager = GameObject.Find("LevelManager").GetComponent<MainLevelManager>(); // get levelmanager
        isDead = false;
        maxHealth = castle.HealthBonus;
        castleCurrentHealth = maxHealth;
        SetHealthUI();
    }
    public void CastleTakeDamage(float damageAmount)
    {
        // TODO Call takedamage anim, sound 
        castleCurrentHealth -= damageAmount;
        Debug.Log("Castle Health " + castleCurrentHealth);
        SetHealthUI();
        if (castleCurrentHealth <= 0)
        {
            isDead = true;
            gameObject.SetActive(false);
            mainLevelManager.LevelFailed(); // level failed things when castle destroyed
        }
            

    }
    private void SetHealthUI()
    {
        healthBar.fillAmount = castleCurrentHealth / maxHealth;
    }

}
