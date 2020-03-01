using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAsset : ScriptableObject
{
    [Header("Card Value")]
    public int CardValue;
    private CardAsset cardAsset;

    public CardAsset(CardAsset cardAsset)
    {
        this.cardAsset = cardAsset;
    }
}
