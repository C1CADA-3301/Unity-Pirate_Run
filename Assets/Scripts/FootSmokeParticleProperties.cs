using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSmokeParticleProperties : MonoBehaviour
{
    
    void Start()
    {
        StartCoroutine(StopEffect());
    }

    IEnumerator StopEffect()
    {
        yield return new WaitForSecondsRealtime(3f);
        gameObject.SetActive(false);
    }
}
