using UnityEngine;
using System.Collections;
using Windows.Kinect;

public class BodySourceManager : MonoBehaviour 
{
    private KinectSensor _Sensor;
    private BodyFrameReader _Reader;
    private Body[] _Data = null;
    private int activeBodyIndex = -1; // Default to impossible value

    public Body[] GetData()
    {
        return _Data;
    }
    

    void Start () 
    {
        _Sensor = KinectSensor.GetDefault();

        if (_Sensor != null)
        {
            _Reader = _Sensor.BodyFrameSource.OpenReader();
            
            if (!_Sensor.IsOpen)
            {
                _Sensor.Open();
            }
        }   
    }
    
    void Update () 
    {
        if (_Reader != null)
        {
            var frame = _Reader.AcquireLatestFrame();
            if (frame != null)
            {
                if (_Data == null)
                {
                    _Data = new Body[_Sensor.BodyFrameSource.BodyCount];
                }
                
                frame.GetAndRefreshBodyData(_Data);
                
                frame.Dispose();
                frame = null;
            }
        }    
    }
    
    void OnApplicationQuit()
    {
        if (_Reader != null)
        {
            _Reader.Dispose();
            _Reader = null;
        }
        
        if (_Sensor != null)
        {
            if (_Sensor.IsOpen)
            {
                _Sensor.Close();
            }
            
            _Sensor = null;
        }
    }
    private void Reader_MultiSourceFrameArrived(
      MultiSourceFrameReader sender,
      MultiSourceFrameArrivedEventArgs e)
    {
        Body body;
        BodyFrame bodyFrame;
        MultiSourceFrame multiSourceFrame = e.FrameReference.AcquireFrame();

        // If the Frame has expired by the time we process this event, return.
        if (multiSourceFrame == null)
        {
            return;
        }

        using (bodyFrame =
            multiSourceFrame.BodyFrameReference.AcquireFrame())
        {
        int activeBodyIndex = -1; // Default to impossible value.
        Body[] bodiesArray = new Body[
        this._Sensor.BodyFrameSource.BodyCount];

        if (bodyFrame != null)
        {
            bodyFrame.GetAndRefreshBodyData(_Data);

            // Iterate through all bodies, 
            // no point persisting activeBodyIndex because must 
            // compare with depth of all bodies so no gain in efficiency.

                    float minZPoint = float.MaxValue; // Default to impossible value
                    for (int i = 0; i < bodiesArray.Length; i++)
                    {
                        body = bodiesArray[i];
                        if (body.IsTracked)
                        {
                            float zMeters =
                               body.Joints[JointType.SpineBase].Position.Z;
                            if (zMeters < minZPoint)
                            {
                                minZPoint = zMeters;
                                activeBodyIndex = i;
                            }
                        }
                    }


                    // If active body is still active after checking and 
                    // updating, use it
                    if (activeBodyIndex != -1)
                    {
                         body = bodiesArray[activeBodyIndex];
                        // Do stuff with known active body.
                    }
                }
            }
        
    }

}
