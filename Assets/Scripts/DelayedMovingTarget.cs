using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedMovingTarget : MonoBehaviour {
    float targetDownwardMovement = 0;
    bool goingDown = true;

    // Use this for initialization
    void Start()
    {

        InvokeRepeating("MoveTarget", 5.0f, 0.02f);
    }

    // Update is called once per frame
    void Update()
    {
        if (targetDownwardMovement <= -2)
        {
            goingDown = false;
        }

        if (targetDownwardMovement >= 0)
        {
            goingDown = true;
        }
    }

    void MoveTarget()
    {
        if (goingDown)
        {
            targetDownwardMovement -= .01f;
            Vector3 targetPosition = this.transform.position;
            targetPosition.y -= .01f;
            this.transform.position = targetPosition;
            Debug.Log(targetDownwardMovement);
        }
        else if (!goingDown)
        {
            targetDownwardMovement += .01f;
            Vector3 targetPosition = this.transform.position;
            targetPosition.y += .01f;
            this.transform.position = targetPosition;
            Debug.Log(targetDownwardMovement);
        }



    }
}