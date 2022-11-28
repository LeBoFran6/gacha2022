using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroScript : MonoBehaviour
{

	[SerializeField] private UI_GyroIndicator gyroIndicator;
	private float xAcc;
	private float zRotAngle;
	private float currentzRotAngle;
    public float pitch;
    public float lerp = 0.1f;

    public float scale = 0.8f;

	void Update()
	{
		currentzRotAngle = Mathf.Lerp(currentzRotAngle, zRotAngle, lerp);
        xAcc = Input.acceleration.x * scale;
		zRotAngle = xAcc * -90; // From [-1,1] phone acceleration to [90,-90] angle
		Quaternion rotation = Quaternion.Euler(pitch, 0,zRotAngle); 
		transform.rotation = rotation;

        gyroIndicator.UpdateView(zRotAngle);
	}
}
