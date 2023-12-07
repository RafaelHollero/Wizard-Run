using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TitleScreen : MonoBehaviour
{
    public Button yourButton;
    public GameObject controls_screen;

    void Start()
    {
        Button btn = gameObject.transform.Find("Button").GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Instantiate(controls_screen);
        Destroy(gameObject);
    }
}