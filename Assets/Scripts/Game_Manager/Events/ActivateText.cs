using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ActivateText : MonoBehaviour
{
    public TextAsset theText;

    public int startLine;
    public int endLine;

    public TextManager theTextBox;

    public bool destroyAtEnd;

    void Start()
    {
        theTextBox = FindObjectOfType<TextManager>();

    }

    void Update()
    {


    }

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            theTextBox.reloadScript(theText);
            theTextBox.currentLine = startLine;
            theTextBox.endAtLine = endLine;
            theTextBox.enableTextBox();
        }

        if (destroyAtEnd)
        {
            Destroy(gameObject);
        }
    }

}
