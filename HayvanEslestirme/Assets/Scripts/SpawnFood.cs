using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    public GameObject[] spawnedFood;
    public GameObject[] animals;
    int randomIndex=-1;

    void setRandomIndex()
    {
        int randomindexBefore = randomIndex;
        randomIndex = Random.Range(0, spawnedFood.Length);
        while (randomIndex == randomindexBefore)
        {
            randomIndex = Random.Range(0, spawnedFood.Length);
        }
        
        
    }

    private void Awake()
    {
        GameObject[] temp = GameObject.FindGameObjectsWithTag("DropArea");
        animals = temp;
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in animals)
        {
            item.SetActive(false);
        }
        Spawn();
        
    }

    public void Spawn()
    {
        setRandomIndex();
        
        animals[randomIndex].SetActive(true);
        Instantiate(spawnedFood[randomIndex]);
        
    }
}
