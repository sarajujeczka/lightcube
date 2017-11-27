using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawn : MonoBehaviour {

    ColorBrick cb;
    int r, i = 0;

    public Texture2D map;
    public ColorToPrefab[] colorMappings;
    GameObject go;
    ColorToPrefab random;
    Color pixelColor;

    public void Spawn() {
        if (i >= map.width)
            i = map.width - 1;
        GenerateLevel();
        i++;
    }

    void GenerateLevel() {
        for (int j = 0; j < map.height; j++) {
            GenerateTile(i, j);
        }

    }

    void GenerateTile(int x, int y) {
        pixelColor = map.GetPixel(x, y);
        if (pixelColor.a == 0) {
            return;
        }
        foreach (ColorToPrefab colorMapping in colorMappings) {
            if (colorMapping.color.Equals(pixelColor)) {
                Vector3 position = new Vector3(transform.position.x - x, GameManager.instance.minMove.y + y, 0);
                if (pixelColor.r == 0) {
                    random = colorMappings[Random.Range(1, colorMappings.Length)];
                    if (random.colour == null) {
                        Instantiate(random.prefab, position, Quaternion.identity);
                    }
                    else {
                        go = Instantiate(random.prefab, position, Quaternion.identity);
                        go.GetComponent<ColorBrick>().myColor = (Colour)random.colour;
                    } 
                }
                else if (colorMapping.colour == null)
                    Instantiate(colorMapping.prefab, position, Quaternion.identity);
                else {
                    go = Instantiate(colorMapping.prefab, position, Quaternion.identity);
                    go.GetComponent<ColorBrick>().myColor = (Colour)colorMapping.colour;
                }
            }
        }
    }
}

[System.Serializable]
public class ColorToPrefab
{
    public string name;
    public Color color;
    public GameObject prefab;
    public ScriptableObject colour;
}