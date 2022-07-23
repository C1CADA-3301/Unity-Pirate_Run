using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthDamage : MonoBehaviour
{
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private Transform BulletParent;
    [SerializeField] private Transform ShootBarrel;
    [SerializeField] private GameObject PlayerDeathEffect;
    
    public bool CanShoot;
    private BG_Scroller BgScrollerRef;
    private PlayerAnimation PlayerAnim;
    [Header("MUZZLE FLASH")]
    [SerializeField] GameObject MuzzleFlash_Effect;
    [SerializeField] GameObject MuzzleFlash_Position;
    [SerializeField] Transform MuzzleFlash_Parent;
    //[SerializeField] int BulletCount =10;

    // Start is called before the first frame update

    private void Awake()
    {
        PlayerAnim = GetComponent<PlayerAnimation>();
        BgScrollerRef = GameObject.Find(Tags.Background).GetComponent<BG_Scroller>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shoot();
    }

    void shoot()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(CanShoot && !GameManager.Game_Manager._Gameover && GameManager.Game_Manager.Bullet_Count>0)
            {

                PlayerAnim.ShootAnim();
                GameManager.Game_Manager.Bullet_Count-- ;
                SoundManager.SoundManager_Instance.shoot_sfx();
                
            }
            
        }
    }
    void BulletFire()
    {

        GameObject Bullet = Instantiate(BulletPrefab, ShootBarrel.position, Quaternion.identity, BulletParent);
        Bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 400f);
        if (MuzzleFlash_Position.activeInHierarchy)
        {
            GameObject Smoke = Instantiate(MuzzleFlash_Effect, MuzzleFlash_Position.transform.position, Quaternion.identity,MuzzleFlash_Parent);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(Tags.Enemy_BulletTag) || other.CompareTag(Tags.Bounds))
        {
            Vector3 EffectPos = transform.position;
            EffectPos.y += 2f;
            GameObject DeathEffect = Instantiate(PlayerDeathEffect, EffectPos, Quaternion.identity);
            BgScrollerRef.CanScroll = false;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag(Tags.Enemy_Tag))
        {
            Vector3 EffectPos = transform.position;
            EffectPos.y += 2f;
            GameObject DeathEffect = Instantiate(PlayerDeathEffect, EffectPos, Quaternion.identity);
            BgScrollerRef.CanScroll = false;
            GameManager.Game_Manager.GameOver();
            Destroy(gameObject);
            
        }
    }

   
}
