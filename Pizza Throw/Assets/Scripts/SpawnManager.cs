using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Properties...
    public GameObject[] animals;
    int animalIndex;
    int positionIndex;
    private float[] spawnPosition = { -10.0f, 0.0f, 10.0f };

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnAnimal", 3.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnAnimal()
    {
        animalIndex = Random.Range(0, animals.Length);
        positionIndex= Random.Range(0, spawnPosition.Length);
        Instantiate<GameObject>(animals[animalIndex], new Vector3(spawnPosition[positionIndex], transform.position.y, transform.position.z), transform.rotation);
    }
}
