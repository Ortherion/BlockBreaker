using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{

    public bool autoPlay = false;
    public float minX, maxX;
    public Sprite[] paddleSprites;

    private Ball ball;

    void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
        print(ball);
    }
    // Update is called once per frame
    void Update()
    {
        if (!autoPlay)
        {
            MoveWithMouse();
        } else
        {
            AutoPlay();
        }
    }

    void AutoPlay()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        Vector3 ballPos = ball.transform.position;
        paddlePos.x = Mathf.Clamp(ballPos.x, minX, maxX); // minX = 2f, maxX = 30f
        this.transform.position = paddlePos;
    }

    void MoveWithMouse()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        float mousePosInBlocks = (Input.mousePosition.x / Screen.width) * 32;
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, minX, maxX); // minX = 2f, maxX = 30f
        this.transform.position = paddlePos;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        LoadSprite(1);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        LoadSprite(0);
    }

    void LoadSprite(int spriteIndex)
    {
        this.GetComponent<SpriteRenderer>().sprite = paddleSprites[spriteIndex];
        Debug.Log(spriteIndex);
    }
}
