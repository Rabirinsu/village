using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LevelManager")]
public class LevelManager : ScriptableObject
{

    public int level;
    public int TotalCoins;
    public int coinRewardAmount;
    public int RewardPerCoin;
    public int LevelRewardAmount;
    public int LevelRewardPerCoin;


}
