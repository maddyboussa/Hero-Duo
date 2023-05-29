using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFireball : MonoBehaviour
{
    public static SpawnFireball instance;

    [SerializeField]
    public GameObject fireball;

    [SerializeField]
    public GameObject spawnSite;

    [SerializeField]
    public List<GameObject> fireballs;

    new Vector2 position;

    bool canAttack = true;

    float cooldownDuration = 1f;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fireballs.Count > 0)
        {
            foreach(GameObject fireball in fireballs)
            {
                fireball.transform.position += new Vector3((-5 * Time.deltaTime), 0f, 0f);
            }
        }

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
        SpawnFireballLocation();

        StartCoroutine(StartCooldown());
    }

    void SpawnFireballLocation()
    {
        float randomY = Random.Range(spawnSite.GetComponent<SpriteRenderer>().bounds.min.y, spawnSite.GetComponent<SpriteRenderer>().bounds.max.y);
        float spawnX = spawnSite.GetComponent<SpriteRenderer>().bounds.max.x;


        fireballs.Add(Instantiate(fireball, new Vector3(spawnX, randomY, 0), transform.rotation));
    }

    public IEnumerator StartCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(cooldownDuration);
        canAttack = true;

        // remove current swords to reset cooldown
        //foreach (GameObject fire in fireballs)
        //{
        //    Destroy(fire);
        //}
        //fireballs.Clear();
    }
}
