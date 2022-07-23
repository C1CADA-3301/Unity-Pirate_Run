using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform PlayerTarget;
    [SerializeField] private float OffsetZ = -15f;
    [SerializeField] private float OffsetX =5f;
    [SerializeField] private float ConstantY =5f;
    [SerializeField] private float LerpTime = 0.05f;

    private void Awake()
    {
        PlayerTarget = GameObject.FindGameObjectWithTag(Tags.Player_Tag).transform;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(PlayerTarget)
        {
            Vector3 TargetPosition = new Vector3(PlayerTarget.position.x + OffsetX, ConstantY, PlayerTarget.position.z + OffsetZ);
            transform.position = Vector3.Lerp(transform.position, TargetPosition, LerpTime);
        }
    }
}
