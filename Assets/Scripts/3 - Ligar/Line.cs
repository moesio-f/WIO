using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour 
{
	private LineRenderer lrenderer;

	void Start ()
	{
		lrenderer = GetComponent<LineRenderer>();
		lrenderer.useWorldSpace = true;
		lrenderer.material = Creator.definitive;
		

	}

	void FixedUpdate () 
	{
		if(Time.time - GetComponentInParent<AutoDestroy>().timeCreated > 0.10f)
		{
			lrenderer.SetPosition(0, GetComponentInParent<AutoDestroy>().firstPos);
			lrenderer.SetPosition(1, GetComponentInParent<AutoDestroy>().PositionNow());
		}
	}
}
