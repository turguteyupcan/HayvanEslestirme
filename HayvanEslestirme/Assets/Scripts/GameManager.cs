using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Dictionary<AnimalsEnum, FoodsEnum> perfectAnimalCombination = new Dictionary<AnimalsEnum, FoodsEnum>();
    public Dictionary<AnimalsEnum, FoodsEnum> averageAnimalCombination = new Dictionary<AnimalsEnum, FoodsEnum>();

    public static GameObject gameManager;

    public GameObject canvas;

    void PerfectCondition()
    {
        perfectAnimalCombination.Add(AnimalsEnum.Cat, FoodsEnum.Fish);
        perfectAnimalCombination.Add(AnimalsEnum.Dog, FoodsEnum.Bone);
        perfectAnimalCombination.Add(AnimalsEnum.Monkey, FoodsEnum.Banana);
        perfectAnimalCombination.Add(AnimalsEnum.Rabbit, FoodsEnum.Carrot);
    }

    void AverageCondition()
    {
        averageAnimalCombination.Add(AnimalsEnum.Cat, FoodsEnum.Bone);
        averageAnimalCombination.Add(AnimalsEnum.Dog, FoodsEnum.Fish);
        averageAnimalCombination.Add(AnimalsEnum.Monkey, FoodsEnum.Carrot);
        averageAnimalCombination.Add(AnimalsEnum.Rabbit, FoodsEnum.Banana);
    }

    public CombinationResult CompareCombination(AnimalsEnum myAnimal, FoodsEnum myFood)
    {
        if (perfectAnimalCombination[myAnimal] == myFood)
        {
            return CombinationResult.Perfect;
        }
        else if (averageAnimalCombination[myAnimal] == myFood)
        {
            return CombinationResult.Average;
        }

        return CombinationResult.Poor;
    }

    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("GameManager");
                go.AddComponent<GameManager>();
            }

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
        PerfectCondition();
        AverageCondition();

        if (gameManager != null)
            gameManager = this.gameObject;

    }
    

    
}
