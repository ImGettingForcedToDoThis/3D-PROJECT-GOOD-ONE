using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public float Speed
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (input.GetKeyDown(KeyCode.W))

		{

			transform.Translate (transform.position.z + Speed * Time.deltaTime);


		}
}
