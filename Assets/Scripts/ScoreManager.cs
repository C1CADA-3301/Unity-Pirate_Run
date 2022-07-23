using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Score_Manager;

    public int score = 0;
    public int Highscore = 0;
    public int Coin = 0;
    public int CoinCount = 0;

    private void Awake()
    {
        if (Score_Manager == null)
        {
            Score_Manager = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
            
        
    }
    void Start()
    {
        
        Highscore = PlayerPrefs.GetInt("HighScore", 0);
        CoinCount = PlayerPrefs.GetInt("CoinCount", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(score>Highscore)
        {
            Highscore = score;
            PlayerPrefs.SetInt("HighScore", Highscore) ;
            

        }
       

        if(Coin!=0)
        {
            CoinCount = Coin;
            PlayerPrefs.SetInt("CoinCount", CoinCount);
            Coin=0;

        }
       




    }

    public void ResetScore()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        PlayerPrefs.SetInt("CoinCount", 0);
        Highscore = 0;
        CoinCount = 0;
    }





    
}
