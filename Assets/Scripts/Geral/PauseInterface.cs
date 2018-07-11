using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseInterface : MonoBehaviour {

	public Text[] textos; //[0] --> Horário, [1] --> Atividade
	void Start () 
	{
		textos [0].text = System.DateTime.Now.ToShortTimeString();

		switch (SceneManager.GetActiveScene().name)
		{
		case "OrgAlfabeto":
			textos[1].text = "Alfabeto";
			break;
		case "JogoDaMemoria":
			textos[1].text = "Memoria";
			break;
		case "QuebraCabeça":
			textos[1].text = "Memoria";
			break;
		case "CaçaPalavras":
			textos[1].text = "Palavras";
			break;
		case "Balões":
			textos [1].text = "Letras";
			break;
		case "LigueAsLetrinhas":
			textos [1].text = "Letras";
				break;
		default:
			textos[1].text = "Error 0820";
			break;
		}

	}

	void Update () 
	{
		textos [0].text = System.DateTime.Now.ToShortTimeString();
	}
}
