using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI : MonoBehaviour {

	public CamBounds camBounds;
	public EnemyManager enemyManager;
	public GameObject playerGO;
	public Canvas menu;
	public Canvas options;

	public bool testPlayer = true;
	// game states

	bool isPlayerActive = false;
	bool isEnemySpawn = false;
	bool isMenueActive = true;
	float gameSpeed = 1f;

	UIScreen uiScreen;
	UIScreen oldUiScreen;

	public enum UIScreen {
		MenuOn,
		Options,
		GameRun,
		GameExit,
		Return,
		GameOver
	}

	void Awake () {
		menu.gameObject.SetActive(true);
		options.gameObject.SetActive(true);
	}

	void Start () {
		if (!playerGO)
			print ("Player Ship not registerd with UI");
		MenuOn();
		uiScreen = UIScreen.MenuOn;
		Time.timeScale = 0f;
	}

	// system states, first run brute force it make it ugly make it work

	public void MenuOn() {
		// when the game starts up and after a game over
		uiScreen=UIScreen.MenuOn;
		
	}
	
	public void GameRun() {
		// when the start button is pressed 
		uiScreen = UIScreen.GameRun;
	}
	
	public void OptionsMenu () {
		// when the options menue button is pressed
		uiScreen = UIScreen.Options;
		
	}
	
	public void GameOver () {
		uiScreen = UIScreen.GameOver;
		
	}
	
	public void GameExit () {
		// exits the game
		uiScreen = UIScreen.GameExit;

	}

	// check UI states
	void Update () {
		if ( Input.GetButton("Pause") ){
			MenuOn();
		}

		if (uiScreen != oldUiScreen) {

			if (uiScreen == UIScreen.GameRun){

				menu.enabled = false;
				options.enabled = false;
				Time.timeScale = 1f;

			}

			if (uiScreen == UIScreen.MenuOn) {

				menu.enabled = true;
				options.enabled = false;
				Time.timeScale = 0f;

			}

			if (uiScreen == UIScreen.Options) {

				menu.enabled = false;
				options.enabled = true;

			}

			if (uiScreen == UIScreen.Return) {
				
				menu.enabled = true;
				options.enabled = false;
				
			}

			if (uiScreen == UIScreen.GameExit){

				Application.Quit();
			}

			oldUiScreen = uiScreen;
		}



	}



}
