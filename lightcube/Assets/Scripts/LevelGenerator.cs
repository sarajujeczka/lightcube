using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    public Texture2D map;
    public Transform spawnPlace;
    public ColorToPrefab[] colorMappings;
    
	
	void Start () {
        GenerateLevel();
	}

    void GenerateLevel() {
        for (int i = 0; i < map.width; i++) {
            for (int j = 0; j < map.height; j++) {
                GenerateTile(i, j);
            }
        }
    }

    void GenerateTile(int x, int y) {
        Color pixelColor = map.GetPixel(x, y);
        if (pixelColor.a == 0) {
            return;
        }
        foreach (ColorToPrefab colorMapping in colorMappings) {
            if (colorMapping.color.Equals(pixelColor)) {
                Vector3 position = new Vector3(spawnPlace.position.x - x, spawnPlace.position.y + y, 0);
                if (colorMapping.colour == null)
                    Instantiate(colorMapping.prefab, position, Quaternion.identity);
                else {

                    GameObject go = Instantiate(colorMapping.prefab, position, Quaternion.identity);
                    if (pixelColor.a == 50) {
                        go.GetComponent<Enemy>().info = (EnemyInfo)colorMapping.colour;
                    }
                    else
                        go.GetComponent<ColorBrick>().myColor = (Colour)colorMapping.colour;
                }
            }
        }
    }
}

