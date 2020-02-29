using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandSlot : MonoBehaviour
{
    public Transform[] child;

    // Start is called before the first frame update
    void Awake()
    {
        Vector3 OnlyElementPos = child[0].transform.position;
    }

}
