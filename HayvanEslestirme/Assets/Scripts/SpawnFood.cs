using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    public GameObject spawnedFood;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(spawnedFood);
    }

    public void Spawn()
    {
        Instantiate(spawnedFood);
    }
    
}
