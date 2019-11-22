using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	private bool hasStarted =  false;
	// config parameters
	[SerializeField] Paddle paddle1;
	[SerializeField] float xPush = 2f;
	[SerializeField] float yPush = 15f;
	
	
	//state
	Vector2 paddleToBallVector;
	
    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
		if(!hasStarted)
		{
			LockBallToPaddle();
			LaunchBallOnMouseClick();	
		}
    }
	
	private void LockBallToPaddle()
	{
		// places the ball on the paddle
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
		transform.position = paddlePos + paddleToBallVector;		
	}
	
	private void LaunchBallOnMouseClick()
	{
		// left click
		if(Input.GetMouseButtonDown(0))
		{
			hasStarted = true;
			Debug.Log("Left mouse clicked");
			GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
		}
	}
}
