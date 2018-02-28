using UnityEngine;
using System.Collections;

public class WaterEvents :  SquareEvents
{
	override public void TriggerSquare(Vector2 GridPosition, PlayerManager player)
	{
		base.TriggerSquare(GridPosition,player);



		player.Thurst = 6;

		gameManager.RunPopUp("Event", "Thurst Restored");
		//Debug.Log ("Thurst Restored");

	}
}