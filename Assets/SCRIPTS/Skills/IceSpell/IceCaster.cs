using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCaster : MonoBehaviour
{
    [HideInInspector] public GameObject IceObject;
    [HideInInspector] public int Damage;
    [HideInInspector] public float skillshotspeed;
    [HideInInspector] public float spellDurationTime;
    [HideInInspector] public float spellDelay;
    [SerializeField] private Transform SpellSpawnPosition;
    

    public void LaunchIce()
    {
        var spellcopy = Instantiate(IceObject, new Vector3(SpellSpawnPosition.position.x, -.5f, SpellSpawnPosition.position.z), Quaternion.identity);
        StartCoroutine(DestroyInTime(spellcopy));
    }

    public IEnumerator DestroyInTime(GameObject fireballClone)
    {
        yield return new WaitForSeconds(spellDurationTime);
        DestroyImmediate(fireballClone);
    }
}
