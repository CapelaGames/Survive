using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PopUp : MonoBehaviour 
{
	GameManager gameManager;

	GameObject PopupObject;

	public Text Title;
	public Text TextMessage;
	public Button button;

	public Button WaterButton;
	public Button FoodButton;
	public Button WinButton;

	public Image imagineZom;
	public Image imagineBan;

	public Button Weapon;
		

	void Start()
	{
		gameManager = FindObjectOfType<GameManager>();
		
		if(gameManager == null)
		{
			Debug.LogError("gameManager is not attached in scene");
		}
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.E))
		{
			RemoveMessage();
		}
		else if(WaterButton.gameObject.activeSelf == true)
		{
			if(Input.GetKeyDown(KeyCode.Q))
			{
				gameManager.Players[gameManager.CurrentPlayersTurn].Stamina = 7;
				RemoveMessage();
			}

			if(Input.GetKeyDown(KeyCode.R))
			{
				gameManager.Players[gameManager.CurrentPlayersTurn].Thurst = 5;
				RemoveMessage();
			}
		}
		else if(WinButton.gameObject.activeSelf == true)
		{
			if(Input.GetKeyDown(KeyCode.Q))
			{
				Application.LoadLevel(Application.loadedLevelName);
			}
		}
		else if(Weapon.gameObject.activeSelf == true)
		{
			if(Input.GetKeyDown(KeyCode.Q))
			{
				RemoveMessage();
				//Application.LoadLevel(Application.loadedLevelName);
			}
		}



	}

	public void DisplayWeaponMessage(string strTitle, string strMessage, bool isZombie)
	{
		DisplayMessage(strTitle, strMessage);

		if(isZombie == true)
		{
			imagineZom.gameObject.SetActive(true);
		}
		else
		{
			imagineBan.gameObject.SetActive(true);
		}


		Weapon.gameObject.SetActive(true);
	}

	public void DisplayMessage(string strTitle, string strMessage)
	{
		if(gameManager == null)
		{
			gameManager = FindObjectOfType<GameManager>();
			
			if(gameManager == null)
			{
				Debug.LogError("gameManager is not attached in scene");
			}
		}

		Title.text = strTitle;

		TextMessage.text = strMessage;

		gameManager.isPaused = true;

	}
	public void DisplayStartOfTurn()
	{
		DisplayMessage("Start Of Turn","Next player can now can eat food to recover stamina or drink water to recover thirst");

		WaterButton.gameObject.SetActive(true);
		FoodButton.gameObject.SetActive(true);


		this.gameObject.SetActive(true);
	}

	public void DisplayWinningMessage()
	{
		DisplayMessage("Goal", "Do you have the three items you win, press Q to win");

		WinButton.gameObject.SetActive(true);

		this.gameObject.SetActive(true);
	}


	public void RemoveMessage()
	{
		WaterButton.gameObject.SetActive(false);
		FoodButton.gameObject.SetActive(false);
		WinButton.gameObject.SetActive(false);

		Weapon.gameObject.SetActive(false);

		imagineZom.gameObject.SetActive(false);
		imagineBan.gameObject.SetActive(false);

		gameManager.isPaused = false;
		this.gameObject.SetActive(false);


	}

}
