using System.Collections;
using UnityEngine;

[ExecuteInEditMode]//allows use of the script while in the editor

public class CardRotation : MonoBehaviour
{
    [Header("CardFaces")]
    public RectTransform CardFront;//parent object for all card fronts
    public RectTransform CardBack;//parent object for all card backs

    [Header("Faepoint Transform")]
    public Transform targetfacepoint;

    [Header("Card Collider")]
    public Collider Col;

    private bool showingBack = false;//if true, the player sees the back of the card
    
    void Update()
    {
        //Raycast goes from the camera to a target point on the face of the card
        //if the ray cast passes through then the back of the card should be showing
        RaycastHit[] hits;
        hits = Physics.RaycastAll(origin: Camera.main.transform.position, direction: (-Camera.main.transform.position + targetfacepoint.position).normalized, maxDistance: (-Camera.main.transform.position + targetfacepoint.position).magnitude);
        bool passedThroughColliderOnCard = false;
        foreach(RaycastHit h in hits)
        {
            if(h.collider == Col)
            {
                passedThroughColliderOnCard = true;//is true if the raycast has hit the object
            }

        }
        if(passedThroughColliderOnCard != showingBack)//means that the card is showing the front side
        {
            //if the card was rotated enough to show the back of the card
            showingBack = passedThroughColliderOnCard;
            if(showingBack)//if the back is showing
            {
                CardFront.gameObject.SetActive(false);//sets front face inactive in heirarchy, if showingBack is true
                CardBack.gameObject.SetActive(true);//sets back face active in heirarchy, if showingBack is true
            }
            else
            {
                CardFront.gameObject.SetActive(true);//sets front face active in heirarchy, as long as showingBack is false
                CardBack.gameObject.SetActive(false);//sets back face inactive in heirarchy, as long as showingBack is false
            }
        }
    }
}
