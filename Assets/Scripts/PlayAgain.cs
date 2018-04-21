using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PlayAgain : MonoBehaviour, IPointerEnterHandler {

    public Button playAgainButton;

    public AudioClip hoverButtonEffect;
    public AudioClip clickButtonEffect;
    public AudioSource audioSource;

    Button btn;

    void Start()
    {
        btn = playAgainButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene("scene1");
        audioSource.PlayOneShot(clickButtonEffect, 2);
        Debug.Log("You have clicked the button!");
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        audioSource.PlayOneShot(hoverButtonEffect, 2);
    }
}
