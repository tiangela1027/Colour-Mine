using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourRandomizer : MonoBehaviour
{
    private static Color color1 = new Color(0.9f, 0.2f, 0.4f);
    private static Color color2 = new Color(0.9f, 0.6f, 0.7f);
    private static Color color3 = new Color(0.5f, 0.8f, 1.0f);
    private static Color color4 = new Color(0.3f, 0.6f, 0.8f);

    public static Color[] Colors = new Color[4] { color1, color2, color3, color4 };
    public int index;

    void Awake()
    {
        index = Random.Range(0, Colors.Length);
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Colors[index];
    }

    public static void changeRandom(List<GameObject> notSameColor)
    {
        List<GameObject> visited = new List<GameObject>();

        for (int i = 0; i < notSameColor.ToArray().Length; i++)
        {
            if (notSameColor[i] != null && !visited.Contains(notSameColor[i]))
            {
                Color curr = notSameColor[i].GetComponent<SpriteRenderer>().color; // = Colors[Random.Range(0, Colors.Length)];

                if (curr == Colors[0]) 
                    notSameColor[i].GetComponent<SpriteRenderer>().color = Colors[1];
                if (curr == Colors[1])
                    notSameColor[i].GetComponent<SpriteRenderer>().color = Colors[2];
                if (curr == Colors[2])
                    notSameColor[i].GetComponent<SpriteRenderer>().color = Colors[3];
                if (curr == Colors[3])
                    notSameColor[i].GetComponent<SpriteRenderer>().color = Colors[0];

                visited.Add(notSameColor[i]);
            }
        }

        notSameColor.Clear();
    }
}
