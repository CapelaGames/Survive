using UnityEngine;
using System.Collections;

public class RandomEvents :  SquareEvents
{
	EventsManager eventsManager;

	override public void TriggerSquare(Vector2 GridPosition, PlayerManager player)
	{
		base.TriggerSquare(GridPosition,player);

		if(eventsManager == null)
		{
			eventsManager = FindObjectOfType<EventsManager>();
			if(eventsManager == null)
			{
				Debug.LogError("eventsManager is not attached in scene");
				return;
			}
		}

		EventsManager.GridEvents gridEvent = eventsManager.RandomEvent();

		if(gridEvent.LoseStamina > 0 )
		{
			player.Stamina -= gridEvent.LoseStamina;
		}

		if(gridEvent.WeaponUsable == true)
		{
			gameManager.RunPopUpWeapon("Random Event", gridEvent.EventText, gridEvent.isZombies);
		}
		else
		{
			gameManager.RunPopUp("Random Event", gridEvent.EventText);
		}



		eventsManager.squareEventsGrid[(int)GridPosition.x,(int)GridPosition.y] = null;

		isConsumed = true;



	}
}