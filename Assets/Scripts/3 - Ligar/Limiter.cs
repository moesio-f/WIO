using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limiter : MonoBehaviour
{
	public bool alreadyCreated { get; private set;}

	void Start()
	{
		alreadyCreated = false;
	}

	public void SetBool(bool a)
	{
		alreadyCreated = a;
	}
}
