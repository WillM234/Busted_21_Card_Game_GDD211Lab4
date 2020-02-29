using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TurnManager : MonoBehaviour
{ 
    public enum TurnState { StartState, DrawState, ScoreState, TurnEndState, StandState};
    public TurnState currentState;

    public StateManager GameM;

    [Header("TurnStart Panel Text")]
    public Text TurnStartText;

    [Header("Player Canvases")]
    public GameObject TurnStartPanel;
    public GameObject Player1;
    public GameObject Player2;
    

    [Header("Turn State Tracking")]
    public GameObject TurnStart;

    [Header("Whose Turn Tracker")]
    public bool p1Turn;

    [Header("Player Stands Tracking")]
    public bool Player1Stands = false;
    public bool Player2Stands = false;

    [Header("Round Tracking")]
    public int CurrentRound = 1;

    void Start()
    {
        currentState = TurnState.StartState;
        ShowScreen(TurnStart);
        p1Turn = true;
    }
    // Update is called once per frame
    void Update()
    {
      if(currentState == TurnState.StartState && !p1Turn)
        {
            TurnStartText.text = (GameM.Player2Name + " it is your turn! Hit the button to continue.");
        }
      else if(currentState == TurnState.StartState && p1Turn)
        {
            TurnStartText.text = (GameM.Player1Name + " it is your turn! Hit the button to continue.");
        }
    }
    private void ShowScreen(GameObject gameobjectToShow)
    {
        TurnStart.SetActive(false);
        Player1.SetActive(false);
        Player2.SetActive(false);
    }

    public void EnterDraw_State()
    {
        currentState = TurnState.DrawState;
        if(p1Turn)
        {
            ShowScreen(Player1);
        }
        else if(!p1Turn)
        {
            ShowScreen(Player2);
        }
    }
    public void EnterScoreState()
    {
        currentState = TurnState.TurnEndState;
    
    }
    public void EnterNextPlayersTurn()
    {
        if (p1Turn)
        {
            p1Turn = false;
        }
        else if (!p1Turn)
        {
            p1Turn = true;
        }
        currentState = TurnState.StartState;
    }
    
}
