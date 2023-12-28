
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    private int kopilka;
    public string[] lines;
    public float speedText;
    public Text dialogText;
    public GameObject L;

    public int index;

    // Use this for initialization
    void Start()
    {
        index = 0;
        StartDialog();
        L.SetActive(false);
    }

    public void StartDialog()
    {
        L.SetActive(true);
        dialogText.text = string.Empty;
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine()
    {

        foreach (char c in lines[index].ToCharArray())
        {
            dialogText.text += c;
            yield return new WaitForSeconds(speedText);
        }
    }

    public void scipTextClick()
    {
        if (dialogText.text == lines[index])
        {
            NextLines();
        }
        else
        {
            StopAllCoroutines();
            dialogText.text = lines[index];
        }
    }

    public void NextLines()
    {
        if (index < lines.Length - 1)
        {
            index++;
            StartDialog();
        }
        else
        {
             index = 0;
             StartDialog();
            L.SetActive(false);

        }
    }
}