using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemManager : MonoBehaviour
{
    public GameObject[] gems;

    private float gemMinSize = 1f;
    private float gemMaxSize = 4f;
    private List<Vector2> spawnPoints = new List<Vector2>();
    private int margin = 100;

    void Awake ()
    {
        for (int i = 0; i < gems.Length; i++)
        {
            GameObject temp = Instantiate(gems[i], transform);

            randomizeSize(temp);
            randomizeRotation(temp);

            temp.transform.position = GetSpawnPosition(i / 3, (i + 1) / 3);
            spawnPoints.Add(temp.transform.position);
        }
    }

    bool containsSpawnPoint(GameObject temp)
    {
        foreach (Vector2 point in spawnPoints)
        {
            /*
            Debug.Log("help: " + temp.name);
            Debug.Log("radius: " + temp.GetComponent<CircleCollider2D>().radius);
            if (temp.GetComponent<CircleCollider2D>().bounds.Contains(point))
            {
                Debug.Log("hello");
                return true;
            }
            */
            Debug.Log("help: " + temp.name);
            if (Physics2D.OverlapCircle(point, 15f, temp.gameObject.layer))
            {
                Debug.Log("halp: " + temp.name);
                return true;
            }
        }

        return false;
    }

    Vector2 GetSpawnPosition(int x_factor, int y_factor)
    {
        float spawnX = Random.Range
            (Camera.main.ScreenToWorldPoint(new Vector2(margin + (Screen.width - margin) * x_factor, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2((Screen.width - margin) * y_factor, 0)).x);
        float spawnY = Random.Range
            (Camera.main.ScreenToWorldPoint(new Vector2(0, margin)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height - margin)).y);

        return new Vector2(spawnX, spawnY);
    }

    void randomizeSize(GameObject gem)
    {
        float size = Random.Range(gemMinSize, gemMaxSize);
        Vector3 randomSize = new Vector3(size, size, 1);
        gem.transform.localScale = randomSize;
    }

    void randomizeRotation(GameObject gem)
    {
        var euler = gem.transform.eulerAngles;
        euler.z = Random.Range(0f, 360f);
        gem.transform.eulerAngles = euler;
    }
}
