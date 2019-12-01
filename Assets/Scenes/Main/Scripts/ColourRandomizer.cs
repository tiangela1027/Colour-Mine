using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourRandomizer : MonoBehaviour
{
    public static Color[] Colors = new Color[4] { new Color(0.9f, 0.2f, 0.4f), new Color(0.9f, 0.6f, 0.7f), new Color(0.5f, 0.8f, 1.0f), new Color(0.3f, 0.6f, 0.8f) };
    public int index;

    void Awake()
    {
        index = Random.Range(0, Colors.Length);
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Colors[index];
    }

    public static void changeRandom(List<GameObject> notSameColor)
    {
        for (int i = 0; i < notSameColor.ToArray().Length; i++)
        {
            if (notSameColor[i] != null)
                notSameColor[i].GetComponent<SpriteRenderer>().color = Colors[Random.Range(0, Colors.Length)];
        }

        notSameColor.Clear();
    }
}
