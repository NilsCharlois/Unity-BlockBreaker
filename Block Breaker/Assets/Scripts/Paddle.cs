using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
	[SerializeField] float screenWidthInUnits = 16f;
	[SerializeField] float minX = 1f;
	[SerializeField] float maxX = 15f;
	
	// cached references
	GameStatus gameStatus;
	Ball ball;
	
    // Start is called before the first frame update
    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
		ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
		// moves the paddle based on mouse position on the x axis
		// need to understand more about units and unity units
		Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
		paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
		transform.position = paddlePos;
    }
	
	private float GetXPos()
	{
		if(gameStatus.IsAutoPlayEnabled())
		{
			return ball.transform.position.x;
		}
		else
		{
			return Input.mousePosition.x / Screen.width * screenWidthInUnits;
		}
	}
}
