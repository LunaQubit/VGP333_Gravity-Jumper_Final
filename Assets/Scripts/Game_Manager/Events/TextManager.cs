using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextManager : MonoBehaviour
{
    public GameObject textBox;

    public Text theText;

    public TextAsset textFile;
    public string[] textLines;

    public int currentLine;
    public int endAtLine;
    public bool isActive;

    private float timer = 0f;

    void Start()
    {
        timer += Time.deltaTime;

        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }
        if(endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }
        if(isActive == true)
        {
            enableTextBox();
        }
        else
        {
            disableTextBox();
        }
    }

    void Update()
    {
            theText.text = textLines[currentLine];
       
        if(!isActive)
        {
            return;
        }
        if(currentLine > endAtLine)
        {
            disableTextBox();
        }
    }

    public void enableTextBox()
    {
        textBox.SetActive(true);
        isActive = true;
    }

    public void disableTextBox()
    {
        textBox.SetActive(false);
        isActive = false;
    }

    public void reloadScript(TextAsset theText)
    {
        if(theText != null)
        {
            textLines = new string[1];
            textLines = (theText.text.Split('\n'));
        }
    }
}
