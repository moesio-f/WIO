using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycasting : MonoBehaviour 
{
	public Vector2 direction;
	public float radius;

	private RaycastHit2D hit;
	private Vector2 origin;
	private Touch touch;


	void Start()
	{
		origin = new Vector2 (transform.position.x, transform.position.y);
	}

	void Update()
	{
		hit = Physics2D.CircleCast(origin, radius, direction);

		if(hit)
		{
			Debug.Log("Tocou hehe");	
		}
	}
}
