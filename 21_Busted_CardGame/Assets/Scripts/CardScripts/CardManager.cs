using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public CardAsset Card_Asset;

    [Header("Text Components")]
    public Text CardValue;

    [Header("Image References")]
    public Image CardBodyImage;
    public Image CardFaceFrameImage;

    private void Awake()
    {
        if(Card_Asset != null)
        {
            ReadCardFromAsset();
        }
    }

    public void ReadCardFromAsset()
    {
    CardValue.text = (Card_Asset.CardValue + "");
    }
}
