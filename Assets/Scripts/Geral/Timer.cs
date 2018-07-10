using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

	public int Tempo; //Inteiro que determina o tempo do contador

	private Text text; //Atributo de texto

	void Start () 
	{
		/* Inicialização de variáveis*/
		text = GetComponent<Text>();
		text.text = Tempo.ToString();
		Tempo += CanvasController.panelTime;
	}

	void Update () 
	{
		/*Controle do tempo(Exibição, Derrota e etc) */
		if (Tempo - (int)Time.timeSinceLevelLoad> 0) 
		{
			text.text = (Tempo - (int)Time.timeSinceLevelLoad).ToString();
		}
		else 
		{
			text.text = "Fim do tempo";
		}
		
	}
}
