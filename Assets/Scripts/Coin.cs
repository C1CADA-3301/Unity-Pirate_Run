using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(Tags.Player_Tag))
        {
            GameManager.Game_Manager.Coin_Update();
            SoundManager.SoundManager_Instance.Coin_sfx();
            Destroy(gameObject);
        }
    }
}
