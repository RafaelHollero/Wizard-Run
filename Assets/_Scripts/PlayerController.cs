using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.5f;
    public GameObject projectile;
    public Rigidbody2D rb;
    private bool isGrounded = true;
    public int health = 5;
    public Animator anim;
    private bool noInput;
    int layerMask = 1 << 6;
    public int crystal_count = 0;
    private bool upKeyPressed = false;
    public GameObject you_win;
    public GameObject game_over;
    public bool enable_input = true;
    public TextMeshProUGUI crystals;
    public GameObject[] full_hearts;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        noInput = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("TitleScreen");
        }
        if (enable_input)
        {
            isGrounded = IsGrounded();
            noInput = true;
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Vector2 newPos = new Vector2(
                    gameObject.transform.position.x - speed * Time.deltaTime,
                    gameObject.transform.position.y);

                gameObject.transform.position = newPos;
                noInput = false;
                gameObject.transform.localScale = new Vector3(-2.5f, 2.5f, 1);
                if (isGrounded)
                {
                    anim.Play("WizardRun");
                }
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                Vector2 newPos = new Vector2(
                    gameObject.transform.position.x + speed * Time.deltaTime,
                    gameObject.transform.position.y);

                gameObject.transform.position = newPos;
                noInput = false;
                gameObject.transform.localScale = new Vector3(2.5f, 2.5f, 1);
                if (isGrounded)
                {
                    anim.Play("WizardRun");
                }
            }
            if (Input.GetKey(KeyCode.UpArrow) && isGrounded && !upKeyPressed)
            {
                Vector2 jump = new Vector2(0.0f, 10f);
                rb.AddForce(jump, ForceMode2D.Impulse);
                noInput = false;
                upKeyPressed = true;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Vector2 position = new Vector2(
                    gameObject.transform.position.x + 0.75f * gameObject.transform.localScale.x / 2.5f,
                    gameObject.transform.position.y
                    );
                Instantiate(projectile, position, Quaternion.identity);
                noInput = false;
                // NEED TO FIX
                anim.Play("WizardAttack");
            }
            if (!Input.GetKey(KeyCode.UpArrow))
            {
                upKeyPressed = false;
            }
            if (!isGrounded)
            {
                anim.Play("WizardJump");
            }
            else if (noInput)
            {
                anim.Play("WizardIdle");
            }
        }
        else
        {
            anim.Play("WizardIdle");
        }
    }

    bool IsGrounded()
    {
        Vector2 checkPos1 = new Vector2(transform.position.x - transform.localScale.x / 2.5f, transform.position.y); //behind
        Vector2 checkPos2 = new Vector2(transform.position.x + transform.localScale.x / 5, transform.position.y); //in front
        bool check1, check2;
        if(Physics2D.Raycast(checkPos1, -Vector2.up, 1.16f, layerMask).collider == null)
        {
            check1 = false;
        }
        else
        {
            check1 = Physics2D.Raycast(checkPos1, -Vector2.up, 1.16f, layerMask);
        }
        if (Physics2D.Raycast(checkPos2, -Vector2.up, 1.16f, layerMask).collider == null)
        {
            check2 = false;
        }
        else
        {
            check2 = Physics2D.Raycast(checkPos2, -Vector2.up, 1.16f, layerMask);
        }
        return check1 || check2;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Win"))
        {
            Instantiate(you_win);
            enable_input = false;
        }
        else if (collision.gameObject.CompareTag("Health"))
        {
            if (health < 5)
            {
                full_hearts[health].SetActive(true);
                health++;
            }
        }
        else if (collision.gameObject.CompareTag("Crystal"))
        {
            crystal_count++;
            crystals.text = "Crystals: " + crystal_count;
        }
        else if (collision.gameObject.CompareTag("EnemyProjectile"))
        {
            health -= 1;
            full_hearts[health].SetActive(false);
            if (health <= 0)
            {
                Destroy(gameObject);
                Instantiate(game_over);
            }
        }
    }


}
