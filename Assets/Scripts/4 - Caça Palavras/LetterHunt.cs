using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterHunt : MonoBehaviour 
{
	public static int numCorrects;
	
	public Texture correct;
	public GameObject[] allObjs;

	private bool onCoroutine;

	public void Clicked(GameObject thisObj)
	{
		if(onCoroutine.Equals(false))
		{
			if (thisObj.GetComponentInChildren<RawImage>().texture.Equals(correct)) 
			{
				StartCoroutine (TurnColor (thisObj, Color.green, true));
				StartCoroutine (DeleteOther(thisObj));
				thisObj.GetComponent<Button>().interactable = false;
				numCorrects++;

			}
			else
			{
				StartCoroutine(TurnColor(thisObj, Color.red, false));
			}
		}
	}

	IEnumerator TurnColor(GameObject a, Color b, bool perma, float time = 1.25f)
	{
		Color aux;
		onCoroutine = true;

		if (perma)
		{
			a.GetComponent<Image>().color = b;
			onCoroutine = false;
		}
		else
		{
			aux = a.GetComponent<Image>().color;
			a.GetComponent<Image>().color = b;
			yield return new WaitForSeconds(time);
			a.GetComponent<Image>().color = aux;
			onCoroutine = false;
		}
	}

	IEnumerator DeleteOther(GameObject excpet)
	{
		Color aux;
		Color auxC;
		onCoroutine = true;

		foreach(GameObject a in this.allObjs)
		{
			if(a != excpet)
			{
				for(int i = 0; i < 2; i++)
				{
					aux = a.GetComponent<Image>().color;
					auxC = a.GetComponentInChildren<RawImage>().color;

					a.GetComponent<Image>().color = Color.clear;
					a.GetComponentInChildren<RawImage>().color = Color.clear;

					yield return new WaitForSeconds(0.25f);

					a.GetComponent<Image>().color = aux;
					a.GetComponentInChildren<RawImage>().color = auxC;

					yield return new WaitForSeconds(0.25f);
				}

				onCoroutine = false;
				Destroy(a);
			}
		}

		if(numCorrects.Equals(2))
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("QuebraCabeça");
		}
	}
}
