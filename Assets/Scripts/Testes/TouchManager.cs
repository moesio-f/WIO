using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchManager : MonoBehaviour 
{
	private Touch touch;
	private RaycastHit2D hit;

	void Update()
	{
		if(Input.touchCount > 0)
		{
			Debug.Log("Touching");
			touch = Input.GetTouch(0);
			hit = Physics2D.CircleCast(touch.position, touch.radius*1.5f, Vector2.zero);
			Debug.Log(hit.point);
			if(hit)
			{
				Debug.Log("Wow");
				hit.collider.transform.position = touch.position;
			}
		}
	}
}
