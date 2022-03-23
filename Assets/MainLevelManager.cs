using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using  TMPro;

public class MainLevelManager : MonoBehaviour
{
    [SerializeField] private AudioClip succesClip;
    [SerializeField] private AudioClip failClip;
   private AudioSource audioSource;
    [SerializeField] private GameObject Monsters;
    [SerializeField] private GameObject Mage;
    private MonsterSpawner monsterSpawner;
    public LevelManager levelManager;
    public CastleHealth castleHealth;
    public GameObject levelSuccesUI;
    public GameObject levelFailedUI;
    [SerializeField] private TextMeshProUGUI coinRewardText;
    [SerializeField] private Castle castle;
    [SerializeField] private CoinsManager coinManager;
    [SerializeField] private TextMeshProUGUI TotalCoinTxt;
    [SerializeField] private TextMeshProUGUI LevelTxt;
    public static bool isLevelEnd;

   
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        LevelTxt.text = "Level " + levelManager.level.ToString();
        coinRewardText.text = (levelManager.RewardPerCoin * levelManager.coinRewardAmount).ToString();
        isLevelEnd = false;
        levelSuccesUI.SetActive(false);
        levelFailedUI.SetActive(false);
        monsterSpawner = Monsters.GetComponent<MonsterSpawner>();
    }
    private void Update()
    {
     
        if (!isLevelEnd)
        StartCoroutine(nameof(LevelSucces));
    }
    public void LevelFailed()
    {
        if (!isLevelEnd)
        {
            audioSource.PlayOneShot(failClip, 2);
            levelFailedUI.SetActive(true);
            Monsters.SetActive(false);
            Debug.Log("LEVEL FAILED");
            isLevelEnd = true;
            Mage.GetComponent<CharachterController>().enabled = false;
        }
    }
   IEnumerator LevelSucces()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("castle hp " + castleHealth.castleCurrentHealth);
        if (!isLevelEnd && monsterSpawner.Monsters.Count == 0)
        {
            audioSource.PlayOneShot(succesClip, 2);
            levelSuccesUI.SetActive(true);
            Monsters.SetActive(false);
            Debug.Log(" LEVEL SUCCESS ");
            castle.HealthBonus += castle.healthPerLevel;
            levelManager.level++;
            levelManager.coinRewardAmount += Mathf.RoundToInt(levelManager.coinRewardAmount * .3f);
            levelManager.RewardPerCoin += Mathf.RoundToInt(levelManager.RewardPerCoin * .5f);
            isLevelEnd = true;
            Mage.GetComponent<CharachterController>().enabled = false;
        }
    }
   
    public void NextLevel()
    {
        GetLevelCoins();
    }
    public void TryAgain()
    {
        SceneManager.LoadScene(0);
    }
    public void GetLevelCoins()
    {
       
        StartCoroutine(nameof(CallLevelCoins));
        StartCoroutine(nameof(DelayForNextLevel));
    }

    IEnumerator CallLevelCoins()
    {
        for (var i = 0; i < levelManager.LevelRewardAmount; i++)
        {
            yield return new WaitForSeconds(.05f);
            coinManager.StartCoinMove(Mage.transform.position, () =>
            {
                levelManager.TotalCoins += levelManager.LevelRewardPerCoin;
                TotalCoinTxt.text = levelManager.TotalCoins.ToString();
            });
        }
    }
    IEnumerator DelayForNextLevel()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }
}
