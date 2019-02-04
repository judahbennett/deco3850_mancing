using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Hand : MonoBehaviour {

    public Transform mHandMesh;
    private string thisjoint;
    private Camera _camera;
    private Calibrate _calibrate;

    private void Start()
    {
        _camera = Camera.main;
        _calibrate = _camera.GetComponent<Calibrate>();
        thisjoint = this.ToString();
        thisjoint = thisjoint.Remove(thisjoint.IndexOf(' '), thisjoint.Length - thisjoint.IndexOf(' '));
   

    }

    private void Update()
    {
        //Linear interperlating the position of the hand mesh to follow the joint
        //Smoothes out the image
        mHandMesh.position = Vector3.Lerp(mHandMesh.position, transform.position, Time.deltaTime * 15.0f);
        updateCalibrater();
        if (Input.GetKeyUp(KeyCode.X))
        {
            if (this.GetComponent<MeshRenderer>().enabled)
            {
                this.GetComponent<MeshRenderer>().enabled = false;
            }
            else
            {
                this.GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }

    public void updateCalibrater()
    {
        if (thisjoint == "Head")
        {
            
            // print(Vector3.Lerp(mHandMesh.position, transform.position, Time.deltaTime * 15.0f));
            // _calibrate.setHead(Vector3.Lerp(mHandMesh.position, transform.position, Time.deltaTime * 15.0f));
            _calibrate.setHead(this.transform.position);
        }
        if (thisjoint == "SpineBase")
        {
            _calibrate.setSpineBase(this.transform.position);
            //_calibrate.setSpineBase(Vector3.Lerp(mHandMesh.position, transform.position, Time.deltaTime * 15.0f));
        }
    }






}
