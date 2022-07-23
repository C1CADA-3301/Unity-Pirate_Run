using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorePlatforms : MonoBehaviour
{
    private float DistanceForMorePlatformObject = 120f;
    private LevelGenerator LevelGenerator;
    private LevelGeneratorPooling LevelGenerator_Pooling;

    
    private void Awake()
    {
        LevelGenerator = GameObject.Find(Tags.Level_Generator_OBJ).GetComponent<LevelGenerator>();
        LevelGenerator_Pooling = GameObject.Find(Tags.Level_Generator_OBJ).GetComponent<LevelGeneratorPooling>();
    }
    private void OnTriggerEnter(Collider Other)
    {
        if(Other.CompareTag(Tags.Player_Tag))
        {
            Vector3 temp = gameObject.transform.position;
            temp.x += DistanceForMorePlatformObject;
            gameObject.transform.position = temp;
            LevelGenerator.GenerateLevel(false);
            //LevelGenerator_Pooling.PoolingPlatforms();
        }
    }
}
