using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Properties...
    public float speed = 10.0f;
    public GameObject pizza;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x >= -10.0f && transform.position.x <= 10.0f)
        {
            transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        }
        else if(transform.position.x <= -10.0f && Input.GetAxis("Horizontal") > 0)
        {
            transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        }
        else if (transform.position.x >= 10.0f && Input.GetAxis("Horizontal") < 0)
        {
            transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate<GameObject>(pizza, new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z + 1.0f), transform.rotation);
        }
    }
}
