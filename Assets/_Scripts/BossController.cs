using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private float timePassed = 0f;
    public GameObject projectile;
    public GameObject player;
    public int health = 30;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed >= 1.2f)
        {
            timePassed = 0f;
            Debug.Log("Fire");
            Vector2 pos = new Vector2(gameObject.transform.position.x - player.transform.position.x, gameObject.transform.position.y - player.transform.position.y);
            Instantiate(projectile, gameObject.transform.position, Quaternion.LookRotation(pos, Vector2.up));
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "PlayerProjectile")
        {
            health--;
            if (health <= 0)
            {
                Destroy(gameObject);
            }

        }
    }
}
