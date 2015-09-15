using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class testArray : MonoBehaviour
{

    //public GameObject thing;

    public float A;

    public float b;

    public float B
    {
        get
        {
            return b;
        }
        set
        {
            b = value;
            A = value;
        }
    }


    [Range(0.0f, 10.0f)]
    public float mySliderFloat;


    public string[] marcus = { "nasty", "yooby", "holla" };
    public TextMesh thisText;
    public float alpha;
    public Color d;
    public bool isTransparent = false;
    public float current;
    public bool max = true;
    public float newAlphaValue = 1;

    // Use this for initialization

    void Start()
    {
        B = 23;
    }

    //IEnumerator TextFadeOut()



    IEnumerator TextFade(bool choice)
    {
        Debug.Log("wut");

        if (isTransparent == false)
        {
            for (alpha = 1; alpha >= 0f; alpha -= Time.deltaTime)
            {
                d.a = alpha;
                yield return null;
            }

            isTransparent = !isTransparent;
            d.a = 0;
            alpha = 0;
            yield break;
        }


        if (isTransparent == true)
        {
            for (alpha = 0; alpha <= 1f; alpha += Time.deltaTime)
            {
                d.a = alpha;
                yield return null;
            }
            d.a = 1;
            alpha = 1;
            isTransparent = !isTransparent;
            yield break;
        }
        yield break;

    }

    IEnumerator TextFade(float startAlpha, float targetAlpha)
    {

        Debug.Log("union buster!");
        for (float time = 0; time <= 1; time += Time.deltaTime)
        {
            //alpha = Lerpy (startAlpha, targetAlpha, time);
            alpha = Mathf.SmoothStep(startAlpha, targetAlpha, time);
            d.a = alpha;
            yield return null;
        }
        d.a = targetAlpha;
        alpha = targetAlpha;
        yield break;

    }

    float Lerpy(float start, float finish, float t)
    {
        return start + ((finish - start) * t);
    }


    // Update is called once per frame
    void Update()

    

    {
       
        
       b = mySliderFloat;

        if (alpha == 1.0f)
        {
            isTransparent = false;
        }
        if (alpha == 0.0f)
        {

            isTransparent = true;
        }

        if (Input.GetKeyDown("q"))
        {
            Debug.Log("genuwine");
            Debug.Log(marcus[2]);
            thisText.text = (marcus[1]);
        }


        if (Input.GetKeyDown("w"))
        {
            StartCoroutine(TextFade(isTransparent));
        }



        if (Input.GetKeyDown("i"))
        {
            if (isTransparent == false)
            {
                StartCoroutine(TextFade(1, 0));
            }
            else if (isTransparent == true)
            {
                StartCoroutine(TextFade(0, 1));

            }
        }

        if (Input.GetKeyDown("1"))
        {
            Debug.Log("yo");
            isTransparent = !isTransparent;
        }

        d.a = newAlphaValue;

     //   updateAlpha();

       //thisText.color = d;


        if (Input.GetKeyDown("d"))
        {
            Debug.Log("yo, d");
            max = !max;
        }
    }


    
        void updateAlpha()
        {
                if (max)
                {
                    newAlphaValue = Mathf.Lerp(newAlphaValue, 1, Time.deltaTime*3);
                }
                if (!max)
                {
                    newAlphaValue = Mathf.Lerp(newAlphaValue, 0, Time.deltaTime*3);
                }
    }
}