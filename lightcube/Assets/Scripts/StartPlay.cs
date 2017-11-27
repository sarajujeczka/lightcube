using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPlay : MonoBehaviour {

    public SceneField scene;
    public GameObject instructions;


    private void OnMouseDown() {
        instructions.SetActive(true);
        instructions.GetComponent<Animator>().SetTrigger("Do");
    }

    public void GoPlay() {
        SceneManager.LoadScene(scene);
    }
}
