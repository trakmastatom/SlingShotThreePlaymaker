using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveLocation : MonoBehaviour {

    [SerializeField]
    GameObject ball;

    [SerializeField]
    GameObject pullpoint;

    [SerializeField]
    GameObject player;

    public AudioClip shot;
    public AudioSource source;

    public float dynamicThrust;
    public float staticThrust;
    public Rigidbody rb;

    //number of shots
    public static int shots;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        shots = 12;
	}
	
	
    void GameOver()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene("gameover");
    }
    // Update is called once per frame
	void Update ()
    {

        //set position variable as ball's position
        Vector3 position = ball.transform.position;
        //set direction variable as direction from ball to pullpoint (origin of ball
        // and midpoint of slingshot)
        Vector3 direction = (pullpoint.transform.position - ball.transform.position).normalized;
        // Get pull point position
        Vector3 pullPosition = pullpoint.transform.position;

        // get scroll wheel movement
        var wheel = Input.GetAxis("Mouse ScrollWheel");



        dynamicThrust = Vector3.Distance(ball.transform.position, pullpoint.transform.position);



        if (Input.GetMouseButtonDown(0))
        {
            //remove all force so ball stays still
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            //set var as player's position
            var playerPos = player.transform.position;
            //offset x position so ball doesn't intersect with player
            playerPos.x -= 0.5f;
            //move ball in front of player
            ball.transform.position = playerPos;


            

        }

        

        if (Input.GetKeyDown("space") && shots > 0)
        {

            source.PlayOneShot(shot, 1);

            //set static thrust to dynamic thrust (distance between ball and starting point)
            //multiplied by 700 because it takes a lot of force for some reason
            staticThrust = dynamicThrust * 700;
            
            //Add force to ball object's rigidbody, multiply by direction (direction toward starting point)
            rb.AddForce(direction * staticThrust,ForceMode.Force);
            // less one shots
            shots--;

            Debug.Log(direction);
            Debug.Log(staticThrust);
        }

        // set right cntrl to make pull point go up
        //if (Input.GetKeyDown("right ctrl"))
        if (wheel > 0f)
        {
            pullPosition.y += .015f;
            pullpoint.transform.position = pullPosition;
        }

        // set left cntrl to make pull point go down
        //if (Input.GetKeyDown("left ctrl"))
        if (wheel < 0f)
        {
            pullPosition.y -= .015f;
            pullpoint.transform.position = pullPosition;
        }

        if (shots == 0)
        {

            Invoke("GameOver", 3);
            
            
        }


    }
}
