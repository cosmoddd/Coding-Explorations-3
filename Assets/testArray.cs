using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class testArray : MonoBehaviour
{


	public string[] marcus = {"nasty", "yooby", "holla"};
	public TextMesh thisText;
	public float alpha;
	public Color d;
	public bool isTransparent = false;
	public float current;


	// Use this for initialization

	void Start ()
	{
	
	}

	//IEnumerator TextFadeOut()



	IEnumerator TextFade (bool choice)
	{
		Debug.Log ("wut");

		if (isTransparent == false) {
			for (alpha = 1; alpha >= 0f; alpha -= Time.deltaTime) {
				d.a = alpha;
				yield return null;
			}

			isTransparent = ! isTransparent;
			d.a = 0;
			alpha = 0;
			yield break;
		}


		if (isTransparent == true) {
			for (alpha = 0; alpha <= 1f; alpha += Time.deltaTime) {
				d.a = alpha;
				yield return null;
			}
			d.a = 1;
			alpha = 1;
			isTransparent = ! isTransparent;
			yield break;
		}
		yield break;

	}


	IEnumerator TextFade (float startAlpha, float targetAlpha)
	{
		Debug.Log ("union buster!");
		for (float time = 0; time <= 1; time += Time.deltaTime) {
			//alpha = Lerpy (startAlpha, targetAlpha, time);
			alpha = Mathf.SmoothStep (startAlpha, targetAlpha, time); 
			d.a = alpha;
			yield return null;
		}
		d.a = targetAlpha;
		alpha = targetAlpha;
		yield break;
	
	}

	float Lerpy (float start, float finish, float t)
	{
		return start + ((finish - start) * t);
	}
		 


	// Update is called once per frame
	void Update ()
	{

		if (alpha == 1.0f) {
			isTransparent = false;
		}
		if (alpha == 0.0f) {
		
			isTransparent = true;
		}

		if (Input.GetKeyDown ("q")) {
			Debug.Log ("genuwine");
			Debug.Log (marcus [2]);
			thisText.text = (marcus [1]);
		}


		if (Input.GetKeyDown ("w")) {	
			StartCoroutine (TextFade (isTransparent));
		}



		if (Input.GetKeyDown ("i")) {
			if (isTransparent == false) {	
				StartCoroutine (TextFade (1, 0));
			

			} else if (isTransparent == true) {
				StartCoroutine (TextFade (0, 1));

			}
	
		}

		if (Input.GetKeyDown ("1")) {
			Debug.Log ("yo");
			isTransparent = ! isTransparent;
		}

		thisText.color = d;


	}
}