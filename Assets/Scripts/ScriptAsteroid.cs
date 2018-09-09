using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptAsteroid : MonoBehaviour 
{
    //config parameters
    [SerializeField] AudioClip audioClip;
    [SerializeField] GameObject sparksVFX;
    [SerializeField] int maxHits;
    [SerializeField] Sprite[] hitSprites;


    //cached refrence
    Level level;

    //state variables

    [SerializeField] int timesHit; //TODO only serialized for debug purposes 



    GameStatus gameStatus;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            timesHit++;
            if (timesHit == maxHits)
            {
                AstroidDestroyed();
            }
            else
            {
                showNextHitSprite();
            }
        }
    }

    private void showNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.Log("Sprite Not added");
        }

    }
       
    private void AstroidDestroyed()
    {
         
        gameStatus.AddToScore();
        Destroy(gameObject);
        level.AstroidDestroyed();
        AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position);
        TriggerSaprksVFX();
     }

    private void Start()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountAsteroids();
        }
        gameStatus = FindObjectOfType<GameStatus>();

    }

    private void TriggerSaprksVFX()
    {
        GameObject sparks = Instantiate(sparksVFX,transform.position,transform.rotation);
        Destroy(sparks, 2);
    }

}
