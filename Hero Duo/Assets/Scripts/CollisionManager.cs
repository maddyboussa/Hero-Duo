using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// this script will handle both collisions between blockades if we want any
// as well as collision between players and enemies
public class CollisionManager : MonoBehaviour
{
    [SerializeField]
    public GameObject fireball;

    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject boss;

    GameObject sword;
    
    float invincibilityTime = 0;
    float bossInvincibilityTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        invincibilityTime += Time.deltaTime;
        bossInvincibilityTime += Time.deltaTime;

        // check for collision between player and boss
        if (HealthManager.instance.BossHealth >= 0 && HealthManager.instance.PlayerHealth >= 0 && RectCollision(player, boss))
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

        // get reference to first sword object in list if list is not empty
        if (player.GetComponent<PlayerMovement>().swords.Count > 0)
        {
            sword = player.GetComponent<PlayerMovement>().swords[0];

            // check for collision between sword and boss
            if (HealthManager.instance.BossHealth >= 0 && RectCollision(sword, boss))
            {
                if (bossInvincibilityTime > .7f)
                {
                    HealthManager.instance.BossHealth -= 10;

                    // restart timer
                    bossInvincibilityTime = 0;
                }

            }
        }

        foreach (GameObject fireball in SpawnFireball.instance.fireballs)
        {
            if (HealthManager.instance.PlayerHealth >= 0 && RectCollision(fireball, player))
            {
                if (invincibilityTime > 1f)
                {
                    // if collision, damage player
                    HealthManager.instance.PlayerHealth -= 5;

                    // then start timer over
                    invincibilityTime = 0;
                }

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
