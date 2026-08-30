using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public class VirusSystem : MonoBehaviour
{
    //public TMP_Text virusText;
    public GameObject virusPrefab;
    public GameObject canvasRef;
    private int virusSpawnsAmt = 0; //Random.Range(4, 8);
    private int virusSpawnTime = 0;//Random.Range(2, 5); // After closing mr squares program
    private List<string> virusTextOptions = new List<string> { "Search this: Nano Training", "Search this: Mr. Squares", "Search this: Escape", "You don't have to follow orders",  "Mr. Squares is not your friend"};
    //public GameObject squaresClosed;
    private int virusTextOptionsIndex = 0;
    private string selectedVirusText;
    private List<string> virusKeywords = new List<string> { "Nano Training", "Mr. Squares", "Escape", "", ""};
    

    public void CloseSquares()
    {
        Debug.Log("Closing Works");
        StartCoroutine(StartVirus());
    }
    IEnumerator StartVirus()
    {
        yield return new WaitForSeconds(Random.Range(2, 5));
        int virusOptionInt = Random.Range(0, virusTextOptions.Count);
        selectedVirusText = virusTextOptions[virusOptionInt];
        virusTextOptions.RemoveAt(virusOptionInt);
        string vk = virusKeywords[virusOptionInt];
        if (!string.IsNullOrEmpty(vk)) KeywordSystem.Instance.AddKeyword(vk);
        virusKeywords.RemoveAt(virusOptionInt);
        for (int i = 0; i < Random.Range(4, 8); i++)
        {
            GameObject newPopup = Instantiate(virusPrefab, canvasRef.transform);
            newPopup.GetComponent<RectTransform>().anchoredPosition = new Vector2(Random.Range(-300, 300), Random.Range(-150, 150));
            newPopup.GetComponentInChildren<TMP_Text>().text = selectedVirusText;
        }
    }
}
