using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballons : MonoBehaviour 
{

	public float speed, finalPosY, posX, startPosY;

	private Rigidbody2D rigid;
	private RectTransform rect;

	void Start () 
	{
		rigid = GetComponent<Rigidbody2D>();
		rect = GetComponent<RectTransform>();
		
		rect.localPosition = new Vector3(posX, startPosY, 0f);
	}

	void FixedUpdate () 
	{
		if((int)Time.timeSinceLevelLoad > (CanvasController.panelTime - 1))
		{
			if (rect.localPosition.y <= finalPosY) 
			{
				Rise ();
			}
			else
			{
				rigid.velocity = Vector2.zero;
			}
		}
	}

	void Rise()
	{
		rigid.velocity = new Vector2(0, speed);
	}
}
