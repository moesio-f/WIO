using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour 
{
	private Rigidbody2D rigid;

	void Awake() 
	{
		rigid = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate ()
	{
		if(Creator.firstClick.Equals(false))
		{
			rigid.MovePosition(Creator.touchPos);
		}
	}
}
