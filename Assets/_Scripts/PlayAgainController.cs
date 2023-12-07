using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayAgain : MonoBehaviour
{
    public Button yourButton;

    void Start()
    {
        Button btn = gameObject.transform.Find("Button").GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene("FinalMap");
        Destroy(gameObject);
    }
}