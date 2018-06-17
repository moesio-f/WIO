using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class CanvasController : MonoBehaviour
{
	public static int panelTime;

	public GameObject panel;
	public int PanelTime;

	private string sceneName;

	void Awake()
	{
		panelTime = PanelTime;
	}

	void Start()
	{
		sceneName = SceneManager.GetActiveScene().name;
		
		if(sceneName != "MainMenu" && sceneName != "Ajustes" && sceneName != "Animação")
		{
			StartCoroutine(Fade(PanelTime));
		}
	}
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

	IEnumerator Fade(int time)
	{
		yield return new WaitForSeconds(time);
		panel.SetActive(false);
	}
}
