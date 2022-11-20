using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBomb : MonoBehaviour
{
    public GameObject[] spawnObjects;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < spawnObjects.Length; i++)
        {
            //float spawnY = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
            float spawnY = Random.Range(13, 32);
            //float spawnX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
            float spawnX = Random.Range(75, 970);
            Vector2 spawnPosition = new Vector2(spawnX, spawnY);
            Instantiate(spawnObjects[i], spawnPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
