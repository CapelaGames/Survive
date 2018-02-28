using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour 
{
	public List<PlayerManager> Players;
	//public PlayerManager[] Players;



	public int StepsPerTurn;
	public int CurrentPlayersTurn = -1;

	//public int DeckCardsRemaining;

	public bool isPaused = false;

	public PopUp popUp;

	public bool isWaitingForStartMessage = false;

	//public bool isWaitingPlayerDead = false;

	public void Start()
	{

		NextPlayerTurn();

		//RunPopUp("sudhsf","dsfdsf");

	}

	public void Update()
	{


		if(isPaused == false)
		{
			int DeadPlayer = -1;



			for( int x = 0; x < Players.Count; x++ )
			{
				PlayerManager player = Players[x];
				if(player.Stamina <= 0)
				{
					RunPopUp(player.playerName + " has died", "Respawning");
					DeadPlayer = x;
					break;
				}
			}

			if(DeadPlayer != -1)
			{
				Players[DeadPlayer].SetPosition(new Vector2(9,7));

				Players[DeadPlayer].Stamina = 7;
				Players[DeadPlayer].Thurst = 5;
				//Players.RemoveAt(DeadPlayer);

				/*
				if(DeadPlayer >= CurrentPlayersTurn)
				{
					CurrentPlayersTurn--;
				}*/


			}

		}

		if(isPaused == false && isWaitingForStartMessage == true)
		{
			isWaitingForStartMessage = false;
			popUp.DisplayStartOfTurn();
		}
	}

	public void RunPopUp(string title, string message)
	{
		popUp.gameObject.SetActive(true);

		popUp.DisplayMessage(title,message);
	}


	public void RunPopUpWeapon(string title, string message, bool isZombie)
	{
		popUp.gameObject.SetActive(true);

		
		popUp.DisplayWeaponMessage(title,message, isZombie);
	}


	public void RunWinningPopUp()
	{
		popUp.gameObject.SetActive(true);
		popUp.DisplayWinningMessage();
	}

	public void NextPlayerTurn()
	{
		if(CurrentPlayersTurn == Players.Count - 1)
		{
			CurrentPlayersTurn = 0;
		}
		else
		{
			CurrentPlayersTurn++;
		}
	
		Players[CurrentPlayersTurn].StepsLeft = StepsPerTurn;

		isWaitingForStartMessage = true;

	}

}
