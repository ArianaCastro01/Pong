using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using TMPro;

public class BallScript : MonoBehaviour 
{
	public float speed;
	public TMP_Text left;
	public TMP_Text right;
	public float leftScore = 0;
	public float rightScore = 0;

	Rigidbody2D BallRB;

	public Vector2 velocity;
	void Start () 
	{
		BallRB = GetComponent<Rigidbody2D>();
		BallRB.velocity = Vector2.right * speed;
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.name == "LeftRacket") 
		{
			++speed;
			float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
			Vector2 dir = new Vector2(1, y).normalized;
			BallRB.velocity = dir * speed;
		}

		if (col.gameObject.name == "RightRacket") 
		{
			++speed;
			float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
			Vector2 dir = new Vector2(-1, y).normalized;
			BallRB.velocity = dir * speed;
		}

		if (col.gameObject.name == "LeftWall") 
		{
			++rightScore;
			right.text = rightScore.ToString();
		}

		if (col.gameObject.name == "RightWall") 
		{
			++leftScore;
			left.text = leftScore.ToString();
		}
	}

	float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
	{
		return(ballPos.y - racketPos.y) / racketHeight;
	}
}
