using UnityEngine;

[System.Serializable]

public class DialogueStep
{
    public string misterSquaresMessage;
    public string[] replyLabels;
    public int[] replyIndexes;
    public string givenKeyword;
    public bool isEndOfDialogue;

    // Not much to comment here, just variables and arrays held in a class
}
