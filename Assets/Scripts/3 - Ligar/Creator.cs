using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour
{

	public GameObject prefab;
	public Material[] material; //0 - Azul; 1 - Rosa; 2 - Laranja; 3 - Verde;

	public static Touch touch{ get; private set;}
	public static Vector2 touchPos{ get; private set; }
	public static bool firstClick { get; private set; }
	public static Material definitive;

	private static int numberOfInstances;

	void Update () 
	{
		if(Input.touchCount > 0)
		{
			touch = Input.GetTouch(0);
			touchPos = Camera.main.ScreenToWorldPoint(touch.position);
			if (touch.phase.Equals(TouchPhase.Began)) 
			{
				firstClick = true;
			}
			else 
			{
				firstClick = false;
			}
		}

	}

	void FixedUpdate()
	{
		if(firstClick)
		{
			Collider2D a = Physics2D.OverlapPoint(touchPos);
			if(a != null && a.isTrigger.Equals(false) && a.gameObject.GetComponent<Limiter>().alreadyCreated.Equals(false))
			{
				Instantiate(prefab, touchPos, Quaternion.identity);
				a.gameObject.GetComponent<Limiter>().SetBool(true);
				switch(a.gameObject.name)
				{
				case "Rosa":
					definitive = material [1];
					break;
				case "Azul":
					definitive = material [0];
					break;
				case "Verde":
					definitive = material [3];
					break;
				case "Laranja":
					definitive = material [2];
					break;
				}
			}
		} 
	}
				
}
