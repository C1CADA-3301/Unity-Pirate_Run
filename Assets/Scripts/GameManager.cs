using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Game_Manager{get;private set;}
    [HideInInspector]public bool _Gameover;
    public float PlayerFallDistance = -9.0f;
    private GameObject Player;
    public int score=0;
    public int coin=0;

    [SerializeField] public int Bullet_Count = 10;



    private void Awake()
    {
        Game_Manager = this;
        Player = GameObject.FindGameObjectWithTag(Tags.Player_Tag);
        score = 0;
        coin = 0;
        Bullet_Count = 5;
        Time.timeScale = 1;
    }
    private void Update()
    {
        if (!_Gameover)
        {
            Score_Update();
        }

        
    }

    public void GameOver()
    {
        SoundManager.SoundManager_Instance.Death_sfx();
        StartCoroutine(GameOverCoroutine());
    }

    public void Score_Update()
    {
        if(Player!=null)
        {
            
            score = (int)Player.transform.position.x;
            ScoreManager.Score_Manager.score = score;
        }
        
    }

    public void Coin_Update()
    {
        coin++;
        ScoreManager.Score_Manager.Coin += coin;
    }

    IEnumerator GameOverCoroutine()
    {
        yield return new WaitForSecondsRealtime(3f);
        _Gameover = true;
        Time.timeScale = 0;
        Debug.Log("GameOver");
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
