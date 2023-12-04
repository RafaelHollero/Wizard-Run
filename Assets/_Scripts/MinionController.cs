using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionController : MonoBehaviour
{
    private float timePassed = 0f;
    public GameObject projectile;
    private int health = 1;
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
        if(timePassed >= 2)
        {
            timePassed = 0f;
            //Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
        }
         
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "PlayerProjectile")
        {
            health--;
            if (health <= 0)
            {
                anim.Play("MinionDeath");
                Destroy(gameObject);
            }

        }
    }
}
