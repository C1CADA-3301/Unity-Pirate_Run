using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("Platform")]
    [SerializeField] private int Level_Length = 0;
    [SerializeField] private int Start_Platform_Length = 5, End_Platform_Length = 5;
    [SerializeField] private int Platform_Length_Min = 1, Platform_Length_Max = 4;
    [SerializeField] private float Distance_Between_Platforms = 0f;
    [SerializeField] private float PlatformPosition_MixY = 0f, PlatformPosition_MaxY = 10f;
    [SerializeField] private Transform Platform_Prefab, Platform_Parent;
    [Header("Monster & Health")]
    [SerializeField] private Transform Monster, Monster_Parent;
    [SerializeField] private Transform Health_Collectable, Health_Collectable_Parent;
    [SerializeField] private float Chance_For_Monster = 0.25f, Chance_For_Collectable = 0.1f;
    [SerializeField] private float HealthCollectable_MinY = 1f, HealthCollectable_MaxY = 3f;
    [Header("Coin")]
    [SerializeField] private Transform Coin, Coin_Parent;
    [SerializeField] private float Chance_For_Coin = 1f;
    [Header("Bullet_Collectable")]
    [SerializeField] private Transform BulletCollectable_Prefab, BullectCollectable_Parent;
    [SerializeField] private float Chance_For_Bullet = 0.25f;



    private bool GameStarting = true;
    private float Platform_Last_PositionXTemp;
    private float Last_Platform_PositionX;


    private enum PlatformType { None, Flat};


        private class PlatformPositionInfo
        {
        public PlatformType PlatformType;
        public float PositionY;
        public bool HasMonster;
        public bool HasCoin;
        public bool HasBullet;

            public PlatformPositionInfo (PlatformType type,float posy,bool has_monster,bool has_coin,bool has_bullet)
            {
            PlatformType = type;
            PositionY = posy;
            HasMonster = has_monster;
            HasCoin = has_coin;
            HasBullet = has_bullet;
            }
        }//Class platformPositionInfo

    void FilloutPositioinInfo(PlatformPositionInfo [] PlatformInfo)
    {
        int CurrentPlatformInfoIndex = 0;

        for(int i=0;i<Start_Platform_Length;i++)
        {
            Debug.Log("Start Platform");
            PlatformInfo[CurrentPlatformInfoIndex].PlatformType = PlatformType.Flat;
            PlatformInfo[CurrentPlatformInfoIndex].PositionY = 0f;

            CurrentPlatformInfoIndex++;
        }

        while(CurrentPlatformInfoIndex<Level_Length-End_Platform_Length)
        {
            if (PlatformInfo[CurrentPlatformInfoIndex - 1].PlatformType == PlatformType.Flat)
            {
                Debug.Log("Gape");
                CurrentPlatformInfoIndex++;
                continue;

                
            }

            float PlatformPositionY = Random.Range(PlatformPosition_MixY, PlatformPosition_MaxY);
            int PlatformLength = Random.Range(Platform_Length_Min, Platform_Length_Max);
            //Debug.Log("Platform Length = "+PlatformLength);
            for(int i=0;i<PlatformLength;i++)
            {
                Debug.Log("i=" + i);
                bool Has_Monster = (Random.Range(0f, 1f) < Chance_For_Monster);
                bool Has_Coin = (Random.Range(0f, 1f) < Chance_For_Coin);
                bool Has_Bullet = (Random.Range(0f, 1f) < Chance_For_Bullet);


                PlatformInfo[CurrentPlatformInfoIndex].PlatformType = PlatformType.Flat;
                PlatformInfo[CurrentPlatformInfoIndex].PositionY = PlatformPositionY;
                PlatformInfo[CurrentPlatformInfoIndex].HasMonster = Has_Monster;
                PlatformInfo[CurrentPlatformInfoIndex].HasCoin = Has_Coin;
                PlatformInfo[CurrentPlatformInfoIndex].HasBullet = Has_Bullet;

                CurrentPlatformInfoIndex++;

                if(CurrentPlatformInfoIndex>Level_Length-End_Platform_Length)
                {
                    CurrentPlatformInfoIndex = Level_Length - End_Platform_Length;
                    break;
                }
            }//forloop

            

        }//while loop
        for (int i = 0; i < End_Platform_Length; i++)
        {
            Debug.Log("End Platform");
            PlatformInfo[CurrentPlatformInfoIndex].PlatformType = PlatformType.Flat;
            PlatformInfo[CurrentPlatformInfoIndex].PositionY = 0f;

            CurrentPlatformInfoIndex++;
        }
    }//FilloutPositioinInfo

    void CreatePlatformFromPositionInfo(PlatformPositionInfo[] platformpositioninfo,bool gameStarting)
    {
        
        for(int i=0;i<platformpositioninfo.Length;i++)
        {
            PlatformPositionInfo PositionInfo = platformpositioninfo[i];

            if(PositionInfo.PlatformType==PlatformType.None)
            {
                continue;
            }

            Vector3 PlatformPosition;
            if(gameStarting)
            {
                PlatformPosition = new Vector3(Distance_Between_Platforms * i, PositionInfo.PositionY, 0);
            }
            else
            {
                PlatformPosition = new Vector3(((Distance_Between_Platforms *i)+Last_Platform_PositionX), PositionInfo.PositionY, 0);
            }
            Platform_Last_PositionXTemp = PlatformPosition.x;
            

            Transform CreatBlock = (Transform) Instantiate(Platform_Prefab, PlatformPosition, Quaternion.Euler(-90,0,0),Platform_Parent);

            if(PositionInfo.HasMonster)
            {
                Transform CreateEnemy = Instantiate(Monster, PlatformPosition+(new Vector3 (0,0.05f,0)), Quaternion.Euler(0,-100,0),Monster_Parent);
            }

            if(PositionInfo.HasCoin)
            {
                Transform CreateCoin = Instantiate(Coin, PlatformPosition + (new Vector3(0, (Random.Range(1,6)), 0)), Quaternion.Euler(90,90,-90), Coin_Parent);
            }

            if (PositionInfo.HasBullet)
            {
                Transform CreateBulletCollectable = Instantiate(BulletCollectable_Prefab, PlatformPosition + (new Vector3(0, (Random.Range(2, 8)), 0)), Quaternion.identity, BullectCollectable_Parent);
            }
        }
        Last_Platform_PositionX = Platform_Last_PositionXTemp;
        Debug.Log("PlatformLast Pos = "+Last_Platform_PositionX);//for loop
    }//CreatePlatformFromPositionInfo

    public void GenerateLevel(bool gameStarting)
    {
        PlatformPositionInfo[] PlatformInfo = new PlatformPositionInfo[Level_Length];
        for(int i=0;i<PlatformInfo.Length;i++)
        {
            PlatformInfo[i] = new PlatformPositionInfo(PlatformType.None, -1f, false, false,false);
        }
        FilloutPositioinInfo(PlatformInfo);
        CreatePlatformFromPositionInfo(PlatformInfo,gameStarting);
    }



    void Start()
    {
        GenerateLevel(GameStarting);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}//Class LevelGenerator
