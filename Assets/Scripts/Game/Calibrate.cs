using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Calibrate : MonoBehaviour {

    private int height;
    private Vector3 Head;
    private Vector3 SpineBase;
    public GameObject zoneDaddy;
    private Vector3 og;
    private Vector3 ogPos;

    private void Start()
    {
        og = zoneDaddy.transform.localScale;
        ogPos = zoneDaddy.transform.localPosition;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            transformZone();
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            resetZone();
        }
        if (Input.GetKey(KeyCode.W))
        { 
            moveUp();
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDown();
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveRight();
        }
        if (Input.GetKeyUp(KeyCode.Equals))
        {
            scaleUp();
        }
        if (Input.GetKeyUp(KeyCode.Minus))
        {
            scaleDown();
        }
    }
    //Pterneas, Vangos. “Kinect for Windows: Find User Height Accurately.” CodeProject - For Those Who Code, 23 Jan. 2014, www.codeproject.com/Tips/380152/Kinect-for-Windows-Find-User-Height-Accurately.
    //gets the length between two joints
    private static double Length(Vector3 Head, Vector3 SpineBase)
    {

        print((Head.y - SpineBase.y) * 2);
            return ((Head.y - SpineBase.y) * 2);
  
    }

    private void updateHeight()
    {
        if (!(Head == null || SpineBase == null))
        {
            height = Convert.ToInt32(Length(Head, SpineBase));
        }
    }

    public void setHead(Vector3 vec)
    {
       // print(vec.ToString());
        Head = vec;
    }

    public void setSpineBase(Vector3 vec)
    {
        SpineBase = vec;
    }

    public void transformZone()
    {
        updateHeight();
        print(height);
        print(Head.ToString());
        print(SpineBase.ToString());
        zoneDaddy.transform.localScale = og * height / 17;
        zoneDaddy.transform.localPosition = new Vector3(ogPos.x, 10 * height / 17 - 10, ogPos.z);


    }

    public void resetZone()
    {
       
        zoneDaddy.transform.localScale = og;
        zoneDaddy.transform.localPosition = ogPos;


    }

    public void moveUp()
    {
            zoneDaddy.transform.Translate(0f, 0.1f, 0f);
    }
    public void moveDown()
    {
            zoneDaddy.transform.Translate(0f, -0.1f, 0f);
    }
    public void moveLeft()
    {
        zoneDaddy.transform.Translate(-0.1f, 0f, 0f);
    }
    public void moveRight()
    {
            zoneDaddy.transform.Translate(0.1f, 0f, 0f);
    }
    public void scaleUp()
    {
        zoneDaddy.transform.localScale = zoneDaddy.transform.localScale * 1.1f;
    }
    public void scaleDown()
    {
        zoneDaddy.transform.localScale = zoneDaddy.transform.localScale * 0.9f;
    }
}
