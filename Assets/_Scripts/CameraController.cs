using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Vector2 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player != null)
        {
            if (player.transform.position.x + offset.x >= 0)
            {
                Vector3 newPos = new Vector3(
                    player.transform.position.x + offset.x,
                    0,
                    -10.0f
                    );
                transform.position = newPos;
            }
            else
            {
                Vector3 newPos = new Vector3(
                    0, transform.position.y,
                    -10.0f
                    );
                transform.position = newPos;
            }
        }
    }
}
