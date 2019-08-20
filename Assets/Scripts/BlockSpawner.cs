using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockColorManager : MonoBehaviour {
    public Shape[] shapePrefabs;
    public Transform[] spawnLocations;

    public Color[] colors =
    {
        Color.blue, Color.cyan, Color.gray, Color.green, Color.magenta, Color.red, Color.white, Color.yellow
    };

    void Awake()
    {
        foreach (Shape shape in shapePrefabs)
        {
            int numShapes = Random.Range(1, 5);
            for (int i = 0; i < numShapes; i++)
            {
                if (!shape.isOpening)
                {
                    GameObject block = Instantiate(shape.gameObject, spawnLocations[Random.Range(0, spawnLocations.Length)], false);
                    block.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Random.value, Random.value);
                    block.GetComponent<Renderer>().material.color = colors[Random.Range(0, colors.Length)];
                }
            }
        }
    }
}
