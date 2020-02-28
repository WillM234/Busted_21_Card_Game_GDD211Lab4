using UnityEngine;
using UnityEditor;

public class CardIntegration
{
    [MenuItem("Assets/Create/CardAsset")]//specifies where the option to create the object will show up in the menu
    public static void CreateYourScriptableObject()
    {
        SOUtility.CreateAsset<CardAsset>();//creates the asset type of Card Asset
    }
}