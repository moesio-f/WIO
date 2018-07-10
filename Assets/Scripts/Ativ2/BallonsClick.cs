using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallonsClick : MonoBehaviour 
{
	public static int correct;

	public Text txt;
	public RawImage image;
	public float time;
	public Texture certo, errado;
	public GameObject opacity;

	private int count;

	public void Click(GameObject thisButton)
	{
		StopAllCoroutines();
		if (Randomizer.AlfabetContain(thisButton.GetComponentInChildren<Text>().text))
		{
			StartCoroutine(Display ("CORRETO", Color.green, time));
			count++;
			Destroy(thisButton, time);
		}

		else
		{
			StartCoroutine(Display ("ERRADO", Color.red, time));
		}

		if(count.Equals(correct))
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("LigueAsLetrinhas");
		}
	}

	IEnumerator Display(string a, Color b,float time)
	{
		if (a.Equals ("CORRETO")) 
		{
			image.texture = certo;
		}
		else
		{
			image.texture = errado;
		}

		txt.gameObject.SetActive(true);
		image.gameObject.SetActive(true);
		opacity.SetActive (true);
		txt.color = b;
		txt.text = a;

		yield return new WaitForSeconds(time);

		txt.gameObject.SetActive(false);
		image.gameObject.SetActive(false);
		opacity.SetActive (false);
	}
}
