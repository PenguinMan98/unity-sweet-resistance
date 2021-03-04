using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int blockCount = 0;
    [SerializeField] int destroyedBlocks = 0;

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

    public void registerBlock()
    {
        blockCount += 1;
    }

    public void destroyBlock()
    {
        destroyedBlocks += 1;
        if (blockCount == destroyedBlocks)
        {
            // player wins
            sceneLoader.LoadNextScene();
        }
    }
}
