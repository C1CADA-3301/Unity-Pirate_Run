using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSlip : MonoBehaviour
{
    private PlayerMovement playerMov;

    private void Awake()
    {
        playerMov = GameObject.FindGameObjectWithTag(Tags.Player_Tag).GetComponent<PlayerMovement>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider target)
    {
        if(target.CompareTag(Tags.Player_Tag))
        {
            Debug.Log("Triggered");
            playerMov.enabled = false;
        }
    }
}
