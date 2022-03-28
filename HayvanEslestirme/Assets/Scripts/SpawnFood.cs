using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    public GameObject[] spawnedFood;
    int randomIndex;

    void setRandomIndex()
    {
        //int randomindexBefore = randomIndex;
        randomIndex = Random.Range(0, spawnedFood.Length);
        //while (randomIndex != randomindexBefore)
        //{
        //    randomIndex = Random.Range(0, spawnedFood.Length);
        //}
        Debug.Log("RandomIndex: " + randomIndex);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        setRandomIndex();
        //Debug.Log("FoodNumber: "+randomIndex);
        Instantiate(spawnedFood[randomIndex]);
    }
}
