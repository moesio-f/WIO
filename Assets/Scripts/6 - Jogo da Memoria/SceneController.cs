using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {

	public int correct;

	private int count;
	private const int numMaxObjFliped = 2;
	private int atualNumObjFliped;
	private GameObject[] objsFliped = new GameObject[numMaxObjFliped];

	void Start () 
	{
		atualNumObjFliped = 0;
	}

	public void AddOneFliped(GameObject a)
	{
		if(atualNumObjFliped < numMaxObjFliped)
		{
			objsFliped[atualNumObjFliped] = a;
			objsFliped [atualNumObjFliped].GetComponent<Animator>().Play("Cardflip");
			atualNumObjFliped++;
		}

	}

	public void Check()
	{
		Debug.Log(atualNumObjFliped);

		if(atualNumObjFliped.Equals(numMaxObjFliped))
		{
			if (Correct(objsFliped))
			{
				StartCoroutine(WaitTime(0.75f, true));
			}
			else
			{
				StartCoroutine(WaitTime(0.75f, false));
			}
		}

		if(count.Equals(correct))
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
		}
	}

	bool Correct(GameObject[] a)
	{

		if (a[0].CompareTag (a[1].tag)) 
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	IEnumerator WaitTime(float time, bool a)
	{
		yield return new WaitForSeconds(time);

		if(a) 
		{
			count++;
			Destroy(objsFliped[0]);
			Destroy(objsFliped[1]);
			atualNumObjFliped = 0;
		}
		else
		{
			objsFliped[0].GetComponent<Animator>().Play("Cardunflip");
			objsFliped[1].GetComponent<Animator>().Play("Cardunflip");
			atualNumObjFliped = 0;
		}
	}
}
