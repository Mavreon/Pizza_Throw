using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : MonoBehaviour
{
    private float speed = 15.0f;
    public ParticleSystem fireworkParticle;
    public static Pizza pizza;
    public bool canPlaySound;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!(GameManager.gameManager.gameIsCompleted))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            if (transform.position.z >= 30.0f)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameManager.gameManager.AddScore(5);
        Instantiate<ParticleSystem>(fireworkParticle, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
