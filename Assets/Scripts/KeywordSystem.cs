using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeywordSystem : MonoBehaviour
{
    public List<string> listOfKeywords = new List<string>();
    public static KeywordSystem Instance;
    public UnityEvent addNewKeyword;
    // Adds and instance of the keyword system and creates an empt ylist of keywords.
    void Awake()
    {
        Instance = this; // Instancing this script
        listOfKeywords.Add("Choose a keyword");
    }

    public void AddKeyword(string keyword)
    {
        if (!listOfKeywords.Contains(keyword))
        {
            listOfKeywords.Add(keyword);
            addNewKeyword.Invoke();
        }
    } // Adds keywords to the list if they aren't there already

    public List<string> GetKeywords()
    {
        return listOfKeywords; // Returns the keywords
    }

}
