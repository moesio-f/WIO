using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour {

	public bool notCorrect = true;
	public Vector2 firstPos{ get; private set;}
	public float timeCreated{ get; private set;}

	private Vector2 aux;

	void Awake()
	{
		firstPos = this.transform.position;
		timeCreated = Time.time;

	}

	void Update()
	{
		if (Creator.touch.phase == TouchPhase.Ended && notCorrect) 
		{
			aux = this.transform.position;
			if(firstPos == aux)
			{
				this.transform.localScale = Vector3.zero;
				this.transform.position += new Vector3(100,100,100);
			}

			Physics2D.OverlapPoint(firstPos).gameObject.GetComponent<Limiter>().SetBool (false);
			Destroy (this.gameObject);
		}
	}

	public void TurCorrect()
	{
		notCorrect = false;
	}

	public Vector2 PositionNow()
	{
		return GetComponentInChildren<Rigidbody2D>().position;
	}
}
