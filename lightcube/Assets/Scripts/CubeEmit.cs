using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEmit : MonoBehaviour {

    public Cube cube;
    public bool shouldPrewarm = false;
    public float duration, cubeMinMSpeed, cubeMaxMSpeed, cubeMinRSpeed, cubeMaxRSpeed, cubeLife;
    public int maxCubes = 1, cubesPerDuration = 1;
    public Vector3 minPosition, maxPosition;

    public List<Cube> cubes;

	void Start () {
        if (shouldPrewarm) {
            for (int i = 0; i < Random.Range(1, cubesPerDuration); i++) {
                FindOrGenerateCube();
            }
            shouldPrewarm = false;
        }

        InvokeRepeating("Emit", 0, duration);
	}

    void Emit() {
        for (int i = 0; i < Random.Range(1, cubesPerDuration); i++) {
            FindOrGenerateCube();
        }

    }


	void FindOrGenerateCube () {
        for (int i = 0; i < cubes.Count; i++) {
            if (cubes[i].isFree) {
                SetCube(cubes[i]);
                return;
            }
        }
        if (cubes.Count <= maxCubes) {
            Cube newCube = (Cube)Instantiate(cube);
            cubes.Add(newCube);
            SetCube(newCube);
        }
    }

    void SetCube(Cube cube) {
        cube.SetCube(Random.Range(cubeMinMSpeed, cubeMaxMSpeed), Random.Range(cubeMinRSpeed, cubeMaxRSpeed), cubeLife, transform.up);
        if (shouldPrewarm)
            cube.transform.position = new Vector3(Random.Range(maxPosition.x/6, maxPosition.x), Random.Range(minPosition.y, maxPosition.y), Random.Range(minPosition.z, maxPosition.z));
        else
            cube.transform.position = new Vector3(transform.position.x-20, Random.Range(minPosition.y, maxPosition.y), Random.Range(minPosition.z, maxPosition.z));
    }
}
