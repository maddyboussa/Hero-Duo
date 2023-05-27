using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script will handle both collisions between blockades if we want any
// as well as collision between players and enemies
public class CollisionManager : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject boss;
    
    float invincibilityTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        invincibilityTime += Time.deltaTime;

        // check for collision
        if (RectCollision(player, boss))
        {
            // if the player is no longer invincible
            if (invincibilityTime > 1f)
            {
                // if collision, damage player
                HealthManager.instance.PlayerHealth -= 10;

                // then start timer over
                invincibilityTime = 0;
            }
            
        }
    }

    public bool RectCollision(GameObject player, GameObject collidable)
    {
        if ((player.GetComponent<SpriteRenderer>().bounds.min.x < collidable.GetComponent<SpriteRenderer>().bounds.max.x) &&
            (player.GetComponent<SpriteRenderer>().bounds.max.x > collidable.GetComponent<SpriteRenderer>().bounds.min.x) &&
            (player.GetComponent<SpriteRenderer>().bounds.max.y > collidable.GetComponent<SpriteRenderer>().bounds.min.y) &&
            (player.GetComponent<SpriteRenderer>().bounds.min.y < collidable.GetComponent<SpriteRenderer>().bounds.max.y))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
