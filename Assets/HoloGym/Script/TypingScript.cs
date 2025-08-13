using UnityEngine;
using System.Collections;
using TMPro;
using System;
using UnityEngine.UI;

// attach to UI Text component (with the full text already there)

public class TypingScript : MonoBehaviour 
{
    public Text txt;
    string story;

    void Awake()
    {
        //txt = GetComponent<Text>();
    }
    private void Start()
    {
        ChangeText(txt.text, 0.5f);
    }

    //Update text and start typewriter effect
    public void ChangeText(string _text, float _delay = 0f)
    {
        StopCoroutine(PlayText()); //stop Coroutime if exist
        story = _text;
        txt.text = ""; 
        Invoke("Start_PlayText", _delay);
    }

    void Start_PlayText()
    {
        StartCoroutine(PlayText());
    }

    IEnumerator PlayText()
    {
        foreach (char c in story)
        {
            txt.text += c;
            yield return new WaitForSeconds(0.025f);
        }
    }
}
