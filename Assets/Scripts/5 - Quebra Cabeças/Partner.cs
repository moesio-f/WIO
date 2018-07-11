using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Partner : MonoBehaviour 
{
	public static int numCorrects;
	public string correct;
	public Texture image;

	void Awake()
	{
		numCorrects = 0;
	}

	void OnTriggerEnter2D(Collider2D a)
	{
		if(a.CompareTag(correct))
		{
			a.transform.position = this.transform.position;
			a.attachedRigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
			this.gameObject.GetComponent<RawImage>().texture = image;
			if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name.Equals("QuebraCabeça2"))
			{
				this.gameObject.GetComponent<RawImage>().color = Color.white;
			}
			Destroy(a.gameObject, 0.05f);
			numCorrects += 1;
		}

		if(numCorrects == 4)
		{
			if (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().name.Equals ("QuebraCabeça"))
			{
				UnityEngine.SceneManagement.SceneManager.LoadScene ("QuebraCabeça2");
			}
			else
			{
				UnityEngine.SceneManagement.SceneManager.LoadScene("JogoDaMemoria");
			}
		}
	}

}
