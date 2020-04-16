using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScores : MonoBehaviour
{
    public Transform entryContainer;
    public Transform entryTemplate;

    public void populate()
    {
        entryTemplate.gameObject.SetActive(false);

        float templateHeight = 25f;

        // get some vector/array with 5 values

        int size = 5;

        for (int i = 0; i < size; i++)
        {
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -10 - templateHeight * i);
            entryTransform.gameObject.SetActive(true);
            // set text to array(i)
        }
    }

    IEnumerator WaitCoroutine(float x)
    {
        yield return new WaitForSeconds(x);
    }
}
