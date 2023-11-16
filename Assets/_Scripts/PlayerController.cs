using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.5f;
    public GameObject projectile;
    public Rigidbody2D rb;
    private bool isGrounded = true;
    public int health = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            Vector2 newPos = new Vector2(
                gameObject.transform.position.x - speed * Time.deltaTime, 
                gameObject.transform.position.y);

            gameObject.transform.position = newPos;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector2 newPos = new Vector2(
                gameObject.transform.position.x + speed * Time.deltaTime,
                gameObject.transform.position.y);

            gameObject.transform.position = newPos;
        }
        if (Input.GetKey(KeyCode.UpArrow) && isGrounded)
        {
            Vector2 jump = new Vector2(0.0f, 2.2f);
            rb.AddForce(jump, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 position = new Vector2(
                gameObject.transform.position.x + 0.75f,
                gameObject.transform.position.y
                );
            Instantiate(projectile, position, Quaternion.identity);
        }
    }
    void OnCollisionEnter2D(Collision2D c)
    {
        if(c.transform.position.y > gameObject.transform.position.y)
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D()
    {
        isGrounded = false;
    }
}
