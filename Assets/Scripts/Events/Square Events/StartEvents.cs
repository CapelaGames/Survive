using UnityEngine;
using System.Collections;

public class StartEvents :  SquareEvents
{
	override public void TriggerSquare(Vector2 GridPosition, PlayerManager player)
	{
		base.TriggerSquare(GridPosition,player);

		player.Stamina = 7;
		
		gameManager.RunPopUp("Event", "Restored your stamina");
	}
}