using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelController : MonoBehaviour
{
    [Header("World Attributes")]
    public float tileLength;
    public float tileWidth;
    public List<GameObject> tilePrefabs;
    public List<GameObject> activeTiles;
    public GameObject startTile;

    [Header("Navigation")]
    NavMeshSurface surface;

    void Awake()
    {
        surface = GetComponent<NavMeshSurface>();
        GenerateWorld();
    }

    // Start is called before the first frame update
    void Start()
    {
        surface.BuildNavMesh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateWorld()
    {
        for (int width = 0; width < tileWidth; width++)
        {
            for (int length = 0; length < tileLength; length++)
            {
                if (activeTiles.Count < 1)
                {
                    activeTiles.Add(startTile);
                    continue;
                }
                else 
                { 
                    var randomTileIndex = Random.Range(0, tilePrefabs.Count);
                    Vector3 randomTilePosition = new Vector3(width * 16, 0f, length * 16);
                    var randomTileRotation = Random.Range(0, 4) * 90.0f;
                    var randomTileObject = Instantiate(tilePrefabs[randomTileIndex], randomTilePosition, Quaternion.Euler(0.0f, randomTileRotation, 0.0f));
                    randomTileObject.transform.parent = this.transform;
                    activeTiles.Add(randomTileObject);
                }
            }
        }
    }
}
