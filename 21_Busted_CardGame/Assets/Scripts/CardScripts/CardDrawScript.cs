using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDrawScript : MonoBehaviour
{
    [Header("Script References")]
    public Deck deck;
    public P1_PlayArea P1_Area;
    public P2_PlayArea P2_Area;
    public DiscardArea Discard;
    public TurnManager TurnMaster;
    

    [Header("Object References")]
    public GameObject P1Slot;
    public GameObject P2Slot;
    public GameObject NumCard;
    public CardAsset NCard;
    private GameObject PlayerDeck;

    [Header("Vect3 for Instantiate")]
    public Vector3 PlayPos;

    // Start is called before the first frame update
    void Awake()
    {
        PlayerDeck = GameObject.Find("Deck");
        deck = PlayerDeck.GetComponent<Deck>();
    }

    // Update is called once per frame
    void Update()
    {
        
       if(TurnMaster.P1_Turn == true)
        {
            PlayPos = P1Slot.transform.position;
        }
       else if(TurnMaster.P1_Turn == false)
        {
            PlayPos = P2Slot.transform.position;
        }
    }
    public void DrawACard()
    {
         NCard = PlayerDeck.GetComponent<Deck>().cards[0];
        if (deck.cards.Count > 0)
        {
            if(TurnMaster.P1_Turn == true)
            {
                Discard.Discarded.Insert(0, NCard);
                P1_Area.P1Area.Insert(0, NCard);
                deck.cards.RemoveAt(0);
            }
            if(TurnMaster.P1_Turn == false)
            {
                Discard.Discarded.Insert(0, NCard);
                P2_Area.P2Area.Insert(0, NCard);
                deck.cards.RemoveAt(0);
            }
        }
    }
    public void CardSpawn(GameObject NewCard)
    {
        Instantiate(NumCard, PlayPos, Quaternion.identity);
    }
}
