using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MrSquaresDialogue : MonoBehaviour
{
    public DialogueStep[] steps;
    public TMP_Text textTMP;
    public Button first;
    public Button second;
    public GameObject endPanel;

    // Stepping array for the steps of the dialogue, plus the text for the tmp text and the buttons.

    public void ShowStep(int i)
    {
        DialogueStep stp = steps[i];

        textTMP.text = stp.misterSquaresMessage;

        if (i == 12)
        {
            endPanel.SetActive(true);
            first.gameObject.SetActive(false);
            second.gameObject.SetActive(false);
            return;
        }
        else
        {
            endPanel.SetActive(false);
        }

        if (!string.IsNullOrEmpty(stp.givenKeyword))
        {
            KeywordSystem.Instance.AddKeyword(stp.givenKeyword);
        } // Checks if the keyword is null or empty, it will add the keyword if it isnt null or empty.

        if (stp.replyLabels.Length > 0)
        {
            first.gameObject.SetActive(true);
            first.GetComponentInChildren<TMP_Text>().text = stp.replyLabels[0];
            first.onClick.RemoveAllListeners();

            int x = stp.replyIndexes[0];
            first.onClick.AddListener(() => ShowStep(x));
        }
        else
        {
            first.gameObject.SetActive(false);
        }
        // Checks if the reply labels are greater in length that 0 and sets active and more. If its not greater than 0, its dissabled

        if (stp.replyLabels.Length > 1)
        {
            second.gameObject.SetActive(true);
            second.GetComponentInChildren<TMP_Text>().text = stp.replyLabels[1];
            second.onClick.RemoveAllListeners();

            int y = stp.replyIndexes[1];
            second.onClick.AddListener(() => ShowStep(y));
        }
        else
        {
            second.gameObject.SetActive(false);
        }

        // Same stuff above, just for the other button.
    }

    void Start()
    {
        ShowStep(0);
    }
}