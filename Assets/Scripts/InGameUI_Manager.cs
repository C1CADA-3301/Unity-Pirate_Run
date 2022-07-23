using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI_Manager : MonoBehaviour
{

    [SerializeField] private Text UI_txt_Score;
    [SerializeField] private Text UI_txt_Coin;

    [SerializeField] private Text UI_txt_GameOverScore;
    [SerializeField] private Text UI_txt_GameOverCoin;

    [SerializeField] private Text UI_txt_Bullet;
    [SerializeField] private Button UI_btn_Pause;
    [SerializeField] private GameObject Panel_Pause;
    [SerializeField] private GameObject Panel_GameOver;

    private void Awake()
    {
        Panel_GameOver.SetActive(false);
        Panel_Pause.SetActive(false);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UI_txt_Score.text = " "+GameManager.Game_Manager.score;
        UI_txt_Coin.text = " " + GameManager.Game_Manager.coin;
        UI_txt_Bullet.text = " " + GameManager.Game_Manager.Bullet_Count;

        UI_txt_GameOverScore.text = " " + GameManager.Game_Manager.score;
        UI_txt_GameOverCoin.text = " " + GameManager.Game_Manager.coin;

        if(GameManager.Game_Manager._Gameover)
        {
            GameOverPanel();
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        Panel_Pause.SetActive(true);
    }

    public void Resume()
    {
        
        Time.timeScale = 1;
        Panel_Pause.SetActive(false);

    }

    public void Restart()
    {

        GameManager.Game_Manager.Restart();

    }

    public void Home()
    {

        GameManager.Game_Manager.Home();

    }

    public void GameOverPanel()
    {
        Panel_GameOver.SetActive(true);
    }

}
