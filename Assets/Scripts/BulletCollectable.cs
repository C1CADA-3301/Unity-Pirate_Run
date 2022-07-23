using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollectable : MonoBehaviour
{
    [SerializeField] private int No_Of_Bullets_In_Collectable = 10;
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
            GameManager.Game_Manager.Bullet_Count += No_Of_Bullets_In_Collectable;
            Destroy(gameObject);
        }
    }
}
