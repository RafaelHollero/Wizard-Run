using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectileController : MonoBehaviour
{
    public float speed = 0.001f;
    public float despawnDistance = 10;
    public float initX;
    public GameObject player;
    private Vector2 dir;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        initX = gameObject.transform.position.x;
        dir = new Vector2(player.transform.position.x - gameObject.transform.position.x, player.transform.position.y - gameObject.transform.position.y);
        gameObject.transform.LookAt(player.transform);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPos = new Vector2(
            gameObject.transform.position.x + speed * dir.x,
            gameObject.transform.position.y + speed * dir.y
            );
        gameObject.transform.position = newPos;

        if (Math.Abs(gameObject.transform.position.x - initX) > despawnDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Destroy alien
            // collision.gameObject.GetComponent<AudioSource>().Play();
            int hp = collision.gameObject.GetComponent<PlayerController>().health -= 1;
            if (hp <= 0)
            {
                Destroy(collision.gameObject);
            }
            // Destroy self

        }
        Debug.Log(collision.gameObject.tag + "\n");
        if (collision.gameObject.tag != "Boss")
        {
            Destroy(gameObject);
        }
    }

}
