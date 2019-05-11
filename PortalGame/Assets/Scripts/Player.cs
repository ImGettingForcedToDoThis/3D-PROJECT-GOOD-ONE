using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera myCamera;
    public float Speed;
    public float JumpStrength;
    public float Sensitivity;
    public GameObject Blueportal;
    public GameObject Orangeportal;
    private Vector2 myMouse;
    private Rigidbody myRigidbody;
    private bool isGrounded;
    private GameObject ActiveBluePortal;
    private GameObject ActiveOrangePortal;
  
    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        myRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        myMouse.x = Input.GetAxis("Mouse X");
        myMouse.y = Input.GetAxis("Mouse Y");

        transform.eulerAngles += new Vector3(0.0f, myMouse.x * Sensitivity * Time.deltaTime, 0.0f);
        Vector3 targetRotation = new Vector3(-myMouse.y * Sensitivity * Time.deltaTime, 0.0f, 0.0f);
        if (targetRotation.x + myCamera.transform.eulerAngles.x < 90 || targetRotation.x + myCamera.transform.eulerAngles.x > 270)
        {
            myCamera.transform.eulerAngles += targetRotation;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0.0f, 0.0f, Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0.0f, 0.0f, -Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-Speed * Time.deltaTime, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Speed * Time.deltaTime, 0.0f, 0.0f);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            myRigidbody.AddForce(0.0f, JumpStrength, 0.0f, ForceMode.Impulse);
            isGrounded = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            ShootBluePortal();
        }
        if (Input.GetMouseButtonDown(1))
        {
            ShootOrangePortal();
        }
    }
   

    void ShootBluePortal
        ()
    {
        Ray ray = myCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
        }
        
        if (ActiveBluePortal)
        {

        }
        ActiveBluePortal = instantiate(Blue) Blueportal; Quaternion.LookRotation(hit.normal, Vector3.up);

    }



    Destroy(oldBlueportal); 


    void Shootorangeportal()
  
    {
        Ray ray = myCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
        }

        if (ActiveOrangePortal)
        {

        }
        Activeorangeportal = instantiate(orange) orangePortal Quaternion.LookRotation(hit.normal, Vector3.up);

    }
}


void teleport(Gameobject portal)

{
	GameObject otherportal;

	if (portal.name == "BluePortal")
	{
		otherPortal = gameObject.Find("OrangePortal")
	}
	else
	{
		otherportal = gameObject.Find("BluePortal")
	}
	transform.Position = Portal.transform.position
}
float magnitude = myRigidbody.Velocity.magnitude;
myRigidbody.Velocity = otherportal.transform.teleport*magnitude;
transform.position = potal transform.position
    void OnCollisionEnter(Collision collision)
    {
	
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
	else if(Collision.gameObject.tag == "portal"){
		teleport Collision.gamemode;
	}
    }
}
