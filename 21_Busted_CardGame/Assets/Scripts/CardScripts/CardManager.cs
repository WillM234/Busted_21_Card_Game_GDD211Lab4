using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public CardAsset Card_Asset;
    public TurnManager TurnMaster;
    public Deck deck;

    private GameObject P1_Area;
    private GameObject P2_Area;

    private GameObject Deck0;
    public int Card_Value;


    [Header("Text Components")]
    public Text CardValue;


    [Header("Image References")]
    public Image CardBodyImage;
    public Image CardFaceFrameImage;

    private void Awake()
    {
        Deck0 = GameObject.Find("Deck");
        P1_Area = GameObject.Find("Player1Cards");
        P2_Area = GameObject.Find("Player2Cards");
        TurnMaster = GameObject.Find("GameManager").GetComponent<TurnManager>();

        if(TurnMaster.P1_Turn == true)
        {
            Card_Asset = P1_Area.GetComponent<P1_PlayArea>().P1Area[0];

        }
        else if(TurnMaster.P1_Turn == false)
        {
            Card_Asset = P2_Area.GetComponent<P2_PlayArea>().P2Area[0];
        }
       
        Card_Value = Card_Asset.CardValue; 

        ReadCardFromAsset();
        
    }
    public void ReadCardFromAsset()
    {
    CardValue.text = (Card_Value + "");
    }
}
