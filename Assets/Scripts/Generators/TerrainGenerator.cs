/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using UnityEngine;

public class TerrainGenerator
{
    private const string c_terrainName = "Terrain";
    private static GameObject s_terrain
    {
        get
        {
            return GameObject.Find(c_terrainName);
        }

        set
        {

        }
    }

    #region Public Methods
    /// <summary>
    /// Генерирует террейн из кубов на основе карты высот.
    /// </summary>
    /// <param name="heightMap">Карта высот для генерации террейна.</param>
    public static void Generate(Texture2D heightMap)
    {
        Clear();

        s_terrain = new GameObject(c_terrainName);

        for (int x = 0; x < heightMap.width; x++)
        {
            for (int z = 0; z < heightMap.height; z++)
            {
                var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

                var y = Mathf.Floor(heightMap.GetPixel(x, z).grayscale * 10.0f);

                cube.transform.position = new Vector3(x, y, z);
                cube.transform.SetParent(s_terrain.transform);
            }
        }
    }

    /// <summary>
    /// Очищает предыдущую генерацию террейна на основе поиска родительско
    /// объекта по имени.
    /// </summary>
    public static void Clear()
    {
        if (s_terrain != null)
        {
            Object.DestroyImmediate(s_terrain);
        }
    }
    #endregion
}