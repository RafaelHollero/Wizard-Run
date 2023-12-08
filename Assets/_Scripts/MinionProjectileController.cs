using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class MinionProjectileController : MonoBehaviour
{
    public float speed = 0.1f;
    public int direction = -1;
    public float despawnDistance = 10;
    public float initX;
    // Start is called before the first frame update
    void Start()
    {
        initX = gameObject.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPos = new Vector2(
            gameObject.transform.position.x + speed * direction,
            gameObject.transform.position.y
            );
        gameObject.transform.position = newPos;

        if (Math.Abs(gameObject.transform.position.x - initX) > despawnDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Minion" && collision.gameObject.tag != "Boss")
        {
            Destroy(gameObject);
        }
    }

}
