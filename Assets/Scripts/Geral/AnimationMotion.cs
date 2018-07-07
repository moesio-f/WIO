using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMotion : MonoBehaviour 
{

	public float animation_time;
	public string next_scene;

	void Start () 
	{
		StartCoroutine(NextScene(animation_time, next_scene));
	}
	
	IEnumerator NextScene(float tempo, string next)
	{
		yield return new WaitForSecondsRealtime(tempo + 0.75f);
		UnityEngine.SceneManagement.SceneManager.LoadScene(next);
	}
}
