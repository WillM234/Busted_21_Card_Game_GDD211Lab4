using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour
{
    [Header("scripts")]
    public TurnManager TurnMaster;
    public StateManager GameMaster;
    public ScoreManager ScoreMaster;
    public P1_PlayArea P1_PA;
    public P2_PlayArea P2_PA;
    public DiscardArea Discard;
    public Deck deck;

    [Header("Bools")]
    public bool P1_isDoneForRound;
    public bool P2_isDoneForRound;
    public bool RoundisOver;
    public bool P1_isRoundWinner;
    public bool P2_isRoundWinner;
    public bool RoundisDraw;
    public bool P1_WinsGame;
    public bool P2_WinsGame;
    public bool GameisDraw;
    public bool GameIsFinished;

    [Header("Ints")]
    public int RoundCount = 1;
    public int P1_RoundWins;
    public int P2_RoundWins;
    public int RoundDraws;
    public int MaxRounds;
    private int GoalScore;

    

    public GameObject RoundisDonePanel;
    public GameObject GameisDonePanel;

    [Header("Texts")]
    public Text RoundCounter;
    public Text P1_RoundWinsText;
    public Text P2_RoundWinsText;
    public Text RoundDrawsText;
    public Text DiscardText;
    public Text DeckText;
    public Text ShowRoundWinner;
    public Text ShowGameWinner;
    

    private void Awake()
    {
        GoalScore = ScoreMaster.GoalScore;

        DiscardText.text = (Discard.Discarded.Count + "");
        DeckText.text = (deck.cards.Count + "");
    }
    // Update is called once per frame
    void Update()
    {

        //Checking to see if a Player is done for the Round
        //P1 check
        if (TurnMaster.P1_isBusted == true || TurnMaster.P1_isStanding == true)
        {
            P1_isDoneForRound = true;
        }//if player becomes busted or decides to stand for the round, then they are done for this round

        //P2Check
        if (TurnMaster.P2_isBusted == true || TurnMaster.P2_isStanding == true)
        {
            P2_isDoneForRound = true;
        }//if player becomes busted or decides to stand for the round, then they are done for this round

        else
        {
            P1_isDoneForRound = false;
            P2_isDoneForRound = false;
        }//if round is not done

        //end of Round Check
        if (P1_isDoneForRound == true && P2_isDoneForRound == true)
        {
            RoundisOver = true;
        }// checks to see if both players are done for the round, if true the round is now over

        else
        {
            RoundisOver = false;
        }// if false the round is not over

        //Checking Scores to see who won the round, only if the round is over
        if (RoundisOver == true)
        {
            if (ScoreMaster.P1_Total <= GoalScore && ScoreMaster.P2_Total <= GoalScore)
            {
                if (ScoreMaster.P1_Total > ScoreMaster.P2_Total)
                {
                    P1_isRoundWinner = true;//round result
                }//Player 1 Wins Round
                else if (ScoreMaster.P2_Total > ScoreMaster.P1_Total)
                {
                    P2_isRoundWinner = true;//round result
                }//Player 2 Wins Round
                else if (ScoreMaster.P1_Total == ScoreMaster.P2_Total)
                {
                    RoundisDraw = true;//round result
                }//round is a draw
            }//if both players are not busted

            else if (TurnMaster.P1_isBusted == true && TurnMaster.P2_isBusted == true)
            {
                RoundisDraw = true;
            }//if both players are busted
            else if (TurnMaster.P1_isBusted == true && ScoreMaster.P2_Total <= GoalScore)
            {
                P2_isRoundWinner = true;
            }//if only player 1 is busted
            else if (TurnMaster.P2_isBusted == true && ScoreMaster.P1_Total <= GoalScore)
            {
                P1_isRoundWinner = true;
            }//if only player 2 is busted
        }
        //setting round counts so they dont go over the max
        if(RoundisOver == true && RoundCount >= MaxRounds)
        {
            GameIsFinished = true;
        }
       /* if(RoundCount > MaxRounds)
        {
            RoundCount = MaxRounds;
        }*/
        //determining who won the game at the end of the game
        if(GameIsFinished == true)
        {
            if(P1_RoundWins > P2_RoundWins)
            {
                P1_WinsGame = true;
            }
            else if(P2_RoundWins > P1_RoundWins)
            {
                P2_WinsGame = true;
            }
            else if(P1_RoundWins == P2_RoundWins)
            {
                GameisDraw = true;
            }
            else
            {
                P1_WinsGame = false;
                P2_WinsGame = false;
                GameisDraw = false;
            }
        }


        //updating Texts so that player can see the results of the round
        DeckText.text = (deck.cards.Count + "");
        RoundCounter.text = (RoundCount + " / " + MaxRounds);
        P1_RoundWinsText.text = (GameMaster.Player1Name + " Wins: " + P1_RoundWins);
        P2_RoundWinsText.text = (GameMaster.Player2Name + " Wins: " + P2_RoundWins);
        RoundDrawsText.text = ("Draws: " + RoundDraws);

    }
    public void StartNewRound()
    {
        if (RoundisOver == true)
        {
            //Player Round Wins/Draws update 
            if (P1_isRoundWinner == true)
            {
                P1_RoundWins += 1;
            }
            if (P2_isRoundWinner == true)
            {
                P2_RoundWins += 1;
            }
            if (RoundisDraw == true)
            {
                RoundDraws += 1;
            }
            //Update DiscardCount
            DiscardText.text = (Discard.Discarded.Count + "");
            //add to Round Count
            RoundCount += 1;
            //reseting the win bools
            P1_isRoundWinner = false;
            P2_isRoundWinner = false;
            RoundisDraw = false;
            //Score Resets
            ScoreMaster.P1_Total = 0;
            ScoreMaster.P2_Total = 0;
            //TurnMasterResets
            TurnMaster.P1_isStanding = false;
            TurnMaster.P2_isStanding = false;
            TurnMaster.P1_isBusted = false;
            TurnMaster.P2_isBusted = false;
            TurnMaster.P1_Turn = true;
            //List Clears
            P1_PA.P1Area.Clear();
            P2_PA.P2Area.Clear();
            //Destroy Cards GameObject
            GameObject[] Cards = GameObject.FindGameObjectsWithTag("Card");
            for (int i = 0; i < Cards.Length; i++)
            {
                Destroy(Cards[i]);
            }
        }
    }
    public void ThreeRounds()
    {
        MaxRounds = 3;
    }
    public void FiveRounds()
    {
        MaxRounds = 5;
    }
    public void SevenRounds()
    {
        MaxRounds = 7;
    }
    public void ShowRoundWinScreen()
    {
        if (RoundisOver == true && GameIsFinished == false)
        {
            RoundisDonePanel.SetActive(true);
            if(P1_isRoundWinner == true)
            {
                ShowRoundWinner.text = (GameMaster.Player1Name + " wins this round! Continue on the next round!");
            }
            else if (P2_isRoundWinner == true)
            {
                ShowRoundWinner.text = (GameMaster.Player2Name + " wins this round! Continue onto the next round!");
            }
            else if (RoundisDraw == true)
            {
                ShowRoundWinner.text = "The round tied! Continue onto the next round!";
            }
        }
        else if (GameIsFinished == true && RoundisOver == true)
        {
            GameisDonePanel.SetActive(true);
            if (P1_WinsGame == true)
            {
                ShowGameWinner.text = (GameMaster.Player1Name + " wins the game! Hit the Reload button to play again!");
            }
            else if (P2_WinsGame == true)
            {
                ShowGameWinner.text = (GameMaster.Player2Name + " wins the game! Hit the Reload button to play again!");
            }
            else if (GameisDraw == true)
            {
                ShowGameWinner.text = "The game ended in a draw! Hit the reload button to play again!";
            }
        }
       else if(RoundisOver == false && GameIsFinished == false)
        {
            TurnMaster.EndTurn();
        }
    }
    
}
