using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Randomizer : MonoBehaviour 
{

	public Texture[] imagesBack;
	public Texture[] imagesBallons;
	public GameObject[] ballons;
	public int guaranteedLetters;
	public static string[] alfabet = new string[] {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
	public static string[] numbers = new string[] {"0","1", "2", "3", "4", "5", "6", "7", "8", "9"};

	private RawImage rimg;

	void Start () 
	{
		rimg = GetComponent<RawImage>();
		rimg.texture = imagesBack[Random.Range(0, imagesBack.Length)];

		for(int i = 0; i < ballons.Length; i++)
		{
			ballons [i].GetComponent<RawImage> ().texture = imagesBallons[Random.Range(0, imagesBallons.Length)];
		}

		for (int i = 0; i < guaranteedLetters; i++) 
		{
			ballons[i].GetComponentInChildren<Text>().text = alfabet[Random.Range(0, alfabet.Length)];
			BallonsClick.correct++;
		} 

		for(int i = guaranteedLetters; i < ballons.Length; i++)
		{
			if (Random.Range (1, 100) > 85)
			{
				ballons[i].GetComponentInChildren<Text>().text = alfabet [Random.Range (0, alfabet.Length)];
				BallonsClick.correct++;
			}
			else
			{
				ballons[i].GetComponentInChildren<Text>().text = numbers[Random.Range(0, numbers.Length)];
			}
		}

	}

	public static bool AlfabetContain(string a)
	{
		bool b = false;
		for(int i = 0; i < alfabet.Length; i++)
		{
			if(alfabet[i] == a)
			{
				b = true;
			}
		}

		return b;
	}

	public static bool NumberContain(string a)
	{
		bool b = false;
		for(int i = 0; i < numbers.Length; i++)
		{
			if(numbers[i] == a)
			{
				b = true;
			}
		}

		return b;
	}
		
}
