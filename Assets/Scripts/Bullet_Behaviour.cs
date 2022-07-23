using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Behaviour : MonoBehaviour
{
    [SerializeField] private float LifeTime = 5f;
    [SerializeField] private Transform PlayerPosition;
    //private Vector3 PlayerPos;

    private void Awake()
    {
       // PlayerPosition = GameObject.FindGameObjectWithTag(Tags.Player_Tag).transform;
    }
    private void Start()
    {
       // PlayerPos = PlayerPosition.position;
        Bulletpos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        
        
        StartCoroutine(TurnOffBullet());
    }
    private void Update()
    {

        
        BulletMove();
    }


    IEnumerator TurnOffBullet()
    {
        yield return new WaitForSeconds(LifeTime);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider target)
    {
        if(target.CompareTag(Tags.Enemy_Tag) || target.CompareTag(Tags.Player_Tag))
        {
            gameObject.SetActive(false);
        }
    }

    private Vector3 Bulletpos;
    void BulletMove()
    {
       // Vector3 bulletmove = transform.position;
        //Bulletpos.x += transform.position.x * Time.deltaTime;
       // transform.position = Bulletpos;
        //transform.Translate(PlayerPos);
    }
}
