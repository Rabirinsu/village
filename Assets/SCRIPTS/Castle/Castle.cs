using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Castle")]
public  class Castle : ScriptableObject
{
  
    public int HealthBonus;
    public int healthPerLevel;
    public Vector3 spawnPoint;
    public GameObject CastleGameObject;
}
