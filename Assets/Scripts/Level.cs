using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {


    [SerializeField]int totalAstroids;
    SceneLoader sceneLoader;


    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    public void CountAsteroids()
    {
        totalAstroids++;
    }

    public void AstroidDestroyed()
    {
        totalAstroids--;
        if(totalAstroids==0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
