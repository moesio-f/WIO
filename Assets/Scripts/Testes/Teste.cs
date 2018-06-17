using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste : MonoBehaviour {

	private Touch touch;
	private Vector2 touchPos;
	// Update is called once per frame
	void Update () 
	{
		if(Input.touchCount > 0)
		{
			touch = Input.GetTouch(0);
			touchPos = Camera.main.ScreenToWorldPoint(touch.position);
			if(GetComponent<BoxCollider2D>() == Physics2D.OverlapPoint(touchPos))
			{
				transform.position = touchPos;
			}
		}
	}
}
