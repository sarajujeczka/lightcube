using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    ColorBrick cb;
    int r, i = 0;

    public Texture2D map;
    public ColorToPrefab[] colorMappings;
    GameObject go;
    ColorToPrefab random;

    void Start() {
    }

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
        Color pixelColor = map.GetPixel(x, y);
        if (pixelColor.a == 0) {
            return;
        }
        foreach (ColorToPrefab colorMapping in colorMappings) {
            if (colorMapping.color.Equals(pixelColor)) {
                Vector3 position = new Vector3(transform.position.x - x, GameManager.instance.minMove.y + y, 0);
                if (pixelColor.r == 0) {
                    random = colorMappings[Random.Range(1, colorMappings.Length)];
                    go = Instantiate(random.prefab, position, Quaternion.identity);
                    go.GetComponent<Enemy>().myColour = (Colour)random.colour;
                }
                else {
                    go = Instantiate(colorMapping.prefab, position, Quaternion.identity);
                    go.GetComponent<Enemy>().myColour = (Colour)colorMapping.colour;
                }
            }
        }
    }
}
