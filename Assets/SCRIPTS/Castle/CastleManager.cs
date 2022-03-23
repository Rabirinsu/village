using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleManager : MonoBehaviour
{
    public Castle castle;
    [HideInInspector] public GameObject castleObject;
    [HideInInspector] public Vector3 spawnLocation;
    void Start()
    {
        castleObject = castle.CastleGameObject;
        spawnLocation = castle.spawnPoint;
       Instantiate(castleObject, spawnLocation, Quaternion.Euler(-90,0,0));
    }
}
