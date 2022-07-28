using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Food : MonoBehaviour
{
    Vector3 offset;
    [SerializeField]
    public FoodsEnum myFoodName = new FoodsEnum();
    public GameObject spawnedFood;

    public GameObject imagePrefab;

    private void Start()
    {
        spawnedFood = GameObject.Find("FoodSpawner");
    }

    private void OnMouseDown()
    {
        
        offset = transform.position-MouseWorldPosition();
        transform.GetComponent<Collider>().enabled = false;
        
    }

    private void OnMouseDrag()
    {
        transform.position = MouseWorldPosition()+offset;
        transform.Rotate(0, 0, 1f);
    }

    private void OnMouseUp()
    {
        var rayOrigin = Camera.main.transform.position;
        var rayDirection = MouseWorldPosition() - Camera.main.transform.position;
        RaycastHit hitInfo;
        if (Physics.Raycast(rayOrigin,rayDirection, out hitInfo))
        {
            if (hitInfo.transform.tag == "DropArea")
            {
                transform.position = hitInfo.transform.position;
                //Destroy(transform.gameObject);

                var _tempComparisonResult = GameManager.Instance.CompareCombination(hitInfo.collider.gameObject.GetComponent<Animal>().myAnimalName, myFoodName);
                GameObject image = Instantiate(imagePrefab) as GameObject;

                image.transform.SetParent(GameManager.Instance.canvas.transform, false);
                Text theText = image.transform.GetComponentInChildren<Text>();
                
                if (_tempComparisonResult == CombinationResult.Perfect)
                {
                    theText.text = "Perfect";
                }
                else if (_tempComparisonResult == CombinationResult.Average)
                {
                    theText.text = "Average";
                }
                else
                {
                    theText.text = "Poor";
                }
                Destroy(transform.gameObject);

                
                Vector2 screenXY = Camera.main.WorldToScreenPoint(transform.position);
                image.GetComponent<RectTransform>().position = screenXY;

                Destroy(image, 1f);
                
            }
        }
        else
        {
            transform.DOMove(new Vector3(0, 0, 0), 0.3f);
            transform.DORotate(new Vector3(0, 0, 0), 0.3f);
        }

        transform.GetComponent<Collider>().enabled=true;
    }
    Vector3 MouseWorldPosition()
    {
        var MouseScreenPos= Input.mousePosition;
        MouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(MouseScreenPos);
    }

    public static bool isQuit = false;
    private void OnApplicationQuit()
    {
        isQuit = true;
    }
    private void OnDestroy()
    {
        if (!isQuit)
        {
            spawnedFood.GetComponent<SpawnFood>().Spawn();
        }
    }
}
