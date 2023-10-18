using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private int spawnInterval = 18;
    private int lastSpawnZ = 25;
    private int SpawnAmount = 10;
    public bool canspawn;
    public bool numberobstacle = true;
    public Transform player;

    public List<GameObject> obstacles;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        canspawn = true;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void SpawnObstacles()
    {
        lastSpawnZ += spawnInterval; 

        for (int i = 0; i < SpawnAmount; i++)
        {
            if (Random.Range(0, 3) == 0 && canspawn)
            {
                GameObject obstacle = obstacles[Random.Range(0, obstacles.Count)];
                Instantiate(obstacle, new Vector3(0, 0.25f, lastSpawnZ), obstacle.transform.rotation);
                GameObject obstacle2 = obstacles[Random.Range(0, obstacles.Count)];
                Instantiate(obstacle2, new Vector3(0, 0.25f, lastSpawnZ -10), obstacle2.transform.rotation);
                canspawn = false;
                StartCoroutine(Spawn());
            }

        }
    }
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(0.2f);
        canspawn = true;
    }
}
