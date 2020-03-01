﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<CardAsset> cards = new List<CardAsset>();
    private void Awake()
    {
        cards.Shuffle();
    }
}
