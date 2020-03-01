using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public enum TurnState { StartState, DrawState, StandingState, BustedState, EndState};
    public TurnState currentTurnState;

    [Header("GameObjects for Canvases")]
    public GameObject Player1Screen;
    public GameObject Player2Screen;
    public GameObject TurnStartScreen;
    public GameObject PlayerStandingScreen;
    public GameObject PlayerBustedScreen;

    [Header("Flag Player Decision Bools")]
    public bool P1_Turn = true;//flag for whose turn it is
    public bool P1_isStanding = false;//checks if P1 is standing
    public bool P1_isBusted = false;//Checks if P1 is busted 
    public bool P2_isStanding = false;// checks if P2 is standing 
    public bool P2_isBusted = false;//Checks if P2 is busted 

    // Start is called before the first frame update
    void Start()
    {
        currentTurnState = TurnState.StartState;
        ShowScreen(TurnStartScreen);
        Player1Screen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ShowScreen(GameObject gameObjectToShow)
    {
        TurnStartScreen.SetActive(false);
        Player1Screen.SetActive(false);
        Player2Screen.SetActive(false);
        PlayerStandingScreen.SetActive(false);
        PlayerBustedScreen.SetActive(false);

        gameObjectToShow.SetActive(true);
    }
    //Start of Player Turn
    public void EnterStartState()
    {
        currentTurnState = TurnState.StartState;
        if(P1_Turn)
        {
            ShowScreen(Player1Screen);
        }
        else if(!P1_Turn)
        {
            ShowScreen(Player2Screen);
        }
    }
    //determines which state depending on thier actions of last turn 
    public void EnterDrawState()
    {
        if(P1_isStanding && P1_Turn)//if it is P1's turn and they are standing 
        {
            currentTurnState = TurnState.StandingState;
            ShowScreen(PlayerStandingScreen);
            Player1Screen.SetActive(true);
        }
        else if(P2_isStanding && !P1_Turn)//if it is P2's turn an they are standing
        {
            currentTurnState = TurnState.StandingState;
            ShowScreen(PlayerStandingScreen);
            Player2Screen.SetActive(true);
        }
        else if(P1_isBusted && P1_Turn)//if it is P1's turn and they are busted
        {
            currentTurnState = TurnState.BustedState;
            ShowScreen(PlayerBustedScreen);
            Player1Screen.SetActive(true);
        }
        else if(P2_isBusted && !P1_Turn)//if it is P2's turn and they are busted 
        {
            currentTurnState = TurnState.BustedState;
            ShowScreen(PlayerBustedScreen);
            Player2Screen.SetActive(true);
        }
        else if(!P1_isStanding && !P2_isBusted && P1_Turn)// if it is P1's turn and they are NOT busted or standing 
        {
            currentTurnState = TurnState.DrawState;
            Player1Screen.SetActive(true);
        }
        else if(!P2_isStanding && !P2_isBusted && !P1_Turn)//if i
        {
            currentTurnState = TurnState.DrawState;
            Player2Screen.SetActive(true);
        }
    }
    //enters only if Player is_Standing is true at the begining of their turn
    public void EnterStandingState()
    {
        if(P1_Turn && !P1_isStanding)//if it is P1's turn and they decide to stand
        {
            P1_isStanding = true;
        }
        else if(!P1_Turn && !P2_isStanding)//if it is P2's turn and they decide to stand
        {
            P2_isStanding = true;
        }
    }
    //not sure if i really need EndState
    public void EnterEndState()
    {
        currentTurnState = TurnState.EndState;
    }
    //happens on Button press and starts next players turn if it can happen 
    public void EndTurn()
    {
        if(P1_Turn)//if it was P1's turn, it is now P2's turn
        {
            P1_Turn = false;
        }
        else if(!P1_Turn)// if it was P2's turn, it is now P1's turn
        {
            P1_Turn = true;
        }
        EnterStartState();
       
    }


}
