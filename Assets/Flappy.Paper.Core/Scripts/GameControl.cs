using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameControl : MonoBehaviour 
{
	public static GameControl instance;			//A reference to our game control script so we can access it statically.
	public GameObject gameOvertext;             //A reference to the object that displays the text which appears when the player dies.

	public int score = 0;						//The player's score.
	public bool gameOver = false;				//Is the game over?
	public float scrollSpeed = -1.5f;

	public TextMeshProUGUI lifeText;
	private TextMeshProUGUI scoreText;

	private void Start()
	{
		scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
		lifeText = GameObject.Find("lifeText").GetComponent<TextMeshProUGUI>();
		lifeText.text = "x" + MainMenu.PlayerDataObject.life.ToString();
	}

	void Awake()
	{
		
		if (instance == null)
			instance = this;
		else if(instance != this)
			Destroy (gameObject);
	}

    void Update()
	{
		if (gameOver && Input.GetMouseButtonDown(0)) 
		{
			StoreUserDataWhenPaperDie();

			if (MainMenu.PlayerDataObject.life <= 0)
			{
				SceneManager.LoadScene("Menu");
			}
			else
            {
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}

		}
	}

	public void BirdScored()
	{
		if (gameOver)	
			return;
		score++;
		scoreText.text = "SCORE: " + score.ToString();
	}

	public void BirdPowerUpLife()
	{
		if (gameOver)
			return;
		MainMenu.PlayerDataObject.life++;
		lifeText.text = "x" + MainMenu.PlayerDataObject.life.ToString();
	}

	public void BirdDied()
	{
		gameOvertext.SetActive(true);
		gameOver = true;
	}

	public void StoreUserDataWhenPaperDie()
    {
		LifeMinus();
		if (score > MainMenu.PlayerDataObject.bestScore)
		{
			SaveSystem.SavePlayer(score, MainMenu.PlayerDataObject.life);
			MainMenu.PlayerDataObject.bestScore = score;
		}
		else
		{
			SaveSystem.SavePlayer(MainMenu.PlayerDataObject.bestScore, MainMenu.PlayerDataObject.life);
		}
	}

	public void LifeMinus()
    {
		MainMenu.PlayerDataObject.life--;
		lifeText.text = "x" + MainMenu.PlayerDataObject.life.ToString();
	}
}
