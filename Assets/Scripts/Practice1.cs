using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Practice1 : MonoBehaviour
{
    public float speed;

    //private float a = 5.0f;
    //private double b = 15.5;
    //private bool c = false;
    //private bool d = true;
    private bool isRunning = true;

    private int num;
    private bool stop = false;

    // Start is called before the first frame update
    private void Start()
    {
        num = 0;
        Debug.Log("Begin to go Right, Loop " + num.ToString());

        //Debug.Log("안녕하세요" + b.ToString());
        //Debug.Log("저는 강남규 입니다." + a.ToString());

        //bool and = c && d;
        //bool or = c || d;
        //bool not = !c;

        //Debug.Log("and: " + and);
        //Debug.Log("or: " + or);
        //Debug.Log("not: " + not);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            stop = true;
        }
        if (stop == false)
        {
            if (isRunning)
            {
                transform.Translate(-speed * 0.1f, 0.0f, 0.0f);
                if (transform.position.x < -10.0f)
                {
                    num++;
                    Debug.Log("Go Left, Loop " + num.ToString());
                    isRunning = false;
                }
            }
            else
            {
                transform.Translate(speed * 0.1f, 0.0f, 0.0f);
                if (transform.position.x > 10.0f)
                {
                    num++;
                    Debug.Log("Go Right, Loop " + num.ToString());
                    isRunning = true;
                }
            }
        }
        else if (stop == true)
        {
            speed = 0;
            transform.position = new Vector3(0.0f, 0.0f, 0.0f);
            Debug.Log("Game Over " + num.ToString() + "Loop");
            //transform.Rotate(0.0f, 90.0f, 0.0f);
            //stop = false;
            //Debug.Log("Rotate at " + num.ToString() + "Loop");
        }
    }
}