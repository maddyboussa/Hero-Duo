using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public AudioSource taroAttack;

    [SerializeField]
    public AudioSource eagleAttack;

    [SerializeField]
    float speed = 10f;

    [SerializeField]
    GameObject swordPrefab;

    Vector3 playerPosition = Vector3.zero;
    Vector3 direction = Vector3.zero;
    Vector3 velocity = Vector3.zero;

    float totalCamHeight;
    float totalCamWidth;

    public List<GameObject> swords;

    bool canAttack = true;

    float cooldownDuration = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        // makes sure vehicle starts whereever it was placed, and not at 0, 0, 0
        playerPosition = transform.position;

        // store camera dimensions
        totalCamHeight = Camera.main.orthographicSize;
        totalCamWidth = totalCamHeight * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        // velocity is direcion * speed * deltaTime
        // this is a vector with a direction and magnitude
        velocity = direction * speed * Time.deltaTime;

        // increment position based on velocity
        playerPosition += velocity;

        // validate position so player stays on screen
        if (playerPosition.x > totalCamWidth)
        {
            playerPosition.x = totalCamWidth;
        }
        if (playerPosition.x < -totalCamWidth)
        {
            playerPosition.x = -totalCamWidth;
        }

        if (playerPosition.y > totalCamHeight)
        {
            playerPosition.y = totalCamHeight;
        }
        if (playerPosition.y < -totalCamHeight)
        {
            playerPosition.y = -totalCamHeight;
        }

        // draw the new (validated) position
        transform.position = playerPosition;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        // get the value from the context
        direction = context.ReadValue<Vector2>();
    }

    public void OnAttack()
    {
        if (!canAttack)
        {
            return;
        }

        // spawn "sword" prefab

        // according to vincent there should be a thing in controller to do on keyup or key release,
        // that way it will only hit it once
        //if (swordPrefab.activeInHierarchy)
        //{
        //    return;
        //}
        swords.Add(Instantiate(swordPrefab, this.transform));
        
        if (PlayerManager.instance.currentState == PlayerManager.GameState.Japanese)
        {
            taroAttack.Play();
        }
        else
        {
            eagleAttack.Play();
        }

        StartCoroutine(StartCooldown());
    }

    public IEnumerator StartCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(cooldownDuration);
        canAttack = true;

        // remove current swords to reset cooldown
        foreach (GameObject sword in swords)
        {
            Destroy(sword);
        }
        swords.Clear();
    }
}
