using UnityEngine;
using System.Collections;

 public class SquareEvents : ScriptableObject 
{
	public bool isConsumable = false;
	public bool isConsumed = false;

	public GameManager gameManager;

	virtual public void TriggerSquare(Vector2 GridPosition, PlayerManager player)
	{
		if(gameManager == null)
		{
			gameManager = FindObjectOfType<GameManager>();
			if(gameManager == null)
			{
				Debug.LogError("gameManager is not attached in scene");
				return;
			}
		}

		//Debug.Log ("baseTrigger");
	}
}









