using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidth = 16f;
    [SerializeField] float paddleMin = 1f;
    [SerializeField] float paddleMax = 15f;

    // cached references
    GameSession myGameSession;
    Ball myBall;

    // Start is called before the first frame update
    void Start()
    {
        myGameSession = FindObjectOfType<GameSession>();
        myBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), paddleMin, paddleMax);
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if (myGameSession.IsAutoPlayEnabled())
        {
            return myBall.transform.position.x;
        }
        return Input.mousePosition.x / Screen.width * screenWidth;
    }
}
