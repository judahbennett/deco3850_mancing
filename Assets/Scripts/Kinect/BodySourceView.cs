using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

using Windows.Kinect;
using Joint = Windows.Kinect.Joint;


public class BodySourceView : MonoBehaviour
{
    public BodySourceManager mBodySourceManager;
    public GameObject mJointObject;


    private Dictionary<ulong, GameObject> mBodies = new Dictionary<ulong, GameObject>();
    private List<JointType> _joints = new List<JointType>
    {
        JointType.HandLeft,
        JointType.HandRight,
        JointType.AnkleLeft,
        JointType.AnkleRight,
        JointType.ElbowLeft,
        JointType.ElbowRight,
        //JointType.FootLeft,
        //JointType.FootRight,
        JointType.Head,
        JointType.HipLeft,
        JointType.HipRight,
        JointType.KneeLeft,
        JointType.KneeRight,
        JointType.SpineBase,
       // JointType.ShoulderLeft,
       // JointType.ShoulderRight,
        
    };



    void Update()
    {
        #region Get Kinect data
        Body[] data = mBodySourceManager.GetData();
        //checks to see if we have any data
        if (data == null)
        {
            return;
        }

        List<ulong> trackedIds = new List<ulong>();
        //This list contains all the ids for bodies the kinect is tracking
        foreach (var body in data)
        {
            if (body == null)
            {
                //checks to see if we have a body
                continue;
            }

            if (body.IsTracked)
            {   
                //if the body is actively being tracked we add it to the list
                trackedIds.Add(body.TrackingId);
            }
        }
        #endregion

        #region Delete Kinect Bodies
        List<ulong> knownIds = new List<ulong>(mBodies.Keys);
        foreach (ulong trackingId in knownIds)
        {
            if (!trackedIds.Contains(trackingId))
            {
                //Destroy body object
                Destroy(mBodies[trackingId]);

                //Remove from list
                mBodies.Remove(trackingId);
            }
        }
        #endregion

        #region Create Kinect bodies
        
        foreach (var body in data)
        {
            //If no body, skip
            if (body == null)
            {
                continue;
            }

            if (body.IsTracked)
            {
                //If body isn't tracked, create body
                if (!mBodies.ContainsKey(body.TrackingId))
                {
                    //need to test if this works
                    //only creates a new body if mBodies is empty
                    if (mBodies.Count == 0)
                    {
                        mBodies[body.TrackingId] = CreateBodyObject(body.TrackingId);
                    }

                }
                if (mBodies.ContainsKey(body.TrackingId))
                {
                    //Update positions
                    UpdateBodyObject(body, mBodies[body.TrackingId]);
                }
                //after it updates it breaks so it doesnt getting any new tracking
                break;
            }
        }
        #endregion

    }

   
    

    private GameObject CreateBodyObject(ulong id)
    {
        //Create body parent
        GameObject body = new GameObject("Body:" + id);

        //Create joints
        foreach (JointType joint in _joints)
        {
            //Create Object 
            GameObject newJoint = Instantiate(mJointObject);
            newJoint.name = joint.ToString();

            //Parent to body
            newJoint.transform.parent = body.transform;
        }

        return body;
    }

    private void UpdateBodyObject(Body body, GameObject bodyObject)
    {
        //Update joints
        foreach (JointType _joint in _joints)
            // get each joint in joints
        {
            
            //Get new target position
            Joint sourceJoint = body.Joints[_joint];
            //getting the body we passed in and getting the joints
            //get the vector 3 the position of it
            Vector3 targetPosition = GetVector3FromJoint(sourceJoint);
            targetPosition.z = 0;

            //Get joint, set new position
            Transform jointObject = bodyObject.transform.Find(_joint.ToString());
            jointObject.position = targetPosition;
        }
    }


    private static Vector3 GetVector3FromJoint(Joint joint)
    {
        return new Vector3(joint.Position.X * 10, joint.Position.Y * 10, joint.Position.Z * 10);
    }
}
