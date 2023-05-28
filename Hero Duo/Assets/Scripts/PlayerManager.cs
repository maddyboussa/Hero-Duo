using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    // enum to handle which state player is in
    public enum GameState
    {
        American,
        Japanese
    }

    // load audio
    [SerializeField]
    public AudioSource swap;

    [SerializeField]
    GameObject taroTitle;

    [SerializeField]
    GameObject eagleTitle;

    [SerializeField]
    GameObject taroSprite;

    [SerializeField]
    GameObject eagleSprite;

    [SerializeField]
    Sprite katana;

    [SerializeField]
    Sprite shotgun;


    // stores current state of the player
    public GameState currentState;

    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        currentState = GameState.Japanese;
        //HealthManager.instance.Health = 100;
        
    }

    // Update is called once per frame
    void Update()
    {
        // change sprites and actions based on player state
        switch (currentState)
        {
            case GameState.American:
                //GetComponent<SpriteRenderer>().color = Color.cyan;
                // specific attacks

                // change UI based on active player
                eagleTitle.SetActive(true);
                taroTitle.SetActive(false);

                // set sprite based on active player
                GetComponent<SpriteRenderer>().sprite = eagleSprite.GetComponent<SpriteRenderer>().sprite;

                // set weapon sprite
                if (GetComponent<PlayerMovement>().swords.Count > 0)
                {
                    foreach (GameObject sword in GetComponent<PlayerMovement>().swords)
                    {
                        sword.GetComponent<SpriteRenderer>().sprite = shotgun;
                    }
                }

                    break;

            case GameState.Japanese:
                //GetComponent<SpriteRenderer>().color = Color.red;
                // other unique moveset

                // change UI based on active player
                eagleTitle.SetActive(false);
                taroTitle.SetActive(true);

                // set sprite based on active player
                GetComponent<SpriteRenderer>().sprite = taroSprite.GetComponent<SpriteRenderer>().sprite;

                // set weapon sprite
                if (GetComponent<PlayerMovement>().swords.Count > 0)
                {
                    foreach (GameObject sword in GetComponent<PlayerMovement>().swords)
                    {
                        sword.GetComponent<SpriteRenderer>().sprite = katana;
                    }
                }

                break;
        }

    }

    public void OnSwap()
    {
        if (currentState == GameState.American)
        {
            currentState = GameState.Japanese;
        }
        // handles switching out of american state
        else if (currentState == GameState.Japanese)
        {
            currentState = GameState.American;

        }

        // play sound
        swap.Play();
    }
}
