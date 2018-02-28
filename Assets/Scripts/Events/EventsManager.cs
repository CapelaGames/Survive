using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventsManager : MonoBehaviour 
{
	BoardManager boardManager;

	public SquareEvents[,] squareEventsGrid;






	public class GridEvents
	{
		//public string EventName;
		public string EventText;
		public int LoseStamina;
		public bool WeaponUsable = false;
		public bool isZombies = false;

	}

	public List<GridEvents> EventsInGame;

	void Start()
	{
		boardManager = FindObjectOfType<BoardManager>();
		
		if(boardManager == null)
		{
			Debug.LogError("boardManager is not attached in scene");
		}

		EventsInGame = new List<GridEvents>();

		GridEvents AddingEvent;

		AddingEvent = new GridEvents();
		//AddingEvent.EventName = "test";
		AddingEvent.EventText = "You have been attacked by a zombie. Lose 1 stamina";
		AddingEvent.LoseStamina = 1;
		AddingEvent.WeaponUsable = true;
		AddingEvent.isZombies = true;
		EventsInGame.Add(AddingEvent);

		AddingEvent = new GridEvents();
		//AddingEvent.EventName = "test";
		AddingEvent.EventText = "You struggle desperately with a small group of the living dead. Lose 2 stamina Draw 1 event card";
		AddingEvent.LoseStamina = 2;
		AddingEvent.WeaponUsable = true;
		AddingEvent.isZombies = true;
		EventsInGame.Add(AddingEvent);


		AddingEvent = new GridEvents();
		//AddingEvent.EventName = "test";
		AddingEvent.EventText = "A zombie horde has gained your scent and is bearing down on you. Lose 3 stamina Draw 2 event card";
		AddingEvent.LoseStamina = 3;
		AddingEvent.WeaponUsable = true;
		AddingEvent.isZombies = true;
		EventsInGame.Add(AddingEvent);


		AddingEvent = new GridEvents();
		//AddingEvent.EventName = "test";
		AddingEvent.EventText = "A lone bandit confronts you. Lose 1 stamina";
		AddingEvent.LoseStamina = 1;
		AddingEvent.WeaponUsable = true;
		EventsInGame.Add(AddingEvent);


		AddingEvent = new GridEvents();
		//AddingEvent.EventName = "test";
		AddingEvent.EventText = "Ambushed by a band of thugs, you escape, barely. Lose 2 stamina Draw 1 event card";
		AddingEvent.LoseStamina = 2;
		AddingEvent.WeaponUsable = true;
		EventsInGame.Add(AddingEvent);

		AddingEvent = new GridEvents();
		//AddingEvent.EventName = "test";
		AddingEvent.EventText = "A raiding party has spotted you. Lose 3 stamina Draw 2 event card";
		AddingEvent.LoseStamina = 3;
		AddingEvent.WeaponUsable = true;
		EventsInGame.Add(AddingEvent);


		//NO COUNTERS FOR BELOW

		AddingEvent = new GridEvents();
		//AddingEvent.EventName = "test";
		AddingEvent.EventText = "A petty thief has snuck into your camp over night. Discard 1 event item";
		EventsInGame.Add(AddingEvent);


		AddingEvent = new GridEvents();
		//AddingEvent.EventName = "test";
		AddingEvent.EventText = "A starving wolf hounds you. Discard 2 event items";
		EventsInGame.Add(AddingEvent);

		AddingEvent = new GridEvents();
		//AddingEvent.EventName = "test";
		AddingEvent.EventText = "A trap left by a hunter snares you. Abandon 1 safe zone > Place item into safe zone draw pile and shuffle";
		EventsInGame.Add(AddingEvent);

		AddingEvent = new GridEvents();
		//AddingEvent.EventName = "test";
		AddingEvent.EventText = "Get lost and stumble into a toxic waste dump. Abandon 1 safe zone > Place item into safe zone draw pile and shuffle.";
		EventsInGame.Add(AddingEvent);


		AddingEvent = new GridEvents();
		AddingEvent.EventText = "Someone had to leave their campsite in a hurry. Draw 1 event card";
		EventsInGame.Add(AddingEvent);


		AddingEvent = new GridEvents();
		//AddingEvent.EventName = "test";
		AddingEvent.EventText = "Your scavenging of an abandoned gas station proves fruitful. Draw 2 event cards";
		EventsInGame.Add(AddingEvent);



		AddingEvent = new GridEvents();
		//AddingEvent.EventName = "test";
		AddingEvent.EventText = "Found a hidden cache. Draw 3 event cards";
		EventsInGame.Add(AddingEvent);

		AddingEvent = new GridEvents();
		//AddingEvent.EventName = "test";
		AddingEvent.EventText = "Contemplate the desolate wasteland before you. Continue";
		EventsInGame.Add(AddingEvent);

		AddingEvent = new GridEvents();
		//AddingEvent.EventName = "test";
		AddingEvent.EventText = "A wrecked family sedan rests beside the road, you find nothing but sadness. Continue";
		EventsInGame.Add(AddingEvent);


		AddingEvent = new GridEvents();
		//AddingEvent.EventName = "test";
		AddingEvent.EventText = "A ravenous horde passes nearby. Continue";
		EventsInGame.Add(AddingEvent);


		SetUpGrid();
	}


	public GridEvents RandomEvent()
	{
		int RandomEventIndex = Random.Range(0, EventsInGame.Count);


		GridEvents returnEvent = EventsInGame[RandomEventIndex];



		//EventsInGame.RemoveAt(RandomEventIndex);
		return returnEvent;
	}	




	public void SetUpGrid()
	{
		squareEventsGrid = new SquareEvents[(int)boardManager.GridSize.x + 1,(int)boardManager.GridSize.y + 1];


		SetUpWaterGrids();
		SetUpGoalGrids();
		SetUpCrateGrids();

		SetUpStartGrids();

		SetUpRandomGrids();
	}

	public void SetUpWaterGrids()
	{
		WaterEvents waterEvent = ScriptableObject.CreateInstance("WaterEvents") as WaterEvents;

		squareEventsGrid[2,7] = waterEvent;
		squareEventsGrid[7,2] = waterEvent;
		squareEventsGrid[18,6] = waterEvent;
		squareEventsGrid[13,11] = waterEvent;

	}

	public void SetUpCrateGrids()
	{
		CrateEvents crateEvent = ScriptableObject.CreateInstance("CrateEvents") as CrateEvents;
		
		squareEventsGrid[4,5] = crateEvent;
		squareEventsGrid[6,10] = crateEvent;
		squareEventsGrid[16,8] = crateEvent;
		squareEventsGrid[14,3] = crateEvent;
		
	}

	public void SetUpStartGrids()
	{
		StartEvents startEvents = ScriptableObject.CreateInstance("StartEvents") as StartEvents;

		squareEventsGrid[9,7] = startEvents;
		//squareEventsGrid[9,6] = startEvents;
		//squareEventsGrid[11,7] = startEvents;
		squareEventsGrid[11,6] = startEvents;
		
	}

	public void SetUpGoalGrids()
	{
		GoalEvents goalEvents = ScriptableObject.CreateInstance("GoalEvents") as GoalEvents;
		
		squareEventsGrid[2,11] = goalEvents;
		squareEventsGrid[2,2] = goalEvents;
		squareEventsGrid[18,2] = goalEvents;
		squareEventsGrid[18,11] = goalEvents;
		
	}

	public void SetUpRandomGrids()
	{
		RandomEvents randomEvent;
		
		for(int x = 2; x <  boardManager.GridSize.x ; x++)
		{
			for(int y = 2; y <  boardManager.GridSize.y ; y++)
			{
				if(squareEventsGrid[x,y] == null)
				{
					randomEvent = ScriptableObject.CreateInstance("RandomEvents") as RandomEvents;
					randomEvent.isConsumable = true;

					squareEventsGrid[x,y] = randomEvent;
				}
			}
		}
		
	}
}
