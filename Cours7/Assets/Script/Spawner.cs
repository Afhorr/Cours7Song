using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    private float timeLeftBeforeSpawn;
    public float spawnRate = 1;
    private SpawnPoint[] spawnPoints;
    public GameObject[] ennemiPrefab;
    // Use this for initialization
    void Start() {
        spawnPoints = FindObjectsOfType<SpawnPoint>();
        timeLeftBeforeSpawn = 1 / spawnRate;

    }
	
	// Update is called once per frame
	void Update () {
        UpdateSysteme();

    }
    public void UpdateSysteme()
    {
        timeLeftBeforeSpawn -= Time.deltaTime;
        if (timeLeftBeforeSpawn <0)
        {
            SpawnEnnemi();
            timeLeftBeforeSpawn = 1 / spawnRate;
        }
    }
    public void SpawnEnnemi()
    {
        int countSpawnPoint = spawnPoints.Length;
        int randomPointIndex = Random.Range(0, countSpawnPoint);
        SpawnPoint spawnPointRandomSelected = spawnPoints[randomPointIndex];
        GameObject newCube = Instantiate(ennemiPrefab[Random.Range(0,2)], spawnPointRandomSelected.GetPosition(), spawnPointRandomSelected.transform.rotation);
    }
}
