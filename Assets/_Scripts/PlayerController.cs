using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship_Controller : MonoBehaviour
{
    public float speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
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
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector2 newPos = new Vector2(
                gameObject.transform.position.x,
                gameObject.transform.position.y + speed * Time.deltaTime);

            gameObject.transform.position = newPos;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector2 newPos = new Vector2(
                gameObject.transform.position.x,
                gameObject.transform.position.y - speed * Time.deltaTime);

            gameObject.transform.position = newPos;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
          //  Instantiate();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Vector2 newPos = new Vector2(
                gameObject.transform.position.x,
                other.gameObject.transform.position.y + 0.5f);

            gameObject.transform.position = newPos;
        }
    }
}
