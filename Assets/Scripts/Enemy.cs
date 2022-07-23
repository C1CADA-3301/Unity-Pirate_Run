using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float DetectionRange = 20;
    [SerializeField] private float MovementSpeed = 5;
    private float DistancefromPlayer;
    private float MoveDirection;
    [SerializeField] private bool canshoot;
    [SerializeField] private bool InRange;
    private bool MoveRight;
    private GameObject PlayerRef;
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private Transform ShootBarrel;
    private Transform BulletParent;
    [SerializeField] private GameObject EnemyDeathEffect;
    [SerializeField] private Transform EnemyDeathEffectParent;

    
    private string StartShootingFunction = "StartShooting";

    private void Awake()
    {
        EnemyDeathEffectParent = GameObject.Find("EnemyDeathEffectParent").transform;
        BulletParent = GameObject.Find("BulletParent_Enemy").transform;
        PlayerRef = GameObject.FindGameObjectWithTag(Tags.Player_Tag);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerRef)
        {
            DistancefromPlayer = Mathf.Abs((transform.position - PlayerRef.transform.position).magnitude);
            MoveDirection = (PlayerRef.transform.position.x - transform.position.x);
            //canshoot = false;
            MoveRight = false;

               
            if (DistancefromPlayer <= DetectionRange)
            {
                //canshoot = true;
                if (MoveDirection < 0)
                {
                   // canshoot = true;
                   MoveRight = false;
                    transform.localScale = new Vector3(1f, 1f, 1f);
                    transform.position = new Vector3(transform.position.x-Time.deltaTime*MovementSpeed,transform.position.y,transform.position.z);

                }
                else
                {
                    //canshoot = true;
                    MoveRight = true;
                    transform.localScale = new Vector3(1f, 1f, -1f);
                    transform.position = new Vector3(transform.position.x + Time.deltaTime * MovementSpeed, transform.position.y, transform.position.z);
                }

                if(!InRange)
                {
                    if(canshoot)
                    {
                        InvokeRepeating(StartShootingFunction, 0.5f, 20f);
                    }
                    InRange = true;
                  
                }
                

            }//DistancefromPlayer <= DetectionRange
            else
            {
                CancelInvoke(StartShootingFunction);
            }
            

        }//PlayerRef
        
    }//Update

    void StartShooting()
    {
        GameObject Bullet = Instantiate(BulletPrefab, ShootBarrel.position, Quaternion.identity, BulletParent);
        Bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 100f);
       


    }//StartShooting

    private void OnCollisionEnter(Collision target)
    {
        if(target.collider.CompareTag(Tags.Player_Tag))
        {
            Vector3 EffectPos = transform.position;
            EffectPos.y += 2f;
            GameObject DeathEffect = Instantiate(EnemyDeathEffect, EffectPos, Quaternion.identity, EnemyDeathEffectParent);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider target)
    {
        if(target.CompareTag(Tags.Player_BulletTag))
        {
            Vector3 EffectPos = transform.position;
            EffectPos.y += 2f;
            GameObject DeathEffect = Instantiate(EnemyDeathEffect, EffectPos, Quaternion.identity, EnemyDeathEffectParent);
            Destroy(gameObject);
        }
        
    }


}//MonoBehaviour
