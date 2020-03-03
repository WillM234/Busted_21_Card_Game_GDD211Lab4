using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    [Header("Score Tracking")]
    public int P1_Total;
    public int P2_Total;
    public int GoalScore = 21;
    public int CardPlayedValue;
    [Header("Text References")]
    public Text P1_TotalText;
    public Text P2_TotalText;
    [Header("Scripts")]
    private TurnManager TurnMaster;
    private StateManager GameMaster;
    private CardAsset Card_Asset;
    [Header("GameObjects")]
    public GameObject P1_PArea;
    public GameObject P2_PArea;



    private void Awake()
    {
        TurnMaster = GameObject.Find("GameManager").GetComponent<TurnManager>();
        GameMaster = GameObject.Find("GameManager").GetComponent<StateManager>();
        P1_PArea = GameObject.Find("Player1Cards");
        P2_PArea = GameObject.Find("Player2Cards");
        
    }
    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {

        if(P1_Total == GoalScore)
        {
            TurnMaster.P1_isStanding = true;
        }
        if(P2_Total == GoalScore)
        {
            TurnMaster.P2_isStanding = true;
        }
        if(P1_Total > GoalScore)
        {
            TurnMaster.P1_isBusted = true;
        }
        if(P2_Total > GoalScore)
        {
            TurnMaster.P2_isBusted = true;
        }
        //Showing current card totals to the players, Names will be based on input
        P1_TotalText.text = (GameMaster.Player1Name + " : " + P1_Total);
        P2_TotalText.text = (GameMaster.Player2Name + " : " + P2_Total);
    }

    //This will be on a button press, when the player draws a card
    public void AddToTotal()
    {
        if(TurnMaster.P1_Turn == true)
        {
            Card_Asset = P1_PArea.GetComponent<P1_PlayArea>().P1Area[0];
            CardPlayedValue = Card_Asset.CardValue;
            P1_Total += CardPlayedValue;
        }
        else if (TurnMaster.P1_Turn == false)
        {
            Card_Asset = P2_PArea.GetComponent<P2_PlayArea>().P2Area[0];
            CardPlayedValue = Card_Asset.CardValue;
            P2_Total += CardPlayedValue;
        }
        else
        {
            CardPlayedValue = 0;
        }
    }
}
