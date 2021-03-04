using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;

        // cached reference
    Level level;

    void Start()
    {
        level = FindObjectOfType<Level>();
        level.registerBlock();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        breakBlock();
    }

    private void breakBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position, 1f);
        Destroy(gameObject, .2f);
        level.destroyBlock();
    }
}
