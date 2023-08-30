using System.Collections.Generic;
using UnityEngine;

public class PathSystem : MonoBehaviour
{
    private static PathSystem instance;
    public static PathSystem Instance { get { return instance; } }

    public List<Edge> edges = new List<Edge>();

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}