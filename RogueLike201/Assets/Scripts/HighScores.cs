using System.Collections;
using UnityEngine;
using Final_Project_Client;
using TMPro;

public class HighScores : MonoBehaviour
{
    public Transform entryContainer;
    public Transform entryTemplate;

    public void populate()
    {
        entryTemplate.gameObject.SetActive(false);

        float templateHeight = 25f;

        Client client = new Client(9999);

        ArrayList[] highScores = client.getHighScores();
        // stringArray.Select(Int32.Parse).ToList();
        // get some vector/array with 5 values

        int size = highScores[0].Count;

        for (int i = 0; i < size; i++)
        {
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -10 - templateHeight * i);
            entryTransform.gameObject.SetActive(true);
            entryTransform.Find("UserEntry").GetComponent<TextMeshProUGUI>().text = (string)highScores[0][i];
            entryTransform.Find("ScoreEntry").GetComponent<TextMeshProUGUI>().text = highScores[1][i].ToString();
            Debug.Log(highScores[0][i] + " " + highScores[1][i]);
        }
    }

    IEnumerator WaitCoroutine(float x)
    {
        yield return new WaitForSeconds(x);
    }
}
