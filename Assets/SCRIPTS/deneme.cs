using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
// THIS SCRIPT MANAGED REWARDED ADD COINS  
public class deneme : MonoBehaviour
{
    public CoinsManager coinManager;
    public GameObject player;
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private TextMeshProUGUI TotalCoinTxt; 

    void Start()
    {
        player = GameObject.Find("Mage");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadCoins()
    {
        StartCoroutine(nameof(callCoins));
    }

    IEnumerator callCoins()
    {

        for (var i = 0; i < levelManager.coinRewardAmount ; i++)
        {
            yield return new WaitForSeconds(.05f);
            coinManager.StartCoinMove(player.transform.position, () =>
            {
                levelManager.TotalCoins += levelManager.RewardPerCoin;
                TotalCoinTxt.text = levelManager.TotalCoins.ToString();
            });
        }
    }

  
}
