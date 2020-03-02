using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    [Header("Script References")]
    public StateManager GameMaster;
    public TurnManager TurnMaster;

    [Header("Text References")]
    public Text PlayerIsBustedText;
    public Text PlayerIsStandingText;
    public Text TurnStartText;

    // Update is called once per frame
    void Update()
    {
        //Inputs player name at the begining of the turn and if they are standing or busted
        if(TurnMaster.P1_Turn == true)
        {
            TurnStartText.text = (GameMaster.Player1Name + " it is your turn! Hit the continue button to proceed");
            if(TurnMaster.P1_isBusted == true)
            {
                PlayerIsBustedText.text = (GameMaster.Player1Name + ", your score is over 21 and you have busted. End your turn.");
            }
            else if(TurnMaster.P1_isStanding == true)
            {
                PlayerIsStandingText.text = (GameMaster.Player1Name + ", you are currently standing. End your turn.");
            }
        }
        else if(TurnMaster.P1_Turn == false)
        {
            TurnStartText.text = (GameMaster.Player2Name + " it is your turn! Hit the continue button to proceed");
            if(TurnMaster.P2_isBusted == true)
            {
                PlayerIsBustedText.text = (GameMaster.Player2Name + ", your score is over 21 and you have busted. End your turn.");
            }
            else if(TurnMaster.P2_isStanding == true)
            {
                PlayerIsStandingText.text = (GameMaster.Player2Name + ", you are currently standing. End your turn.");
            }
        }
    }
}
