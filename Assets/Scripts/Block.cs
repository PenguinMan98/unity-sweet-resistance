using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] int pointsForBreaking = 10;

        // cached reference
    Level level;
    GameStatus gameStatus;

    void Start()
    {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameStatus>();
        
        level.registerBlock();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        breakBlock();
    }

    private void breakBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position, 1f);
        gameStatus.updateScore(pointsForBreaking);
        Destroy(gameObject, .2f);
        level.destroyBlock();
    }
}
