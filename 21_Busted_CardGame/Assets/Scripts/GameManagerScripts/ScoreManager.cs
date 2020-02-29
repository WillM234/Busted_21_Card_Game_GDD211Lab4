using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public CardAsset card;
    public TurnManager whoseTurn;

    [Header("Text References")]
    public InputField Player1;
    public InputField Player2;
    public string P1Name;
    public string P2Name;
    public Text p1Name;
    public Text p2Name;
    [Header("Player Scores")]
    public int p1Total;
    public int p2Total;
    

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
