using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{

    [SerializeField]
    GameObject carPrefab;

    [SerializeField]
    float spawnTimer = 2.0f;

    Vector2 leftEdge;
    Vector2 rightEdge;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= spawnTimer)
        {
            SpawnCar( new Vector2(leftEdge.x, this.transform.position.y));
            timer = 0.0f;
        }
    }

    void SpawnCar(Vector2 position)
    {
        //GameObject.Instantiate(carPrefab, position, Quaternion.identity); // We replace our instancing with calling a return object from our pool using the key "cars"

        ObjectPoolManager.Instance().ReturnObject("cars", position, Quaternion.identity);
    }
}
