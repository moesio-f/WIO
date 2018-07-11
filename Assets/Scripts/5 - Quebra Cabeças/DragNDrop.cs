using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class DragNDrop : MonoBehaviour 
{
	private Touch touch;
	private Vector2 touchPos;
	private bool moveAllowed;
	private bool isMoving;	
	private Collider2D coll;
	private RaycastHit2D hit;

	void Update () 
	{
		if(Input.touchCount > 0)
		{
			touch = Input.GetTouch(0);
			touchPos = Camera.main.ScreenToWorldPoint(touch.position);
			moveAllowed = true;
		}
		else
		{
			moveAllowed = false;
		}
	}

	void FixedUpdate()
	{
		if (moveAllowed) 
		{
			hit = Physics2D.Raycast(touchPos, Vector2.zero);
			coll = hit.collider;
			if (coll != null && coll.tag != "Sombra") 
			{
				coll.attachedRigidbody.MovePosition(touchPos);
			}
		}

	}
		
		
}