using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkLoader : MonoBehaviour
{
    public static ChunkLoader Instance;

    WallParallax wall;

    [SerializeField]
    private Transform chunkParent;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(Instance);

        wall = GetComponent<WallParallax>();
    }

    private void UnloadChunk()
    {
        for (int i = 0; i < chunkParent.childCount; i++)
        {
            Destroy(chunkParent.GetChild(i).gameObject);
        }
    }
    public void LoadChunk(Chunk chunk)
    {
        UnloadChunk();

        wall.SetFillerSize(chunk.chunkSize);

        if(chunk.obstacles.Count <1)
            return;

        foreach (var obstacle in chunk.obstacles)
        {
           var go = Instantiate(obstacle.obstaclePrefab, new Vector3(0, WallParallax.Filler.position.y - obstacle.depth), Quaternion.identity);
            go.transform.parent = chunkParent;
        }
    }
}
