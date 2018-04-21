using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicUI : MonoBehaviour {
    void OnGUI()
    {
        int posX = 10;
        int posY = 10;
        int width = 100;
        int height = 30;
        int buffer = 10;


        
        if (ColliderPoints.points == 0)
        {
            GUI.Box(new Rect(posX, posY, width, height), "No Points");
        }


        if (ColliderPoints.points != 0)
        {
            GUI.Box(new Rect(posX, posY, width, height), ColliderPoints.points + " Points");
        }

        GUI.Box(new Rect(posX + 150, posY, width + 50, height), "Shots Remaining: " + MoveLocation.shots);


        posX = 10;
        posY += height + buffer;

        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
