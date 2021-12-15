using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject brickPrefab;
    public int rows;
    public int columns;

    // Start is called before the first frame update
    void Start()
    {
        GenerateLevel();
    }

    void GenerateLevel()
    {
        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < columns; j++)
            {
                var brick = Instantiate(brickPrefab);
                var renderer = brick.GetComponent<Renderer>();
                brick.transform.position = transform.position + (Vector3.right * renderer.bounds.size.x * i) + (Vector3.down * renderer.bounds.size.y * j);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                var renderer = brickPrefab.GetComponent<Renderer>();
                var pos = brickPrefab.transform.position = transform.position + (Vector3.right * renderer.bounds.size.x * i) + (Vector3.down * renderer.bounds.size.y * j);
                Gizmos.DrawWireCube(pos, renderer.bounds.size);
            }
        }
    }
}
