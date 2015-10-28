using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI : MonoBehaviour {

	public CamBounds camBounds;
	public EnemyManager enemyManager;
	public GameObject playerGO;
	public Canvas menu;

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
		GameExit
	}

	void Awake () {

	}

	void Start () {
		if (!playerGO)
			print ("Player Ship not registerd with UI");
		MenuOn();
		uiScreen = UIScreen.MenuOn;
		Time.timeScale = 0f;
	}

	void Update () {
		if ( Input.GetButton("Pause") ){
			MenuOn();
		}


		// check for change
		if (uiScreen != oldUiScreen) {

			if (uiScreen == UIScreen.GameRun){

				print ("Game Run");
				menu.enabled = false;
				Time.timeScale = 1f;

			}

			if (uiScreen == UIScreen.MenuOn) {

				print ("Menu On");
				menu.enabled = true;
				Time.timeScale = 0f;

			}

			if (uiScreen == UIScreen.Options) {



			}

			if (uiScreen == UIScreen.GameExit){
				print ("Game Exit");
				Application.Quit();
			}

			oldUiScreen = uiScreen;

		}

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
		print ("Option Menu");

	}
	
	public void GameOver () {
		// when the player dies
		print ("Game Over");

	}

	public void GameExit () {
		// exits the game
		uiScreen = UIScreen.GameExit;
		print ("Game Exit");
	}

}
