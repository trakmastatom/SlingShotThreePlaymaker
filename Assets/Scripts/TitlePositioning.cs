using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitlePositioning : MonoBehaviour
{
    RectTransform title;

    Vector3 targetPosition;
    float totalChange;


    // Use this for initialization
    void Start()
    {
        title = GetComponent<RectTransform>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
            targetPosition = title.position;
            targetPosition.x += .01f;
            title.position = targetPosition;
            totalChange += .1f;
        

    }

}
