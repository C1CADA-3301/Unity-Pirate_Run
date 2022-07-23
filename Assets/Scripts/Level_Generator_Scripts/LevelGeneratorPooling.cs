using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneratorPooling : MonoBehaviour
{
    [Header("PLATFORM")]
    [SerializeField] private int Level_Length = 0;
    [SerializeField] private int Start_Platform_Length = 3, End_Platform_Length = 3;
    [SerializeField] private int Platform_Min_Length = 1, Platform_Max_Length = 4;
    [SerializeField] private float Distance_Between_Platforms = 6;
    [SerializeField] private float Platform_Min_Position_Y = 0f, Platform_Max_Position_Y = 1f;
    [SerializeField] private Transform Platform_Prefab, Platform_Parent;

    [Header("MONSTER & HEALTH")]
    [SerializeField] private Transform Enemy_Prefab, Enemy_Parent;
    [SerializeField] private Transform Health_Prefab,Health_Parent;
    [SerializeField] private float Chance_For_Monster, Chance_For_Health;

    private float Platform_Last_Position_X;

    private Transform[] PlatformArray;

    private enum PlatformType { None,Filled};

    private class PlatformPositionInfoClass
    {
        public PlatformType platformType;
        public float PositionY;
        public bool HasMonster;
        public bool HasHealth;

        public PlatformPositionInfoClass(PlatformType type,float posy,bool has_monster,bool has_health)
        {
            platformType = type;
            PositionY = posy;
            HasMonster = has_monster;
            HasHealth = has_health;
        }
    }

    private void Start()
    {
        CreatePlatforms();
    }
    void CreatePlatforms()
    {
        PlatformArray = new Transform[Level_Length];

        for(int i=0;i<PlatformArray.Length;i++)
        {
            Transform New_Platform = Instantiate(Platform_Prefab, Vector3.zero, Quaternion.identity, Platform_Parent);
            PlatformArray[i] = New_Platform;
        }

        for(int i=0;i<PlatformArray.Length;i++)
        {
            float Platform_Position_Y = Random.Range(Platform_Min_Position_Y, Platform_Max_Position_Y);
            Vector3 Platform_Position;
            if(i<Start_Platform_Length)
            {
                Platform_Position_Y = 0;
                
            }
            Platform_Position = new Vector3(Distance_Between_Platforms * i, Platform_Position_Y, 0);
            Platform_Last_Position_X = Platform_Position.x;

            PlatformArray[i].position = Platform_Position;
            
        }
    }

    public void PoolingPlatforms()
    {
        for(int i=0;i<PlatformArray.Length;i++)
        {
            if(!PlatformArray[i].gameObject.activeInHierarchy)
            {
                PlatformArray[i].gameObject.SetActive(true);
                float PlatformPositionY = Random.Range(Platform_Min_Position_Y, Platform_Max_Position_Y);
                Vector3 PlatformPosition = new Vector3(Distance_Between_Platforms + Platform_Last_Position_X,PlatformPositionY,0);

                PlatformArray[i].position = PlatformPosition;
                Platform_Last_Position_X = PlatformPosition.x;
            }

        }
        
    }
}
