using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float torque = 5f;
    [SerializeField] float minX = 1.803f;
    [SerializeField] float maxX = 19.48f;
    //[SerializeField] float leftButton = 1f;
    //[SerializeField] float rightButton = 1f;
    //[SerializeField] float paddleYPos = 0.25f;
    //[SerializeField] float paddleZPos = 0.0f;
    [SerializeField] float speed = 10.0f;
    // Start is called before the first frame update

    [SerializeField] float force = 1.0f;
    Rigidbody2D myRigidbody2D;
    
    void Start()
    {
        //myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    //void Update()
    //{

    //Camera cam = Camera.main;
    //screenWidthInUnits = cam.orthographicSize * 2f;
    //float mousePosInUnits = Mathf.Clamp(Input.mousePosition.x, cam.aspect, screenWidthInUnits); // (minX + maxX) - screenWidthInUnits;
    //float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;

    ////var mousePosInUnits = Input.acceleration;

    //This plays with finger on screen

    //Vector2 paddlePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    ////Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
    //paddlePos.x = Mathf.Clamp(paddlePos.x, minX, maxX);
    //paddlePos.y = paddleYPos;
    //transform.position =  paddlePos;

    //}

    /*
    Vector3 dir = new Vector3(Input.acceleration.x,0, 0);
    dir.x = Mathf.Clamp(dir.x, minX, maxX);
    dir.y = paddleYPos;
    dir.z = paddleZPos;
    //Debug.Log("dir x: " + dir.x);
    //Debug.Log("dir y: " + dir.y);
    //Debug.Log("dir z: " + dir.z);
    //if (dir.sqrMagnitude > 1)
    //{
    //    dir.Normalize();
    //}
    //dir *= Time.deltaTime;
    //transform.position = dir;
    //Debug.Log(dir);
    transform.Translate(dir * speed);
    */
    void Update()
    {

        if (FindObjectOfType<GameStatus>().IsAutoPlayEnabled())
        {
            Vector2 paddlePos = new Vector2();
            paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
            paddlePos.y = 0.25f;
            transform.position = paddlePos;
        }
        else
        {
            // normalize axis

            //Debug.Log( "position is: " + Input.acceleration.x * Time.deltaTime);
            //myRigidbody2D.AddForce(Input.acceleration,ForceMode2D.Impulse);
            //myRigidbody2D.AddTorque(torque);

            Vector3 paddlePos = Vector3.zero;
            paddlePos.x = Input.acceleration.x;
            //Debug.Log("Accelaration: " + paddlePos);
            //paddlePos.x = paddlePos.x * Time.deltaTime * speed;
            transform.Translate(paddlePos.x * Time.fixedDeltaTime * speed, paddlePos.y,0.0f,Space.Self);
        }
    }
        
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Wall")
        {
            myRigidbody2D.velocity = new Vector2(0f, 0f);
            //myRigidbody2D.isKinematic = true;
        }
    }
    
    private float GetXPos()
    {
        if(FindObjectOfType<GameStatus>().IsAutoPlayEnabled())
        {

            return FindObjectOfType<Ball>().transform.position.x;
        }
        else
        {
            return 0;
        }
    }

}

