using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoFade : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(doFade());
    }

   IEnumerator doFade()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime*2;
            yield return new WaitForSeconds(0f);
        }
        canvasGroup.alpha = 1;
        
        yield return null;
    }
}
