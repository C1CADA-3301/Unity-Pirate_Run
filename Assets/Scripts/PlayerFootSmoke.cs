using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootSmoke : MonoBehaviour
{
    public GameObject SmokeEffect;
    public GameObject SmokePosition;
    public GameObject SmokeParent;

    private void OnTriggerEnter(Collider Target)
    {
        if (Target.CompareTag(Tags.Platform))
        {
            if(SmokePosition.activeInHierarchy)
            {
              GameObject Smoke = Instantiate(SmokeEffect, SmokePosition.transform.position, Quaternion.identity,SmokeParent.transform);
                
            }
        }
    }
}
