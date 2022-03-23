using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CooldDown : MonoBehaviour
{
    public Image darkMask;
    public TextMeshProUGUI coolDownText;

    [SerializeField] private GameObject player;
    private Animator animator;
    [SerializeField] private Spell spell;
    [SerializeField] private GameObject Weapon;
    private Image SkillIcon;
    private AudioSource spellSound;
    private float coolDownDuration = 2;
    private float nextReadyTime;
    private float coolDownTimeLeft;
    private bool coolDownComplete;
    private ParticleSystem spellfx;
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    private void Start()
    {
        Initialize(spell,Weapon);
    }
    void Update()
    {
        coolDownComplete = (Time.time > nextReadyTime);
        if (coolDownComplete)
        {
            AbilityReady();
     
        }
        else
        {
            CoolDown();
        }
    }

 private void Initialize(Spell selectedSpell, GameObject weapon)
    {
        spellfx = Instantiate(spell.spellFX, player.transform.position, Quaternion.Euler(-90, 0, 0));
        spellfx.transform.parent = player.transform;
       animator =  player.GetComponent<Animator>();
        spell = selectedSpell;
        SkillIcon = GetComponent<Image>();
        spellSound = GetComponent<AudioSource>();
        SkillIcon.sprite = spell.spellSprite;
        darkMask.sprite = spell.spellSprite;
        coolDownDuration = spell.spellCoolDown;

        selectedSpell.Initialize(weapon); // Call Spell Initialize
    }
    private void AbilityReady()
    {
        coolDownText.enabled = false;
        darkMask.enabled = false;
    }

    private void CoolDown()
    {
        coolDownTimeLeft -= Time.deltaTime;
        float roundedCd = Mathf.Round(coolDownTimeLeft);
        coolDownText.text = roundedCd.ToString();
        darkMask.fillAmount = (coolDownTimeLeft / coolDownDuration);
    }
    public void ButtonTriggered()
    {
        if (coolDownComplete)
        {
            nextReadyTime = coolDownDuration + Time.time;
            coolDownTimeLeft = coolDownDuration;
            darkMask.enabled = true;
            coolDownText.enabled = true;
            animator.SetTrigger(spell.animationName);
            spellSound.PlayOneShot(spell.spellPrepareSound, 1);
            spellfx.Play();
            StartCoroutine(nameof(SpellDelay));
        }
    }
    IEnumerator SpellDelay()
    { 
       
        yield return new WaitForSeconds(spell.DelayTime);
      
        spellSound.PlayOneShot(spell.spellSound, 1);
        spell.TriggerSpell(); // trigger fireball when button touched.
    }
  }
