using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroScript : MonoBehaviour
{

	//Rigidbody rb;
	//float dirX;
	//float moveSpeed = 20f;

	[SerializeField] private UIManager _UIManager;
	private float xAcc;
	private float zRotAngle;

	// Use this for initialization
	void Start()
	{
		//rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
		//dirX = Input.acceleration.x * moveSpeed;
		//transform.position = new Vector2(Mathf.Clamp(transform.position.x, -7.5f, 7.5f), transform.position.y);

		xAcc = Input.acceleration.x;
		zRotAngle = xAcc * -90; // From [-1,1] phone acceleration to [90,-90] angle
		Quaternion rotation = Quaternion.Euler(0,0,zRotAngle); 
		transform.rotation = rotation;

		_UIManager.getGyroX(xAcc);
	}

	void FixedUpdate()
	{
		//rb.velocity = new Vector2(dirX, 0f);
	}
}
