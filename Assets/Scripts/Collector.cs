using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag(Tags.Player_Tag) )
        {
            other.gameObject.SetActive(false);
        }
    }
}
