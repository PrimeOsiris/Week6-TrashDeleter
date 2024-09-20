using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class MeshGenerator : MonoBehaviour
{
    Mesh mesh;
    public int xSize = 20;
    public int zSize = 20;
    private Vector3[] vertices;
    private int[] triangles;

    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();
    }

    void CreateShape()
    {
        //vertex count formula = (xSize +1) * (zSize + 1);
        vertices = new Vector3[(xSize +1) * (zSize + 1)];
        
        for (int index = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float y = Mathf.PerlinNoise(x * 0.4f, z*.1f)*2f;
                vertices[index] = new Vector3(x,y,z);
                index++;
            }
        }

        int vert = 0;
        int tri = 0;
        triangles = new int[xSize * zSize * 6];
        
        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                //triangles = new int[3];
                triangles[tri + 0] = vert + 0;
                triangles[tri + 1] = vert + xSize + 1;
                triangles[tri + 2] = vert + 1;
                triangles[tri + 3] = vert + 1;
                triangles[tri + 4] = vert + xSize + 1;
                triangles[tri + 5] = vert + xSize + 2;
                tri += 6;
                vert++;
            }
            vert++;
        }
    }

    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }

    private void OnDrawGizmos()
    {
        if(vertices==null) return;
        for (int i = 0; i < vertices.Length; i++){
            Gizmos.DrawSphere(vertices[1], .1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
