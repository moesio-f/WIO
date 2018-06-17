using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMotion : MonoBehaviour 
{

	public float animation_time;

	void Start () 
	{
		StartCoroutine(NextScene(animation_time, "Orgalfabeto"));
	}
	
	IEnumerator NextScene(float tempo, string next)
	{
		yield return new WaitForSecondsRealtime(tempo + 0.75f);
		UnityEngine.SceneManagement.SceneManager.LoadScene(next);
	}
}
