using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    //Properties
    public float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.gameManager.gameIsCompleted)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            if (transform.position.z <= -10.0f)
            {
                Destroy(gameObject);
            }
        }
        
    }
}
