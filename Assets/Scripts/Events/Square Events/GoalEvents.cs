using UnityEngine;
using System.Collections;

public class GoalEvents :  SquareEvents
{
	override public void TriggerSquare(Vector2 GridPosition, PlayerManager player)
	{
		base.TriggerSquare(GridPosition,player);

		gameManager.RunWinningPopUp();
		//Debug.Log ("GoalEvent");
	}
}
