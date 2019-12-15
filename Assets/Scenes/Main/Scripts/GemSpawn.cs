using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawn : MonoBehaviour
{
    private Vector2 spawnPosition;

    private float gemMinSize = 1f;
    private float gemMaxSize = 3f;

    public GameObject spawnArea;

    // Start is called before the first frame update
    void Awake()
    {
        transform.position = GetSpawnPosition();

        // random size
        float size = Random.Range(gemMinSize, gemMaxSize);
        Vector3 randomSize = new Vector3(size, size, 1);
        transform.localScale = randomSize;

        // random rotation
        var euler = transform.eulerAngles;
        euler.z = Random.Range(0f, 360f);
        transform.eulerAngles = euler;
    }

    Vector2 GetSpawnPosition()
    {
        Vector2 origin = spawnArea.transform.position;
        Vector2 range = spawnArea.transform.localScale / 2.0f;
        Vector2 randomRange = new Vector2(Random.Range(-range.x, range.x),
                                          Random.Range(-range.y, range.y));
        Vector2 randomCoordinate = origin + randomRange;

        return randomCoordinate;
    }
}
