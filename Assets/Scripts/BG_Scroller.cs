using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Scroller : MonoBehaviour
{
    [SerializeField] private float BGOffsetSpeed = -0.0006f;
    private MeshRenderer BgRenderer;

    public bool CanScroll;

    private void Awake()
    {
        BgRenderer = GetComponent<MeshRenderer>();

    }

    private void FixedUpdate()
    {
        if(CanScroll && !GameManager.Game_Manager._Gameover)
        {
            BgRenderer.material.mainTextureOffset -= new Vector2(BGOffsetSpeed, 0);
        }
        
    }
}
