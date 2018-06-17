using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEffect : MonoBehaviour 
{
	public string texto;
	public Text targetText;
	public float tempo;

	void Start()
	{
		StartCoroutine(LetterByLetter());
	}


	IEnumerator LetterByLetter()
	{
		foreach(char letter in texto.ToCharArray())
		{
			targetText.text += letter;
			yield return new WaitForSeconds(tempo);
		}
	}
}
