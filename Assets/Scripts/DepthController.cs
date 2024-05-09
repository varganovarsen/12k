using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthController : MonoBehaviour
{
    public static DepthController Instance;
    public static float Depth;
    [SerializeField]
    private float startDepth;

    [SerializeField]
    private float _nearestEnder;

    [SerializeField]
    public Location CurrentLocation;
    Queue<Chunk> _chunks;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(Instance);
    }

    private void Start()
    {
        Depth = startDepth;
        _chunks = new Queue<Chunk>(CurrentLocation.chunks);
        LoadNextChunk();

    }

    private void OnEnable()
    {
        WallParallax.OnChunkCompleted += LoadNextChunk;
    }

    private void OnDisable()
    {
        WallParallax.OnChunkCompleted -= LoadNextChunk;
    }

    private void Update()
    {
        
    }

    private void LoadNextChunk()
    {
        ChunkLoader.Instance.LoadChunk(_chunks.Dequeue());
    }

}
