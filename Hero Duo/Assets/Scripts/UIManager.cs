using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Slider playerHealthSlider;
    [SerializeField]
    Slider bossHealthSlider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // update player health
        playerHealthSlider.value = HealthManager.instance.PlayerHealth;
        bossHealthSlider.value = HealthManager.instance.BossHealth;
    }
}
