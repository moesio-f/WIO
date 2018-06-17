using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterGenerator : MonoBehaviour 
{

	public static string ordem_correta { get; private set; }
	public static Button[] buttons_static {get; private set; }

	private Button[] buttons;
	private string[] letras_alfabeto; 
	private int aux_int_button;
	private int aux_int_alfabeto;

	void Start()
	{
		ordem_correta = " ";
		letras_alfabeto = new string[] {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
		buttons = GetComponentsInChildren<Button>();
		buttons_static = buttons;

		aux_int_button = Random.Range(0, (buttons.Length - 1));
		aux_int_alfabeto = Random.Range(0, (letras_alfabeto.Length - (buttons.Length + 1)));

		buttons[aux_int_button].GetComponentInChildren<Text>().text = letras_alfabeto[aux_int_alfabeto];
		ordem_correta += letras_alfabeto [aux_int_alfabeto];
		aux_int_alfabeto++;

		for(int i = 0; i < buttons.Length; i++)
		{
			if(i != aux_int_button)
			{
				buttons[i].GetComponentInChildren<Text>().text = letras_alfabeto[aux_int_alfabeto];
				ordem_correta += " " + letras_alfabeto [aux_int_alfabeto];
				aux_int_alfabeto++;
			}
		}

		Debug.Log(ordem_correta);
	}
}
