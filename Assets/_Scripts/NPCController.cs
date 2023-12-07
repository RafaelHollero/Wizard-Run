using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public GameObject dialogue_box;
    public GameObject box;
    public TextMeshProUGUI dialogue;
    public string speech;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 newPos = new Vector2(
                gameObject.transform.position.x,
                gameObject.transform.position.y + 2
                ) ;
            box = Instantiate(dialogue_box, newPos, Quaternion.identity);
            box.transform.Rotate(0, 0, 90);
            dialogue = box.transform.Find("Bubble").Find("Dialogue").GetComponent<TextMeshProUGUI>();
            dialogue.text = speech;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(box);
        }
    }
}
