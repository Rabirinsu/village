using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class MonsterSpawner : MonoBehaviour
{

    [HideInInspector] public Vector3 destinationPoint;
    [HideInInspector] public Vector3 spawnPoint;
    [HideInInspector] public NavMeshAgent agent;
    [SerializeField] private MonsterList monsterList;
     public List<NavMeshAgent> AgentClones;
    public List<MonsterType> Monsters;
    [SerializeField] private GameObject player;
    [SerializeField] private LevelManager levelManager;



    private void OnEnable()
    {
        GetMonsters();
        spawnMonster();

    }
    private void GetMonsters()
    {
        switch (levelManager.level)
        {
            case 1:
                for (var i = 0; i < 3; i++)
                    Monsters.Add(monsterList.Monsters[0]);
                break;
            case 2:
                for (var i = 0; i < 4; i++)
                {
                    Monsters.Add(monsterList.Monsters[0]);
                    Monsters.Add(monsterList.Monsters[1]);
                }
                   
                break;
            case 3:
                for (var i = 0; i < 5; i++)
                {
                    Monsters.Add(monsterList.Monsters[0]);
                    Monsters.Add(monsterList.Monsters[1]);
                }
                  
                break;
            case 4:
                for (var i = 0; i < 5; i++)
                {
                    Monsters.Add(monsterList.Monsters[0]);
                    Monsters.Add(monsterList.Monsters[1]);
                    Monsters.Add(monsterList.Monsters[2]);
                }
                  
                break;
            case 5:
                for (var i = 0; i < 3; i++)
                {
                    Monsters.Add(monsterList.Monsters[3]);
                }
                 
                break;
            case 6:
                for (var i = 0; i < 2; i++)
                {
                    Monsters.Add(monsterList.Monsters[4]);
                }

                break;
            case 7:
                for (var i = 0; i < 3; i++)
                {
                    Monsters.Add(monsterList.Monsters[0]);
                    Monsters.Add(monsterList.Monsters[4]);
                }

                break;
            case 8:
                for (var i = 0; i < 4; i++)
                {
                    Monsters.Add(monsterList.Monsters[2]);
                    Monsters.Add(monsterList.Monsters[4]);
                }

                break;
            case 9:
                for (var i = 0; i < 3; i++)
                {
                    Monsters.Add(monsterList.Monsters[0]);
                    Monsters.Add(monsterList.Monsters[1]);
                    Monsters.Add(monsterList.Monsters[3]);
                    Monsters.Add(monsterList.Monsters[4]);
                }

                break;
            case 10:
                for (var i = 0; i < 7; i++)
                {
                    Monsters.Add(monsterList.Monsters[0]);
                    Monsters.Add(monsterList.Monsters[1]);
                    Monsters.Add(monsterList.Monsters[2]);
                    Monsters.Add(monsterList.Monsters[3]);
                    Monsters.Add(monsterList.Monsters[4]);
                }
                break;
            case 11:
                for (var i = 0; i < 15; i++)
                {
                    Monsters.Add(monsterList.Monsters[0]);
                    Monsters.Add(monsterList.Monsters[1]);
                  
                }
                break;
            case 12:
                for (var i = 0; i < 9; i++)
                {
                    Monsters.Add(monsterList.Monsters[0]);
                    Monsters.Add(monsterList.Monsters[1]);
                    Monsters.Add(monsterList.Monsters[2]);
                  
                }
                break;
            case 13:
                for (var i = 0; i < 25; i++)
                {
                    Monsters.Add(monsterList.Monsters[0]);
                    Monsters.Add(monsterList.Monsters[1]);
                    Monsters.Add(monsterList.Monsters[2]);
                    Monsters.Add(monsterList.Monsters[3]);
                   
                }
                break;
            case 14:
                for (var i = 0; i < 15; i++)
                {
                    Monsters.Add(monsterList.Monsters[0]);
                    Monsters.Add(monsterList.Monsters[1]);
                    Monsters.Add(monsterList.Monsters[2]);
                 
                    Monsters.Add(monsterList.Monsters[4]);
                }
                break;
            case 15:
                for (var i = 0; i < 35; i++)
                {
                    Monsters.Add(monsterList.Monsters[0]);
                    Monsters.Add(monsterList.Monsters[4]);
                }


                break;
        }



    }
    public void spawnMonster()
    {

        foreach (var monster in Monsters)
        {

            spawnPoint = new Vector3(Random.Range(monster.spawnPointX1, monster.spawnPointX2), monster.spawnPointY, Random.Range(monster.spawnPointZ1, monster.spawnPointZ2));
            destinationPoint = new Vector3(Random.Range(monster.destinationPointX1, monster.destinationPointX2), monster.spawnPointY, Random.Range(monster.destinationPointZ1, monster.destinationPointZ2));
            agent = monster.agent;
            var monsterClone = Instantiate(agent, spawnPoint, Quaternion.Euler(0, 180, 0), transform);
            monsterClone.destination = destinationPoint;
            AgentClones.Add(monsterClone);

        }
    }
 
  
}
