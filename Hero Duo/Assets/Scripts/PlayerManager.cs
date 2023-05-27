using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    // enum to handle which state player is in
    public enum GameState
    {
        American,
        Japanese
    }

    // stores current state of the player
    GameState currentState;

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
                GetComponent<SpriteRenderer>().color = Color.cyan;
                // specific attacks

                break;

            case GameState.Japanese:
                GetComponent<SpriteRenderer>().color = Color.red;
                // other unique moveset

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
    }
}
