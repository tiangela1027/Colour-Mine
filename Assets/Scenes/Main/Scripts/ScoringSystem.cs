using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    private static int pointsPerSquare = 100;
    private static int penalty = 150;
    private static int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void AddToScore(int patchSize)
    {
        score += pointsPerSquare;
        GameObject.FindGameObjectWithTag("Score").GetComponent<Text>().text = score.ToString();
    }

    public static void DeleteFromScore()
    {
        score -= penalty;
        GameObject.FindGameObjectWithTag("Score").GetComponent<Text>().text = score.ToString();
    }
}
