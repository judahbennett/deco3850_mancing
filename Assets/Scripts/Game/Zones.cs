using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zones : MonoBehaviour {

    public ZoneManager zoneManager;
    public int zoneNumber;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //turn the name into a suitable string
        string jointName = collision.ToString();
        jointName = jointName.Remove(jointName.IndexOf(' '), jointName.Length - jointName.IndexOf(' '));
        //print(jointName);
        zoneManager.updateJoint(zoneNumber, jointName);
        // every time it collides it will check for a song and replay it need to check for if its the same song and have a reset so other moves can be done
        /*AudioSource song = new AudioSource();
        song = zoneManager.checkDanceSong();
        
        //print(song.ToString());
        if (song)
        {
            
            //checks that this current song isnt playing
            if (!song.isPlaying)
            {
                //stops all audio so that songs dont play over each other
                zoneManager.StopAllAudio();
                song.Play();
                //reset users movement
                zoneManager.resetDictionary();

            }
        }*/


        //get the number of movements in that joints list and if its more than ten
        if (zoneManager.getmoveNumber(zoneManager.getMoves(jointName)) > 20 )
        {
            //reset that joint list if its more than 10
            zoneManager.resetJoint(jointName);
        }

    }

    
}
