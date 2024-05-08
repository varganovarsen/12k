using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthController : MonoBehaviour
{
    public static DepthController Instance;
    public static float Depth;
    [SerializeField]
    private float startDepth;

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
    }

}
