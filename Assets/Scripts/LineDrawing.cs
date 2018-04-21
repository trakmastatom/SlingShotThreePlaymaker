using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawing : MonoBehaviour {

    public GameObject line1;
    public GameObject line2;
    public LineRenderer[] lines;
    public Transform leftanchor;
    public Transform rightanchor;
    public Transform pullPoint;
    public Transform[] anchors;
    public GameObject dragPoint;
    public GameObject ball;
    


    private float[] lineLengths;

    // Use this for initialization
    void Start ()
    {

        
        //arrays
        anchors = new Transform[2];
        anchors[0] = leftanchor;
        anchors[1] = rightanchor;
        lineLengths = new float[2];
        //lines
        lines = new LineRenderer[2];
        line1.GetComponent<LineRenderer>().SetPosition(0, leftanchor.position);
        line1.GetComponent<LineRenderer>().SetPosition(1, dragPoint.transform.position);
        lines[0] = line1.GetComponent<LineRenderer>();
        line2.GetComponent<LineRenderer>().SetPosition(0, rightanchor.position);
        line2.GetComponent<LineRenderer>().SetPosition(1, dragPoint.transform.position);
        lines[1] = line2.GetComponent<LineRenderer>();

    }
	
	// Update is called once per frame
	void Update ()
    {

        dragPoint.transform.position = ball.transform.position;
        UpdateLines();

        // remove lines when shot
        if (Input.GetKeyDown("space"))
        {
            line1.GetComponent<LineRenderer>().startWidth = 0;
            line1.GetComponent<LineRenderer>().endWidth = 0;

            line2.GetComponent<LineRenderer>().startWidth = 0;
            line2.GetComponent<LineRenderer>().endWidth = 0;

        }

        //add lines back on click
        if (Input.GetMouseButtonDown(0))
        {
            line1.GetComponent<LineRenderer>().startWidth = .001f;
            line1.GetComponent<LineRenderer>().endWidth = .001f;

            line2.GetComponent<LineRenderer>().startWidth = .001f;
            line2.GetComponent<LineRenderer>().endWidth = .001f;

            UpdateLines();
        }
    }

    void UpdateLines()
    {
        for (int i = 0; i < lines.Length; i++)
        {
            lines[i].SetPosition(1, dragPoint.transform.position);
            lines[i].SetPosition(0, anchors[i].position);
            lineLengths[i] = Vector3.Distance(dragPoint.transform.position, anchors[i].position);

            if (lineLengths[i] <= 0.65f) lineLengths[i] = 0.65f;
        }
    }
}
