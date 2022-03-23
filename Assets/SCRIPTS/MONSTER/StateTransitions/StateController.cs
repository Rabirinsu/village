using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class StateController : MonoBehaviour
{
    [HideInInspector] public MonsterSpawner monsterSpawner;
    public MeleeMonster monster;
    public State currentState;
    public Transform monsterEyes;   
    private float timer;

    public LevelManager levelManager;
    [HideInInspector]public MonsterHealth monsterHP;
    [HideInInspector] public NavMeshAgent MonsterAgent;
    [HideInInspector] public Vector3 destinationPoint;
    [HideInInspector] public int health;
    [HideInInspector] public Animator animator;
 
    public CoinsManager coinManager;
 
    public bool isDamaged;
    [HideInInspector] public bool isDead;
    [HideInInspector] public GameObject CastleGameObject;
    [HideInInspector] public GameObject monsterGameObject;
    [HideInInspector] public float deathDelay;
    [HideInInspector] public int coinAmount;
    [HideInInspector] public int perCoin;
    private TextMeshProUGUI TotalCoinTxt;
    public GameObject player;
    private void Awake()
    {

        TotalCoinTxt = GameObject.Find("AmountTxt").GetComponent<TextMeshProUGUI>();
        player = GameObject.Find("Mage");
        Initialize();
    }
    public void Initialize()
    {

        monsterSpawner = GameObject.Find("MonsterSpawner").GetComponent<MonsterSpawner>();
        TotalCoinTxt.text = levelManager.TotalCoins.ToString();
        isDead = false;
        perCoin = monster.perCoin;
        coinManager = GameObject.Find("CoinsManager").GetComponent<CoinsManager>();
        coinAmount = monster.coinAmount;
        deathDelay = monster.deathDelay;
        animator = GetComponent<Animator>();
        MonsterAgent = monster.agent;
        MonsterAgent.speed = monster.speed;
        monsterHP = GetComponent<MonsterHealth>();
        monsterGameObject = gameObject;
    }
    public void UpdateState()
    {
        
        foreach (var state in currentState.transitions) // Check every state transitions rules
        {
         
            if (state.CheckRules(this))
                currentState = state;
        }
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if ( currentState.ExitState(this))
        {
            UpdateState();
            Debug.Log("Monster Update State");
        }

        currentState.ExecuteState(this);
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FireBall"))
        {
            StartCoroutine(nameof(DoActions));
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ice"))
        {
            StartCoroutine(nameof(DoActions));
        }
    }
    private IEnumerator DoActions()
    {
        Debug.Log("IM DAMAGED FCK ");
        isDamaged = true;
        yield return new WaitForSeconds(monster.takeDamageTime);
        isDamaged = false;
    }




    public void StartCoins()
    {
        StartCoroutine(nameof(callCoins));
    }

    IEnumerator callCoins()
    {
        isDead = true;
        for (var i = 0; i < coinAmount; i++)
        {
         
            yield return new WaitForSeconds(.05f);
            coinManager.StartCoinMove(player.transform.position, () =>
            {
                levelManager.TotalCoins += perCoin;
                TotalCoinTxt.text = levelManager.TotalCoins.ToString();
            });
        } StartCoroutine(nameof(callDeath));
    }
    IEnumerator callDeath()
    {
        yield return new WaitForSeconds(monster.deathDelay);
        monsterSpawner.Monsters.Remove(monster);
        Destroy(gameObject);
    }
}
