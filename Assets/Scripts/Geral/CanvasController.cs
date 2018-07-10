using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class CanvasController : MonoBehaviour
{
	public static int panelTime;
	public int PanelTime;
	public GameObject panel;
	public GameObject next;
	public GameObject back;
	public GameObject[] vogais;
	public GameObject[] alfabeto;
	public GameObject[] alfabeto2;

	private string sceneName;
	private int count;


	void Awake()
	{
		panelTime = PanelTime;
	}

	void Start()
	{
		count = 0;
		sceneName = SceneManager.GetActiveScene().name;
		
		if(sceneName != "MainMenu" && sceneName != "Ajustes" && sceneName != "Animação" && sceneName != "ConhecendoAsLetrinhas")
		{
			StartCoroutine(Fade(PanelTime));
		}
	}


	/* CONTROLE DE CENAS */

	//Troca de Cena
	public void ChangeScene(string scene)
	{
		SceneManager.LoadScene (scene);
	}

	//Sair do Jogo
	public void Quit()
	{
		Application.Quit();
	}


	/* CONTROLE IN-GAME */

	//Pausa o jogo
	public void Pause(GameObject a)
	{
		Time.timeScale = 0;
		a.SetActive(true);

	}

	//Despausa o jogo
	public void Unpause(GameObject a)
	{
		Time.timeScale = 1;
		a.SetActive(false);
	}

	//Avançar e Esconder - ConhecendoAsLetrinhas
	public void Next()
	{
		if (count.Equals(0)) 
		{
			foreach(GameObject a in vogais)
			{
				a.SetActive(false);
			}
			foreach(GameObject a in alfabeto)
			{
				a.SetActive(true);
			}

			back.SetActive(true);
			count++;
		}
		else if (count.Equals(1)) 
		{
			foreach(GameObject a in alfabeto)
			{
				a.SetActive(false);
			}
			foreach(GameObject a in alfabeto2)
			{
				a.SetActive(true);
			}

			count++;
		}
		else
		{
			ChangeScene("OrgAlfabeto");
		}
	}

	//Voltar e Esconder - ConhecendoAsLetrinhas
	public void Back()
	{
		if (count.Equals(1)) 
		{
			foreach (GameObject a in alfabeto) 
			{
				a.SetActive (false);
			}
			foreach (GameObject a in vogais) 
			{
				a.SetActive (true);
			}

			back.SetActive(false);
			count--;
		}
		else if(count.Equals(2))
		{
			foreach (GameObject a in alfabeto2) 
			{
				a.SetActive (false);
			}
			foreach (GameObject a in alfabeto) 
			{
				a.SetActive (true);
			}

			count--;
		}
	}


	/* CONTROLE DE ÁUDIO */

	//Mutar o som
	public void Mute()
	{
		AudioListener.volume = 0f;
	}

	//Desmutar o som
	public void UnMute()
	{
		AudioListener.volume = 0f;
	}


	/* IENUMERATORS */

	//Fade effect
	IEnumerator Fade(int time)
	{
		yield return new WaitForSeconds(time);
		panel.SetActive(false);
	}

}
