using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class KeywordsToNotes : MonoBehaviour
{
    public TMP_Text notesText;
    public KeywordSystem keywordSystemRef;
    void Start()
    {
        if (keywordSystemRef != null)
        {
            List<string> keywords = keywordSystemRef.GetKeywords();
            notesText.text = string.Join("\n", keywords.GetRange(1, keywords.Count - 1));
        }
        keywordSystemRef.addNewKeyword.AddListener(UpdateNotes);
    }

    void UpdateNotes()
    {
        if (keywordSystemRef != null)
        {
            List<string> keywords = keywordSystemRef.GetKeywords();
            notesText.text = string.Join("\n", keywords);
        }
    }
    

}
