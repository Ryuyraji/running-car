/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    // Start is called before the first frame update
    private void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacle();
    }

    /*private void Start()
    {
        // groundSpawner.GameObject.FindObjectType<GroundSpawner>();
        SpawnObstacle();

    }*/
/*
    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public GameObject obstaclePreFabs;
    void SpawnObstacle()
    {
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPont = transform.GetChild(obstacleSpawnIndex).transform;
        Instantiate(obstaclePreFabs, spawnPont.position,Quaternion.identity,transform);
    }
}
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    private GroundSpawner groundSpawner;
    public GameObject obstaclePreFabs;

    private void Awake()
    {
        groundSpawner = FindObjectOfType<GroundSpawner>();
    }

    private void Start()
    {
        SpawnObstacle();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2f);
    }

    void SpawnObstacle()
    {
        int obstacleSpawnIndex = Random.Range(2, 5);
        if (transform.childCount > obstacleSpawnIndex)
        {
            Transform spawnPoint = transform.GetChild(obstacleSpawnIndex);
            Instantiate(obstaclePreFabs, spawnPoint.position, Quaternion.identity, transform);
        }
        else
        {
            Debug.LogError("Obstacle spawn index out of range!");
        }
    }
}
