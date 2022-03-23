using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip levelupClip;
    [SerializeField] private ParticleSystem levelupFX;
    [SerializeField] private AudioClip ButtonClip;
    [SerializeField] private AudioListener audioListener;
    
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void LevelUpSkill()
    {
        audioSource.PlayOneShot(levelupClip, 1);
        levelupFX.Play();
       
    }
    public void MuteSound()
    {
        AudioListener.pause = true;
    }
    public void UpSound()
    {
        AudioListener.pause = false;
    }
}
