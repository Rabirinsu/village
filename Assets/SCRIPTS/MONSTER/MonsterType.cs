
using UnityEngine;
using UnityEngine.AI;



public abstract class MonsterType : ScriptableObject
{
    // Monster Stats
    public string Name;
    public string Description;
    public float speed;
    public float atakRange;
    public float atakTime;
    public float takeDamageTime;
    public float sphereRadius; 
    public float deathDelay;
    public NavMeshAgent agent;
    public int HealthBonus;
    public int Damage;
    public int coinAmount;
    public int perCoin;

    // Monster Spawn points 
    public float spawnPointX1;
    public float spawnPointX2;
    public float spawnPointY;
    public float spawnPointZ1;
    public float spawnPointZ2;

    // Monster Destination Points
    public float destinationPointX1;
    public float destinationPointX2;
    public float destinationPointY;
    public float destinationPointZ1;
    public float destinationPointZ2;


    public abstract void Initialize();

}
