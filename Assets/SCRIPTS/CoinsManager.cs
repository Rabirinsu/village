using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{
  public float speed;
    private AudioSource audioSource;
    [SerializeField] private AudioClip coinClip;
    public Transform target;
    public GameObject Coin;
    public Camera cam;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        cam = Camera.main;
    }

    public void StartCoinMove(Vector3 intial, Action onComplete)
    {
        var targetPosition = cam.ScreenToWorldPoint(new Vector3(target.position.x, target.position.y, cam.transform.position.z * -1));
        var coin = Instantiate(Coin,transform) ;
 
        StartCoroutine(MoveCoin(coin.transform, intial, targetPosition, onComplete));
    }

    IEnumerator MoveCoin(Transform obj, Vector3 startPosition, Vector3 endPosition, Action onComplete)
    {
        var time = 0f;
   
        while (time < 1)
        {
            time += speed * Time.deltaTime;
            obj.position = Vector3.Lerp(startPosition, endPosition, time);
            yield return new WaitForEndOfFrame();
        }

        //    AndroidManager.HapticFeedback();
        audioSource.PlayOneShot(coinClip, 1);
        onComplete.Invoke();
        Destroy(obj.gameObject);

    }
}
