using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private Spell FireSpell;
    [SerializeField] private Spell IceSpell;
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private GameObject fireUpgradeButton;
    [SerializeField] private GameObject IceUpgradeButton;
    [SerializeField] private TextMeshProUGUI TotalCoinTxt;
    private void Update()
    {
        if (FireSpell.UpgradePrice <= levelManager.TotalCoins)
        {
            fireUpgradeButton.SetActive(true);
        }
        else fireUpgradeButton.SetActive(false);

         if(IceSpell.UpgradePrice <= levelManager.TotalCoins)
        {
            IceUpgradeButton.SetActive(true);
        }
        else IceUpgradeButton.SetActive(false);
    }

    public void UpgradeFireSkill()
    {
        FireSpell.damage += Mathf.RoundToInt(FireSpell.damage * FireSpell.damageMultiply);
        levelManager.TotalCoins -= Mathf.RoundToInt(FireSpell.UpgradePrice);
        FireSpell.UpgradePrice *= FireSpell.priceMultiply;
   
        UpdateUI();
    }
    public void UpgradeIceSkill()
    {
        IceSpell.damage += Mathf.RoundToInt(IceSpell.damage * IceSpell.damageMultiply);
        levelManager.TotalCoins -= Mathf.RoundToInt(IceSpell.UpgradePrice);
        IceSpell.UpgradePrice *= IceSpell.priceMultiply;
     //   AndroidManager.HapticFeedback();
        UpdateUI();

    }
    public void UpdateUI()
    {
        TotalCoinTxt.text = levelManager.TotalCoins.ToString();
    }
}
