using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_MainMenu_Manager : MonoBehaviour
{
    public Text txt_HighScore;
    public Text txt_Coin;
    public GameObject Container_HomeMenu;
    public GameObject Options_Panel;
    public GameObject HowToPlay_Panel;

    void Start()
    {
        Container_HomeMenu.SetActive(true);
        Options_Panel.SetActive(false);
        HowToPlay_Panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        txt_HighScore.text = ScoreManager.Score_Manager.Highscore.ToString();
        txt_Coin.text = ScoreManager.Score_Manager.CoinCount.ToString();
    }

    public void play_btn()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit_btn()
    {
        Application.Quit();
    }

    public void Options_btn()
    {
        Container_HomeMenu.SetActive(false);
        Options_Panel.SetActive(true);

    }

    public void HowToPlay_btn()
    {
        Container_HomeMenu.SetActive(false);
        HowToPlay_Panel.SetActive(true);

    }

    public void Home()
    {
        Container_HomeMenu.SetActive(true);
        Options_Panel.SetActive(false);
        HowToPlay_Panel.SetActive(false);

    }




}
