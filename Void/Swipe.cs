using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    private List<int> scene_value;
    public int scene_dur;
    public int curr_scene = 0;
    public float timer = 0f;
    public int vdur = 10;
    public float velchange = 25f;
    public Vector3 F_val,vel;
    float Error = 0.1f;
    public bool Tap, SwipeLeft, SwipeRight, SwipeUp, SwipeDown;
    public float MaxDistance;
    public int coincount = 0;
    public float distcount = 0;
    private bool IsDragging;
    public Vector2 StartTouch, SwipeDelta;
    //public static GameObject other;
    private Rigidbody rb;
    //rb = GetComponent<Rigidbody>();
    //rb.AddForce(0,0,1);
    void Start()
    {
        //scene_value.Add(1);scene_value.Add(2);scene_value.Add(3);
        vel.x = 0; vel.y = 0; vel.z = 10;
        rb = this.GetComponent<Rigidbody>();
        SwipeLeft = false;
        SwipeRight = false;
        rb.velocity = new Vector3(0, 0, 10);
    }
    private void FixedUpdate()
    {
    }
    private void Update()
    {
        //vel = rb.velocity;
        timer += Time.deltaTime;
        distcount += Time.deltaTime * vel.z;
        Tap = false;
        SwipeUp = false;
        SwipeDown = false;
        //rb.AddForce(1, 1, 1);
        if (Input.GetMouseButtonDown(0))
        {
            IsDragging = true;
            Tap = true;
            StartTouch = (Vector2)Input.mousePosition;
        }

        else if (Input.GetMouseButtonUp(0))
        {
            IsDragging = false;
            Reset();
        }

        if (Input.touches.Length > 0)
        {

            if (Input.touches[0].phase == TouchPhase.Began)
            {
                IsDragging = true;
                Tap = true;
                StartTouch = Input.touches[0].position;
            }

            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                IsDragging = false;
                Reset();
            }


        }

        SwipeDelta = Vector2.zero;

        if (IsDragging)
        {

            if (Input.touches.Length > 0)
                SwipeDelta = Input.touches[0].position - StartTouch;
            else if (Input.GetMouseButton(0))
                SwipeDelta = (Vector2)Input.mousePosition - StartTouch;


        }

        if (SwipeDelta.magnitude >= MaxDistance)
        {
            float X = SwipeDelta.x;
            float Y = SwipeDelta.y;

            if (Mathf.Abs(X) > Mathf.Abs(Y))
            {
                if (X > 0)
                {
                    SwipeRight = true;
                    Vector3 temp = transform.position;
                    float offset = Mathf.Min(vel.z, 20) * Time.deltaTime;

                    if (!(Mathf.Abs(temp.x - 2.5f) < Error))
                    {

                        temp.x = temp.x + offset;
                    }

                    if ((Mathf.Abs(temp.x - 2.5f) < Error)|| (temp.x > 2.5f)) {
                        temp.x = 2.5f;
                        SwipeRight = false;
                        Reset();
                    }


                    float Xpos = temp.x;
                    transform.position = new Vector3(Xpos , 1f, distcount + vel.z * Time.deltaTime);

                    
                }


                else if (X < 0)
                {
                    SwipeLeft = true;
                    Vector3 temp = transform.position;

                    float offset = Mathf.Max(-vel.z, -20) * Time.deltaTime;

                    if (!(Mathf.Abs(temp.x + 2.5f) < Error))
                    {

                        temp.x = temp.x + offset;
                    }

                    if ((Mathf.Abs(temp.x + 2.5f) < Error) || (temp.x<-2.5f))
                    {
                        temp.x = -2.5f;
                        SwipeLeft = false;
                        Reset();
                    }


                    float Xpos = temp.x;
                    transform.position = new Vector3(Xpos, 1f, distcount + vel.z * Time.deltaTime);


                }

            }

            else if(Mathf.Abs(Y)>Mathf.Abs(X))
            {
                if (Y > 0)
                {
                    if (transform.position.y <= 1.2f)
                    {
                        SwipeUp = true;
                        rb.AddForce(F_val, ForceMode.Impulse);

                        Reset();
                        
                    }
                }
                else if (Y < 0)
                {
                    SwipeDown = true;



                }

            }



            X = 0;Y = 0;
        }
    /*    if (SwipeLeft)
        {
            Vector3 temp = transform.position;
            int f = 0;
            int f2 = 0;
            if (temp.x>0)
            {
                f = 1;
                transform.Translate(Mathf.Max(0f,-vel.z*Time.deltaTime), 0, 0);
                if (temp.x <= 0)
                {
                    SwipeLeft = false;
                    f = 0;
                }
            }
            else if ((temp.x <= 0) && (temp.x>-2.5f))
            {
                f2 = 1;
                transform.Translate(Mathf.Max(-2.5f,-vel.z*Time.deltaTime), 0, 0);
                if (temp.x <= -2.5f)
                {
                    f2 = 0;
                    SwipeLeft = false;
                }
            }
            Debug.Log("hello");

            if ((Mathf.Abs(temp.x-0f)< Error) || (Mathf.Abs(temp.x + 2.5f) < Error))
            {
                SwipeLeft = false;
            }

        }
        if (SwipeRight)
        {
            Vector3 temp = transform.position;
            if ((temp.x >= 0) && (temp.x<2.5f))
            {
                transform.Translate((Mathf.Min(vel.z*Time.deltaTime,2.5f)), 0, 0);
                if (temp.x >= 2.5f)
                {
                    SwipeRight = false;

                }
            }
            else if (temp.x < 0)
            {
                transform.Translate((Mathf.Min(vel.z * Time.deltaTime,0f)), 0, 0);
                if (temp.x >= 0f)
                {
                    SwipeRight = false;
                }
            }

            if ((Mathf.Abs(temp.x - 0f) < Error) || (Mathf.Abs(temp.x - 2.5f) < Error))
            {
                SwipeRight = false;
            }


        }  */
        if (timer > vdur)
        {
            timer -= vdur;
            //Vector3 a = rb.velocity;
            vel.z += velchange;
            rb.velocity = vel;
            //Debug.Log("hii");
        }
        else
        {
            rb.velocity = vel;
        }
        /*if (timer > scene_dur)
        {
            int sum = 0;
            for (int i = 0; i < 3; i++)
            {
                sum += scene_value[i];
            }
            curr_scene= 6 - sum;
            int index = Random.Range(0, 3);
            scene_value.Add(curr_scene);
            curr_scene = scene_value[index];
            scene_value.RemoveAt(index);
        }*/
        Debug.Log(rb.velocity);
    }

    private void Reset()
    {
        IsDragging = false;
        StartTouch = Vector2.zero;
        SwipeDelta = Vector2.zero;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("coin") == true)
        {
            coincount++;
            collision.collider.gameObject.SetActive(false);
        }
    }

}
