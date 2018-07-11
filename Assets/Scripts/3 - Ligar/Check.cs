using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour 
{
	public static int numCorrects { get; private set;}
	public static int clickeds { get; private set;}
	public GameObject[] anotherObjs, result; // For result.. [0] = Wrong, [1] = Correct
	public bool correct;
	public GameObject[] warn;

	private int count = 0;

	void OnTriggerEnter2D(Collider2D a)
	{ 
		if(count.Equals(0))
		{
			a.GetComponentInParent<AutoDestroy>().TurCorrect();	
			a.attachedRigidbody.position = this.gameObject.GetComponentInChildren<RectTransform>().position;
			a.attachedRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
			count++;
			clickeds++;

			if(Physics2D.OverlapPoint(a.GetComponentInParent<AutoDestroy>().firstPos).CompareTag(this.gameObject.tag))
			{
				numCorrects++;
				correct = true;
			}

			if (numCorrects.Equals(4)) 
			{
				for(int i = 0; i < warn.Length; i++)
				{
					warn[i].SetActive(false);
				}

				StartCoroutine (Correct());
			}
			else if(clickeds.Equals(4))
			{
				StartCoroutine(Wrong());
			}

		}
	}

	IEnumerator Correct()
	{
		StartCoroutine(ShowResults());
		yield return new WaitForSeconds(0.35f*anotherObjs.Length);
		yield return new WaitForSeconds(0.75f);
		UnityEngine.SceneManagement.SceneManager.LoadScene("CaçaPalavras");
	}

	IEnumerator Wrong()
	{
		StartCoroutine(ShowResults());
		yield return new WaitForSeconds(0.35f*anotherObjs.Length);
		for(int i = 0; i < warn.Length; i++)
		{
			warn[i].SetActive(true);
		}
		yield return null;
	}

	IEnumerator ShowResults()
	{
		for(int i = 0; i < anotherObjs.Length; i++)
		{
			if (anotherObjs [i].GetComponent<Check> ().correct) 
			{
				anotherObjs [i].GetComponent<Check> ().Show ("Correto");
			}
			else 
			{
				anotherObjs [i].GetComponent<Check> ().Show ("Errado");
			}

			yield return new WaitForSeconds(0.35f);
		}
	}


	void Show(string a)
	{
		if (a.Equals ("Correto")) 
		{
			result[1].SetActive (true);
		}
		else 
		{
			result[0].SetActive (true);
		}
	}

	public static void ResetStatics()
	{
		clickeds = 0;
		numCorrects = 0;
	}
}
