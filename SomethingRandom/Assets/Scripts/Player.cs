using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public Camera myCamera;
	public float Speed; 
	public float sensitivity;
	private Vector2 Mymouse;
	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
		Mymouse.x = Input.GetAxis("Mouse X");
		Mymouse.y = Input.GetAxis("Mouse Y");

		transform.eulerAngles += new Vector3(0.0f, Mymouse.x*sensitivity*Time.deltaTime, 0.0f);
		if (Input.GetKey(KeyCode.W))
		{

			transform.Translate (0.0f,0.0f, Speed * Time.deltaTime);


		}

		if (Input.GetKey(KeyCode.A))
		{

			transform.Translate (0.0f,0.0f, - Speed * Time.deltaTime);


		}

		if (Input.GetKey(KeyCode.S))
		{

			transform.Translate (0.0f,0.0f, - Speed * Time.deltaTime);

		}

		if (Input.GetKey(KeyCode.D))
		{

			transform.Translate (0.0f,0.0f,  Speed * Time.deltaTime);


		}

	}
}
