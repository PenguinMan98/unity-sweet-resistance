using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int blockCount = 0;

    // cached reference
    SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        blockCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void registerBlock() // CountBreakableBlocks
    {
        blockCount += 1;
    }

    public void destroyBlock() // BlockDestroyed
    {
        blockCount -= 1;
        if(blockCount <= 0)
        {
            // player wins
            sceneLoader.LoadNextScene();
        }
    }
}
