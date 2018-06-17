using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Partner : MonoBehaviour 
{
	public static int numCorrects;
	public string correct;
	
	void OnTriggerEnter2D(Collider2D a)
	{
		if(a.CompareTag(correct))
		{
			a.transform.position = this.transform.position;
			a.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
			numCorrects += 1;
		}

		if(numCorrects == 4)
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("JogoDaMemoria");
		}
	}

}
