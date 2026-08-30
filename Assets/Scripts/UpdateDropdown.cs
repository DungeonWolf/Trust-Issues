using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class UpdateDropdown : MonoBehaviour
{
    [System.Serializable]
    public class KeywordPage
    {
        public string keyword;
        [TextArea(3, 10)] public string pageText;
    }

    public KeywordSystem keywordSystemScript;
    public TMP_Dropdown dropdown;
    public GameObject scrollView;
    public TMP_Text pageTextDisplay;
    public KeywordPage[] pages;

    void Start()
    {
        dropdown.ClearOptions();
        if (keywordSystemScript.GetKeywords() != null)
        {
            List<string> keywords = keywordSystemScript.GetKeywords();
            dropdown.AddOptions(keywords);
        }
        keywordSystemScript.addNewKeyword.AddListener(UpdateOptions);
    }

    void UpdateOptions()
    {
        dropdown.ClearOptions();
        if (keywordSystemScript.GetKeywords() != null)
        {
            List<string> keywords = keywordSystemScript.GetKeywords();
            dropdown.AddOptions(keywords);
        }
    }

    void Update()
    {
        if (dropdown.value > 0)
        {
            SwitchPage();
        }
    }

    void SwitchPage()
    {
        string selected = dropdown.options[dropdown.value].text;

        pageTextDisplay.text = "Page not found.";
        foreach (KeywordPage page in pages)
        {
            if (page.keyword == selected)
            {
                pageTextDisplay.text = page.pageText;
                break;
            }
        }

        dropdown.gameObject.SetActive(false);
        scrollView.SetActive(true);
    }
}