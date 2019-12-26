using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed = 10f;
    public float turnSpeed = 50f;

    private float timer = 0.0f;
    public float bobbingSpeed = 0.18f;
    public float bobbingAmount = 0.2f;
    public float midpoint = 2.0f;

    private Rigidbody rb;

    void start()
    {
        rb = this.GetComponent<Rigidbody>();
             
    }


    // Update is called once per frame
    void Update()
    {

        float waveslice = 0.0f;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

      

        Vector3 cSharpConversion = transform.localPosition;

      
    //            if (Input.GetKey(KeyCode.DownArrow))
      //          transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);

            if (Input.GetKey(KeyCode.LeftArrow))
                transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);

            if (Input.GetKey(KeyCode.RightArrow))
                transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);

        if (Mathf.Abs(horizontal) == 0 && (vertical <=0))
        {
            timer = 0.0f;
        }
        else if(Mathf.Abs(vertical) !=0)
        {
            waveslice = Mathf.Sin(timer);
            timer = timer + bobbingSpeed;
            if (timer > Mathf.PI * 2)
            {
                timer = timer - (Mathf.PI * 2);
            }
        }

        if (waveslice != 0)
        {
            float translateChange = waveslice * bobbingAmount;
            float totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
            totalAxes = Mathf.Clamp(totalAxes, 0.0f, 1.0f);
            translateChange = totalAxes * translateChange;
            cSharpConversion.y = midpoint + translateChange;
        }
        else
        {
            cSharpConversion.y = midpoint;
        }

        transform.localPosition = cSharpConversion;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

    }


}

   /* private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Building")
        {
            Debug.Log("HI");
            rb.velocity = Vector3.zero;

        }
    } */


