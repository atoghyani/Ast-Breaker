using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptAsteroid : MonoBehaviour 
{
    [SerializeField] AudioClip audioClip;

    Level level; //cached refrence
    GameStatus gameStatus;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AstroidDestroyed();
    }

    private void AstroidDestroyed()
    {
        gameStatus.AddToScore();
        Destroy(gameObject);
        level.AstroidDestroyed();
        AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position);
    }

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.CountAsteroids();
        gameStatus = FindObjectOfType<GameStatus>();

    }

}
