using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventSquarePlacer : MonoBehaviour 
{
	BoardManager boardManager;
	EventsManager eventsManager;

	public Transform objectToPlace;

	public Transform[,] objectArray;
	/*
	void Start()
	{
		eventsManager = FindObjectOfType<EventsManager>();
		if(eventsManager == null)
		{
			Debug.LogError("eventsManager is not attached in scene");
		}
		
		boardManager = FindObjectOfType<BoardManager>();
		if(boardManager == null)
		{
			Debug.LogError("boardManager is not attached in scene");
		}


		objectArray = new Transform[(int)boardManager.GridSize.x, (int)boardManager.GridSize.y];

		for(int x = 0; x < (int)boardManager.GridSize.x; x++)
		{
			for(int y = 0; y < (int)boardManager.GridSize.y ; y++)
			{
				//Debug.Log( x + " " + y );
				objectArray[x,y] = (Transform)Instantiate(objectToPlace);
			}
		}
	}*/
	/*
	void Update()
	{
		for(int x = 0; x <  (int)boardManager.GridSize.x; x++)
		{
			for(int y = 0; y <  (int)boardManager.GridSize.y; y++)
			{
				objectArray[x,y].gameObject.SetActive(false);
				if(eventsManager.squareEventsGrid[x,y] != null)
				{

					if(eventsManager.squareEventsGrid[x,y].isConsumable == true
					   && eventsManager.squareEventsGrid[x,y].isConsumed == false)
					{
						//objectArray[x,y]
						SetPosition(new Vector2(x,y),objectArray[x,y]);
					}
				}
			}
		}

	}*/


	public void SetPosition(Vector2 gridPosition, Transform gameObjectToPlace)
	{
		gameObjectToPlace.position = boardManager.GetCenterOfPosition(gridPosition);
		gameObjectToPlace.gameObject.SetActive(true);

		
		//gameObjectToPlace.transform = gridPosition;
		//Debug.Log(gridPosition);
	}
}
