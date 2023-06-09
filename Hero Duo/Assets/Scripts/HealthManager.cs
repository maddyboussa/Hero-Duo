using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;

    [SerializeField]
    int playerHealth;

    [SerializeField]
    int bossHealth;

    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject boss;

    [SerializeField]
    GameObject deathScene;

    // properties
    public int PlayerHealth { get { return playerHealth; } set { playerHealth = value; } }

    public int BossHealth { get { return bossHealth; } set { bossHealth = value; } }

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 100;
        bossHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0)
        {
            // Die
            player.SetActive(false);
            deathScene.SetActive(true);
            //Destroy(player);
        }

        if (bossHealth <= 0)
        {
            // Die
            boss.SetActive(false);
            deathScene.SetActive(true);
            //Destroy(boss);
        }
        
    }
}
