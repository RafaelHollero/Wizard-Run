using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionController : MonoBehaviour
{
    private float timePassed = 0f;
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if(timePassed >= 2)
        {
            timePassed = 0f;
            Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
        }
         
    }
}
