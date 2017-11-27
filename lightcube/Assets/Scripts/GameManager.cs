using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public bool shouldSpawn = true;
    public GameObject playerPrefab;
    public static GameManager instance;
    public SceneField mainScene;
    public GameObject endCanvas;
    public Text message;
    public Text score;

    public Options[] moves;

    public Vector3 maxMove = new Vector3(6, 3, 0);
    public Vector3 minMove = new Vector3(-6, -2, 0);

    public float worldSpeed = 0.05f;
    public float spawnDuration = 5f;

    public Texture2D map;
    public ColorToSpawn[] spawns;

    public int enemy = 0;

    public GameObject[] winPS;

    float resasp;
    float asp;

    TurretSpawn turretSpawn;
    WallSpawn wallSpawn;
    EnemySpawn enemySpawn;
    Player player;
    Color pixelColor;
    int r = 0;

	void Awake () {
        if (instance == null) {
            instance = this;
        }
        if (instance != this) {
            Destroy(gameObject);
        }
        SetMove();
        player = Instantiate(playerPrefab, new Vector3(maxMove.x, 0, 0), Quaternion.identity, this.transform).GetComponent<Player>();
        turretSpawn = GetComponentInChildren<TurretSpawn>();
        wallSpawn = GetComponentInChildren<WallSpawn>();
        enemySpawn = GetComponentInChildren<EnemySpawn>();
    }

	void Update () {
        if(!Pause.active)
            transform.Translate(worldSpeed * Time.deltaTime, 0, 0);

    }

    public void ReadMap() {
        if (shouldSpawn) {
            if (enemy < 0)
                enemy = 0;
            if (enemy == 0) {
                if (r < map.width) {
                    pixelColor = map.GetPixel(r, 2);
                    if (pixelColor.a == 0) {
                        return;
                    }
                    foreach (ColorToSpawn colorSpawn in spawns) {
                        if (colorSpawn.color.r.Equals(pixelColor.r)) {
                            if (colorSpawn.prefab != null) {
                                if (pixelColor.r == 50) {
                                    Instantiate(colorSpawn.prefab, turretSpawn.transform.position, Quaternion.identity);
                                }
                                else
                                    Instantiate(colorSpawn.prefab, turretSpawn.transform.position, Quaternion.identity);
                            }
                            else {
                                switch (colorSpawn.sp) {
                                    case Spawner.Wall:
                                        wallSpawn.Spawn();
                                        break;
                                    case Spawner.Turret:
                                        turretSpawn.Spawn();
                                        break;
                                    case Spawner.Enemy:
                                        enemySpawn.Spawn();
                                        break;
                                    case Spawner.EnemyWall:
                                        wallSpawn.Spawn();
                                        enemySpawn.Spawn();
                                        break;
                                    case Spawner.TurretWall:
                                        wallSpawn.Spawn();
                                        turretSpawn.Spawn();
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                }
                r++;
            } 
        }
    }

    void SetMove() {
        resasp = Mathf.Round(((float)Screen.width / (float)Screen.height) * 100);
        for (int i = 0; i < moves.Length; i++) {
            asp = Mathf.Round(((float)moves[i].w / (float)moves[i].h) * 100);
            if (asp == resasp) {
                minMove = new Vector3(moves[i].min.x, moves[i].min.y, 0);
                maxMove = new Vector3(moves[i].max.x, moves[i].max.y, 0);
                return;
            }
        }
    }

    public void ResetButton() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void ExitButton() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(mainScene);
    }

    public void EndGame() {
        worldSpeed = 0;
        endCanvas.SetActive(true);
        score.text = "YOUR SCORE: " + player.scoreValue;
        player.StopYourself(true);
        GetComponent<Pause>().enabled = false;
    }

    public void WinGame() {
        InvokeRepeating("SpawnPS", 0, 2);
        worldSpeed = 0;
        endCanvas.SetActive(true);
        message.text = "STAGE CLEAR!";
        score.text = "YOUR SCORE: " + player.scoreValue;
        GetComponent<Pause>().enabled = false;
        player.StopYourself(true);
        player.GetComponent<Animator>().enabled = true;
    }

    void SpawnPS() {
        for (int i = 0; i < Random.Range(1,4); i++) {
            Instantiate(winPS[Random.Range(0, winPS.Length)], transform);
        }
    }
}


[System.Serializable]
public class Options {
    public string name;
    public Vector2 max, min;
    public float w, h;
}

[System.Serializable]
public class ColorToSpawn
{
    public string name;
    public Color color;
    public GameObject prefab;
    public Spawner sp;
}

public enum Spawner {
    Wall, Turret, Enemy, EnemyWall, TurretWall
}