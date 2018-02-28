using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour 
{
	BoardManager boardManager;
	GameManager gameManager;
	EventsManager eventsManager;

	public Text playerStepsText;
	public int StepsLeft = 0;

	public Vector2 CurrentGridPosition = Vector2.zero;

	public Text playerThurstText;
	public int Thurst = 5;
	public Text playerStaminaText;
	public int Stamina = 7;


	public float xOffset = 0;
	public float yOffset = 0;

	public string playerName = "Player";

	public enum MoveDirection
	{
		Up,Down,Left,Right
	}

	public void Start()
	{
		boardManager = FindObjectOfType<BoardManager>();

		if(boardManager == null)
		{
			Debug.LogError("boardManager is not attached in scene");
		}

		gameManager = FindObjectOfType<GameManager>();

		if(gameManager == null)
		{
			Debug.LogError("gameManager is not attached in scene");
		}

		eventsManager = FindObjectOfType<EventsManager>();
		
		if(eventsManager == null)
		{
			Debug.LogError("eventsManager is not attached in scene");
		}


		SetPosition(CurrentGridPosition);

		StartCoroutine(InputLoop());
	}

	public void Update()
	{
		playerStepsText.text = StepsLeft.ToString();
		playerThurstText.text = Thurst.ToString();
		playerStaminaText.text = Stamina.ToString();


	}

	public void SetPosition(Vector2 gridPosition)
	{
		Vector3 position  = boardManager.GetCenterOfPosition(gridPosition);


		position.x += xOffset;
		position.y += yOffset;
		gameObject.transform.position = position;

		CurrentGridPosition = gridPosition;
		//Debug.Log(gridPosition);
	}

	IEnumerator InputLoop()
	{
		while(true)
		{
			if(gameManager.isPaused == false)
			{
				if(StepsLeft > 0)
				{
					if(Input.GetKeyDown(KeyCode.W))
					{
						MovePosition(MoveDirection.Up);
						//Debug.Log("W");
					}
					if(Input.GetKeyDown(KeyCode.S))
					{
						MovePosition(MoveDirection.Down);

						//Debug.Log("S");
					}
					if(Input.GetKeyDown(KeyCode.A))
					{
						MovePosition(MoveDirection.Left);

					}
					if(Input.GetKeyDown(KeyCode.D))
					{
						MovePosition(MoveDirection.Right);

						//Debug.Log("D");
					}

					if(StepsLeft <=0)
					{
						yield return 0;
						EndTurn();

					}
				}
			}
			yield return 0;
		}
	}

	void EndTurn()
	{
		TriggerEvent(CurrentGridPosition);

		if(Thurst <= 0)
		{
			Stamina--;
		}
		else
		{
			Thurst--;
		}

		if(Stamina == 0)
		{
			Debug.Log("Player Dead");
		}
		
		gameManager.NextPlayerTurn();
	}

	public void MovePosition(MoveDirection moveDirection)
	{
		Vector2 NewMove = CurrentGridPosition;


		switch(moveDirection)
		{
		case MoveDirection.Up:

			if(NewMove.y + 1 <= boardManager.GridSize.y)
			{
				NewMove.y++;
				SetPosition(NewMove);
				StepsLeft--;
			}
			break;
		case MoveDirection.Down:
			if(NewMove.y -1 > 0)
			{
				NewMove.y--;
				SetPosition(NewMove);
				StepsLeft--;
			}
			break;
		case MoveDirection.Left:

			if(NewMove.x -1 > 0)
			{
				NewMove.x--;
				SetPosition(NewMove);
				StepsLeft--;
			}
			break;
		case MoveDirection.Right:
			if(NewMove.x + 1 <= boardManager.GridSize.x)
			{
				NewMove.x++;
				SetPosition(NewMove);
				StepsLeft--;
			}
			break;
		}

	//	playerStepsText.text = StepsLeft.ToString();

	}


	void TriggerEvent(Vector2 GridPosition)
	{
		if(eventsManager.squareEventsGrid[(int)GridPosition.x,(int)GridPosition.y] != null)
		{
			eventsManager.squareEventsGrid[(int)GridPosition.x,(int)GridPosition.y].TriggerSquare(GridPosition, this);
		}
	}
}
