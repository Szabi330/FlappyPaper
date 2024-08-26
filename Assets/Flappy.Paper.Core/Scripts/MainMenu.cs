using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public static PlayerData PlayerDataObject;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI bestScore;
    public TextMeshProUGUI nextFreeLiveText;
    public GameObject Achievements;
    public Sprite[] achievementsSprites;
    public GameObject CollectButton;
    public TextMeshProUGUI nextTrophytext;
    public Button PlayButton;
    public GameObject[] MiniAchivements;

    private DateTime nextFreeLiveTime;

    // UNITY ADS
    string gameId = "4056761";
    bool testMode = false;
    public string surfacingId = "Banner_Android";

    private void Start()
    {
        livesText = GameObject.Find("livesText").GetComponent<TextMeshProUGUI>();
        bestScore = GameObject.Find("BestScore").GetComponent<TextMeshProUGUI>();

        PlayerDataObject = SaveSystem.LoadPlayer();
        nextFreeLiveTime = SaveSystem.LoadNextFreeLive();

        if (PlayerDataObject.life <= 0)
        {
            PlayButton.interactable = false;
        }
        else
        {
            PlayButton.interactable = true;
        }

        livesText.text = "x" + PlayerDataObject.life.ToString();
        bestScore.text = "BEST SCORE: " + PlayerDataObject.bestScore.ToString();

        CheckFreeLive();

        if (PlayerDataObject.bestScore > 0)
        {
            Achievements.SetActive(true);
            SetCurrentProgressOfAchievement(PlayerDataObject.bestScore);
        }
    }

    private void CheckFreeLive()
    {
        var remainingTime = (nextFreeLiveTime.AddHours(1) - DateTime.Now);
        if (remainingTime.Minutes > 0 || remainingTime.Hours > 0)
        {
            nextFreeLiveText.text = "Next Free Live in: " + remainingTime.Minutes + " minutes";
        }
        else
        {
            CollectButton.SetActive(true);
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void SetCurrentProgressOfAchievement(int score)
    {
        if (score > 0 && score < 10)
        {
            Achievements.GetComponent<SpriteRenderer>().sprite = achievementsSprites[0];
            nextTrophytext.text = "NEXT TROPHY AT 10";
           
        }
        if (score >= 10 && score < 15)
        {
            Achievements.GetComponent<SpriteRenderer>().sprite = achievementsSprites[1];
            nextTrophytext.text = "NEXT TROPHY AT 15";
            SetActiveMiniAchivements(1);
        }
        if (score >= 15 && score < 20)
        {
            Achievements.GetComponent<SpriteRenderer>().sprite = achievementsSprites[2];
            nextTrophytext.text = "NEXT TROPHY AT 20";
            SetActiveMiniAchivements(2);
        }
        if (score >= 20 && score < 30)
        {
            Achievements.GetComponent<SpriteRenderer>().sprite = achievementsSprites[3];
            nextTrophytext.text = "NEXT TROPHY AT 30";
            SetActiveMiniAchivements(3);
        }
        if (score >= 30 && score < 40)
        {
            Achievements.GetComponent<SpriteRenderer>().sprite = achievementsSprites[4];
            nextTrophytext.text = "NEXT TROPHY AT 40";
            SetActiveMiniAchivements(4);
        }
        if (score >= 40 && score < 50)
        {
            Achievements.GetComponent<SpriteRenderer>().sprite = achievementsSprites[5];
            nextTrophytext.text = "NEXT TROPHY AT 50";
            SetActiveMiniAchivements(5);
        }
        if (score >= 50 && score < 60)
        {
            Achievements.GetComponent<SpriteRenderer>().sprite = achievementsSprites[6];
            nextTrophytext.text = "NEXT TROPHY AT 60";
            SetActiveMiniAchivements(6);
        }
        if (score >= 60 && score < 70)
        {
            Achievements.GetComponent<SpriteRenderer>().sprite = achievementsSprites[7];
            nextTrophytext.text = "NEXT TROPHY AT 70";
            SetActiveMiniAchivements(7);
        }
        if (score >= 70 && score < 80)
        {
            Achievements.GetComponent<SpriteRenderer>().sprite = achievementsSprites[8];
            nextTrophytext.text = "NEXT TROPHY AT 80";
            SetActiveMiniAchivements(8);
        }
        if (score >= 80 && score < 90)
        {
            Achievements.GetComponent<SpriteRenderer>().sprite = achievementsSprites[9];
            nextTrophytext.text = "NEXT TROPHY AT 90";
            SetActiveMiniAchivements(9);
        }
        if (score >= 90 && score < 100)
        {
            Achievements.GetComponent<SpriteRenderer>().sprite = achievementsSprites[10];
            nextTrophytext.text = "NEXT TROPHY AT 100";
            SetActiveMiniAchivements(10);
        }
        if (score >= 100)
        {
            Achievements.GetComponent<SpriteRenderer>().sprite = achievementsSprites[11];
            nextTrophytext.text = "AWESOME";
            SetActiveMiniAchivements(11);
        }
    }

    private void SetActiveMiniAchivements(int current)
    {
        for (int i = 0; i < current; i++)
        {
            MiniAchivements[i].SetActive(true);
        }
    }

    public void CollectFreeLive()
    {
        MainMenu.PlayerDataObject.life = MainMenu.PlayerDataObject.life + 1;
        SaveSystem.SavePlayer(MainMenu.PlayerDataObject.bestScore, MainMenu.PlayerDataObject.life);
        SaveSystem.SaveNextFreeLive();
        CollectButton.SetActive(false);
        SceneManager.LoadScene("Menu");
    }

    public void UserBought100Lives()
    {
        MainMenu.PlayerDataObject.life = MainMenu.PlayerDataObject.life + 100;
        SaveSystem.SavePlayer(MainMenu.PlayerDataObject.bestScore, MainMenu.PlayerDataObject.life);
        SceneManager.LoadScene("Menu");
    }
}
