using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlfabetOrg : MonoBehaviour 
{

	public int buttons_num; //Quantiadde de botões

	private string letra; //Letra do botão
	private Text alfabeto; //Elemento texto 
	private int count; // Quantidade de vezes que os botões foram pressionados


	/*Inicialização*/
	void Start()
	{
		alfabeto = GetComponent<Text>(); //Instancia o objeto

		/*Inicialização de variáveis*/
		alfabeto.text = "";
		letra = "";
		count = 0; 
	}

	/*Metódos para alteração de texto e botões*/
	public void AddLetter(GameObject a) // Metódo para realizar a ação de por a letra no texto
	{
		if(a.GetComponent<RectTransform>().localScale.x > 0f)
		{
			letra = a.GetComponent<Text>().text;
			StartCoroutine(SetAlfabet());
			count++;
			if(count == buttons_num)
			{
				Debug.Log(alfabeto.text);
				if(alfabeto.text == LetterGenerator.ordem_correta)
				{
					UnityEngine.SceneManagement.SceneManager.LoadScene("Balões");
				}
			}
		}

		a.GetComponent<RectTransform>().localScale = new Vector3(0f,0f,0f);
	}

	public void Reset() // Metódo para resetar o texto e as letras
	{
		for(int i = 0; i < buttons_num; i++)
		{
			LetterGenerator.buttons_static [i].GetComponentInChildren<Text> ().GetComponent<RectTransform>().localScale = new Vector3(1f,1f,1f);
			alfabeto.text = "";
			count = 0;
		}
	}

	IEnumerator SetAlfabet() // Metódo para alterar os botões e a string de letra
	{
		alfabeto.text += " " + letra;
		yield return new WaitForEndOfFrame();
		letra = "";
	}
}
