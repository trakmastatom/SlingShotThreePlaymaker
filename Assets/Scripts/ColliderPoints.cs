using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderPoints : MonoBehaviour {

    Collision boxHit;
    public static int points;
    public static int numOfBlocks;


    public AudioClip clangsfx;
    public AudioClip tinnyclangsfx;
    public AudioSource audioSource;

    


    //variable for delaying destruction of blocks
    float delay = 2.0f;



    // Use this for initialization
    void Start ()
    {

        points = 0;
        boxHit = gameObject.GetComponent<Collision>();

        audioSource.clip = clangsfx;
        audioSource.clip = tinnyclangsfx;

    }
	
	// Update is called once per frame
	void Update ()
    {


        //set numofblocks variable to number of objects tagged as destructible cubes
        numOfBlocks = GameObject.FindGameObjectsWithTag("DestructibleCubes").Length;
        Debug.Log(numOfBlocks);


        // was having problem where last shot wouldn't take numOfBlocks down for
        // some reason. Added a placeholder block away from the scene, which is why
        // player wins if numOfBlocks is less than 2 instead of 1
        if (numOfBlocks < 2)
        {
            SceneManager.LoadScene("winner");
            Debug.Log("Winner!!!");
        }


    }




    void OnCollisionEnter(Collision boxHit)
    {
        
        
        if (boxHit.gameObject.name == "Ball")
        {
            
            points += 100;
            Destroy(this.gameObject, delay);
            audioSource.PlayOneShot(clangsfx, 2);

            
            
            
        }
        else
        {
            points += 10;
            Destroy(this.gameObject, delay);
            audioSource.PlayOneShot(tinnyclangsfx, 2);



        }
    }


}
