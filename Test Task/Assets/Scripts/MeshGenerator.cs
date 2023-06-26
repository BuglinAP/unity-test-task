using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{
    private bool[,,] cubeExistenceArray;
    [SerializeField] private Vector3 cubeSize = Vector3.one;

    private void Start()
    {
        GenerateRandomCubeExistenceArray();
        GenerateMesh();
    }

    private void GenerateRandomCubeExistenceArray()
    {
        cubeExistenceArray = new bool[6, 6, 6];

        for (int x = 0; x < cubeExistenceArray.GetLength(0); x++)
        {
            for (int y = 0; y < cubeExistenceArray.GetLength(1); y++)
            {
                for (int z = 0; z < cubeExistenceArray.GetLength(2); z++)
                {
                    cubeExistenceArray[x, y, z] = Random.value < 0.5f;
                }
            }
        }
    }

    private void GenerateCubeMesh(Vector3 position, Vector3 size, List<Vector3> vertices, List<int> triangles, List<Vector3> normals)
    {
        // Вершины куба
        Vector3[] cubeVertices =
        {
            // Нижняя грань
            position + new Vector3(0, 0, 0),
            position + new Vector3(size.x, 0, 0),
            position + new Vector3(size.x, 0, size.z),
            position + new Vector3(0, 0, size.z),
            // Верхняя грань
            position + new Vector3(0, size.y, 0),
            position + new Vector3(size.x, size.y, 0),
            position + new Vector3(size.x, size.y, size.z),
            position + new Vector3(0, size.y, size.z)
        };
        vertices.AddRange(cubeVertices);

        // Треугольники для куба
        int[] cubeTriangles =
        {
            // Нижняя грань
            0, 1, 2,
            0, 2, 3,
            // Верхняя грань
            5, 4, 7,
            5, 7, 6,
            // Боковые грани
            1, 5, 6,
            1, 6, 2,
            4, 0, 3,
            4, 3, 7,
            4, 5, 1,
            4, 1, 0,
            3, 2, 6,
            3, 6, 7
        };
        foreach (int triangleIndex in cubeTriangles)
        {
            triangles.Add(triangleIndex + vertices.Count - cubeVertices.Length);
        }

        // Нормали для куба
        Vector3[] cubeNormals =
        {
            Vector3.down,
            Vector3.down,
            Vector3.down,
            Vector3.down,
            Vector3.up,
            Vector3.up,
            Vector3.up,
            Vector3.up
        };
        normals.AddRange(cubeNormals);
    }

    public void GenerateMesh()
    {
        Mesh mesh = new Mesh();

        // Списки для хранения вершин, треугольников и нормалей
        var vertices = new List<Vector3>();
        var triangles = new List<int>();
        var normals = new List<Vector3>();

        for (int x = 0; x < cubeExistenceArray.GetLength(0); x++)
        {
            for (int y = 0; y < cubeExistenceArray.GetLength(1); y++)
            {
                for (int z = 0; z < cubeExistenceArray.GetLength(2); z++)
                {
                    if (cubeExistenceArray[x, y, z])
                    {
                        Vector3 cubePosition = new Vector3(x * cubeSize.x, y * cubeSize.y, z * cubeSize.z);

                        GenerateCubeMesh(cubePosition, cubeSize, vertices, triangles, normals);
                    }
                }
            }
        }

        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.normals = normals.ToArray();

        MeshFilter meshFilter = GetComponent<MeshFilter>();
        meshFilter.sharedMesh = mesh;
    }
}