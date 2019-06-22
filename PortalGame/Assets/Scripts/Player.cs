using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera myCamera;
    public float Speed;
    public float JumpStrength;
    public float Sensitivity;
    public float Teleportexitdisc;
    public float waitTime;

    public GameObject BluePortal;
    public GameObject OrangePortal;

    private Vector2 myMouse;
    private Rigidbody myRigidbody;
    private bool isGrounded;
    private bool canteleport = true;

    private GameObject ActiveBluePortal;
    private GameObject ActiveOrangePortal;

    // Use this for initialization
    void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;
        myRigidbody = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        myMouse.x = Input.GetAxis("Mouse X");
        myMouse.y = Input.GetAxis("Mouse Y");

        transform.eulerAngles += new Vector3(0.0f, myMouse.x * Sensitivity * Time.deltaTime, 0.0f);
        Vector3 targetRotation = new Vector3(-myMouse.y * Sensitivity * Time.deltaTime, 0.0f, 0.0f);
        if(targetRotation.x + myCamera.transform.eulerAngles.x < 90 || targetRotation.x + myCamera.transform.eulerAngles.x > 270)
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
        if(Input.GetMouseButtonDown(0))
        {
            ShootBluePortal();
        }
        if(Input.GetMouseButtonDown(1))
        {
            ShootOrangePortal();
        }

    }

    void ShootBluePortal()
    {
        Ray ray = myCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit))
        {
            if(ActiveBluePortal)
            {
                Destroy(ActiveBluePortal);
            }
            ActiveBluePortal = Instantiate(BluePortal, hit.point, Quaternion.LookRotation(hit.normal, Vector3.up));
        }
        
    }

    void ShootOrangePortal()
    {
        Ray ray = myCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (ActiveOrangePortal)
            {
                Destroy(ActiveOrangePortal);
            }
            ActiveOrangePortal = Instantiate(OrangePortal, hit.point, Quaternion.LookRotation(hit.normal, Vector3.up));
        }
    }

    void Teleport(GameObject portal)
    {
        if (canteleport)
        {
            GameObject otherPortal;
            if (portal.name == "Blue Portal(Clone)")
            {
                otherPortal = GameObject.Find("Orange Portal(Clone)");
            }
            else
            {
                otherPortal = GameObject.Find("Blue Portal(Clone)");
            }
            if (otherPortal)
            {
                transform.position = otherPortal.transform.position + otherPortal.transform.forward * Teleportexitdisc;



                float magnitude = myRigidbody.velocity.magnitude;
                myRigidbody.velocity = otherPortal.transform.forward * magnitude;
                canteleport = false;
                StartCoroutine(Teleportcooldown());
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        else if (collision.gameObject.tag == "Portal")
        {
            Teleport(collision.gameObject);
        }
        
    }
        IEnumerator Teleportcooldown()
        {
            yield return new WaitForSeconds(waitTime);
            canteleport = true;
        }
}
