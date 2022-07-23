using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator Anim;
    [SerializeField] private GameObject Gun_Stationary;
    [SerializeField] private GameObject Gun_Hand;

    private void Awake()
    {
        Anim = GetComponent<Animator>();
    }
    private void Start()
    {
        Gun_Hand.SetActive(false);
        Gun_Stationary.SetActive(true);
    }

    public void DidJump()
    {
        Anim.SetBool("IsDoubleJump", false);
        Anim.SetBool("DidLand", false);
        Anim.SetBool("IsRun", false);
        Anim.SetBool("IsJump", true);
    }

    

    public void DidLand ()
    {
        Anim.SetBool("IsDoubleJump", false);
        Anim.SetBool("DidLand", true);
        Anim.SetBool("IsJump", false);
        Anim.SetBool("IsRun", true);

    }
    public void PlayerRun()
    {
        Anim.SetBool("IsDoubleJump", false);
        Anim.SetBool("IsRun", true);
    }

    public void ShootAnim()
    {
        Anim.SetLayerWeight(1, 1);
        Anim.SetBool("Shoot", true);
        Gun_Stationary.SetActive(false);
        Gun_Hand.SetActive(true);
        StartCoroutine(shoottime());
        

    }

    IEnumerator shoottime()
    {
        yield return new WaitForSeconds(1f);
        Anim.SetLayerWeight(1, 0);
        Anim.SetBool("Shoot", false);
        Gun_Stationary.SetActive(true);
        Gun_Hand.SetActive(false);
    }

    

    //public void PlayerIdle()
    //{
    //    Anim.Play(Tags.ANIMATION_IDLE);
    //}

}

