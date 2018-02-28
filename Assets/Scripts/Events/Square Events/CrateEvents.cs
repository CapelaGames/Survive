using UnityEngine;
using System.Collections;

public class CrateEvents :  SquareEvents
{
	override public void TriggerSquare(Vector2 GridPosition, PlayerManager player)
	{
		base.TriggerSquare(GridPosition,player);
		
		gameManager.RunPopUp("Event", "You can draw a Safe Zone Items if you have a crowbar");
	}
}