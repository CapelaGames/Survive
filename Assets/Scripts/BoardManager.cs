using UnityEngine;
using System.Collections;

public class BoardManager : MonoBehaviour 
{
	//Board Stats
	public Vector2 GridSize =  new Vector2 (2.0f,2.0f);

	public float GridOffset = 0f;

	public Vector3 GetCenterOfPosition(Vector2 gridPosition)
	{
		float maxy = collider2D.bounds.max.y;
		float miny = collider2D.bounds.min.y;

		float diffy = maxy - miny;

		float yGap = diffy / (GridSize.y + GridOffset);


		float maxx = collider2D.bounds.max.x;
		float minx = collider2D.bounds.min.x;
		
		float diffx = maxx - minx;
		
		float xGap = diffx / (GridSize.x+GridOffset);


		Vector3 ReturnPosition = collider2D.bounds.min;
		ReturnPosition.x += (xGap * gridPosition.x);
		ReturnPosition.y += (yGap * gridPosition.y);

		return ReturnPosition;
	}




}
