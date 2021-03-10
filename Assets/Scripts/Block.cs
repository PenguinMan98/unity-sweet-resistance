using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] int pointsForBreaking = 10;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] int maxHits = 2;
    [SerializeField] Sprite[] hitSprites;

    // cached reference
    Level level;
    GameSession gameStatus;

    // state variables
    [SerializeField] int timesHit = 0; // TODO: remove serialization

    void Start()
    {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameSession>();
        
        if(tag == "Breakable")
        {
            level.registerBlock();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit += 1;
        if (timesHit >= maxHits)
        {
            breakBlock();
        } else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        // TODO: handle hits of 4 or more
        int spriteIndex = Mathf.Clamp(maxHits - timesHit - 1, 0, maxHits);
        if(hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
    }

    private void breakBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position, 1f);
        gameStatus.updateScore(pointsForBreaking);
        Destroy(gameObject, .1f);
        TriggerSparkles();
        level.destroyBlock();
    }

    private void TriggerSparkles()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
