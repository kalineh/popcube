using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(BlockGenerate))]
public class BlockGenerateEditor
    : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var self = target as BlockGenerate;

        if (GUILayout.Button("Generate"))
            self.Generate();
        if (GUILayout.Button("Cleanup"))
            self.CleanupEditor();
    }
}
#endif

public class BlockGenerate
    : MonoBehaviour
{
    public GameObject prefabBlock;

    public int dimX;
    public int dimY;
    public int dimZ;
    public float spacing;

    public void OnEnable()
    {
        Cleanup();
        Generate();
    }

    public void Generate()
    {
        for (int z = 0; z < dimZ; ++z)
        {
            for (int y = 0; y < dimY; ++y)
            {
                for (int x = 0; x < dimX; ++x)
                {
                    var obj = GameObject.Instantiate(prefabBlock, transform);
                    var pos = new Vector3(
                        dimX * spacing * 1.0f / dimX * x + dimX * spacing * -0.5f + spacing * 0.5f,
                        dimY * spacing * 1.0f / dimY * y + dimY * spacing * -0.5f + spacing * 0.5f,
                        dimZ * spacing * 1.0f / dimZ * z + dimZ * spacing * -0.5f + spacing * 0.5f
                    );

                    obj.transform.localPosition = pos;
                }
            }
        }
    }

    public void Cleanup()
    {
        for (int i = 0; i < transform.childCount; ++i)
            Destroy(transform.GetChild(i).gameObject);
    }

    public void CleanupEditor()
    {
        while (transform.childCount > 0)
            DestroyImmediate(transform.GetChild(0).gameObject);
    }

    public void Update()
    {
        transform.Rotate(Vector3.up, 2.0f * Time.deltaTime, Space.World);
    }
}
