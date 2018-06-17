using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class DragNDrop : MonoBehaviour {

	private Rigidbody2D rb;
	private Collider2D coll;
	private Touch touch;
	private Vector2 touchPos;
	private bool moveAllowed;

	void Start () 
	{
		rb = GetComponent<Rigidbody2D>();
		coll = GetComponent<Collider2D>();
	}
	

	void Update () 
	{
		if(Input.touchCount > 0)
		{
			touch = Input.GetTouch(0);
			touchPos = Camera.main.ScreenToWorldPoint(touch.position);

			if( Physics2D.OverlapPoint(touchPos) != null)
			{
				if(coll.tag == Physics2D.OverlapPoint(touchPos).tag)
				{
					rb.MovePosition(touchPos);
				}
			}
		}
	}
}
