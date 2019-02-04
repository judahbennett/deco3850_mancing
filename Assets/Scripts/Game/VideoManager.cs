using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour {

    
    public GameObject dance0;
    public GameObject dance1;
    public GameObject dance2;
    public GameObject dance3;
    public GameObject dance4;
    public GameObject dance5;
    public GameObject dance6;
    public GameObject dance7;
    public GameObject dance8;
    public GameObject dance9;
    private int num = 0;
    public Dictionary<int, GameObject> videoList = new Dictionary<int, GameObject>();

    // Use this for initialization
    void Start () {
        setVideoList();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            playVideo();
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            int which = checkVid();
            if (which < 10)
            {
                stopVid(which);
            }
        }
    }

    private void playVideo()
    {
        int which = checkVid();
        
        if (which < 10)
        {
            stopVid(which);
        }
        videoList[num].GetComponent<VideoPlayer>().Play();
        if (num == 9)
        {
            num = 0;
        }
        else
        {
            num++;
        }
        
    }

    private int checkVid()
    {
        int which = 10;
        foreach (KeyValuePair<int, GameObject> vid in videoList)
        {
            if (vid.Value.GetComponent<VideoPlayer>().isPlaying)
            {
                which = vid.Key;
            }
        }
        return which;
    }

    private void stopVid(int aNum)
    {
        if (videoList[aNum].GetComponent<VideoPlayer>().isPlaying)
        {
            videoList[aNum].GetComponent<VideoPlayer>().Stop();
        }
    }

    private void setVideoList()
    {
     
        videoList[0] = dance0;
        videoList[1] = dance1;
        videoList[2] = dance2;
        videoList[3] = dance3;
        videoList[4] = dance4;
        videoList[5] = dance5;
        videoList[6] = dance6;
        videoList[7] = dance7;
        videoList[8] = dance8;
        videoList[9] = dance9;
    }
}
