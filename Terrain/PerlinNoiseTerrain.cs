using UnityEngine;

[ExecuteInEditMode]
public class PerlinNoiseTerrain : MonoBehaviour
{
    public int width = 256;
    public int height = 256;

    public float scale = 20f;
    public float heightScale = 60f;

    public int octaves = 6;
    public float persistence = 0.5f;
    public float lacunarity = 2f;

    public float offset = 1000f;

    void Update()
    {
        if (!Application.isEditor)
            return;

        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
    }

    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width, heightScale, height);
        terrainData.SetHeights(0, 0, GenerateHeights());

        return terrainData;
    }

    float[,] GenerateHeights()
    {
        float[,] heights = new float[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                heights[x, y] = CalculateHeight(x, y);
            }
        }
        return heights;
    }

    float CalculateHeight(int x, int y)
    {
        float xCoord = (float)x / width * scale + offset;
        float yCoord = (float)y / height * scale + offset;

        float noiseHeight = 0f;
        float amplitude = 1f;
        float frequency = 1f;

        for (int i = 0; i < octaves; i++)
        {
            float perlinValue = Mathf.PerlinNoise(xCoord * frequency, yCoord * frequency);
            noiseHeight += perlinValue * amplitude;

            amplitude *= persistence;
            frequency *= lacunarity;
        }

        return noiseHeight / octaves;
    }
}
