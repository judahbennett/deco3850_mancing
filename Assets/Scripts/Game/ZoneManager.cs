using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneManager : MonoBehaviour
{
    
    
    private AudioSource[] allAudioSources;
    public DanceManager danceManager;
    public Dictionary<string, List<int>> jointLocation = new Dictionary<string, List<int>>();



    public  void StopAllAudio()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Stop();
        }
    }

    
    public void updateJoint(int zone, string joint)
    {

        if (!jointLocation.ContainsKey(joint))
        {
            List<int> LocationInfo = new List<int>();
            LocationInfo.Add(zone);
            jointLocation[joint] = LocationInfo;
        }
        else
        {

            if (!(jointLocation[joint][jointLocation[joint].Count - 1] == zone))
            {
                jointLocation[joint].Add(zone);
            }
        }

        //check to see if dictionary is updating
        /*foreach (KeyValuePair<string, List<int>> kvp in jointLocation)
        {
            string aString = kvp.Key;
            foreach (int i in kvp.Value)
            {
                aString += i.ToString();
            }

            print(aString);
        }*/
    }


    //reset once a dance move is recoginised
    public void resetDictionary()
    {
        foreach (KeyValuePair<string, List<int>> kvp in jointLocation)
        {

            jointLocation[kvp.Key].Clear();
            jointLocation[kvp.Key].Add(0);
            jointLocation[kvp.Key].Add(0);
        }

    }

    //count number of moves
    public int getmoveNumber(List<int> moves)
    {
        return moves.Count;
    }

    //get move list
    public List<int> getMoves(string joint)
    {
        return jointLocation[joint];
    }

    //reset joint
    public void resetJoint(string joint)
    {
            jointLocation[joint].Clear();
            jointLocation[joint].Add(0);
            jointLocation[joint].Add(0);
    }




    //function compares lists
    public bool isIt(List<int> list, List<int> pattern)
    {
        bool itis = false;

        //iterate through the list of zone values the joint has been with
        for (int i = 0; i < list.Count - 1; i++)
        {
            //check if i matches the first number of the pattern
            if (list[i] == pattern[0])
            {
                if (pattern.Count == 1)
                {
                    return itis = true;
                }
                //make sure theres enough points in the list
                if (list.Count - i > pattern.Count)
                {
                    //iterate through pattern getting each value
                    for (int x = 1; x < pattern.Count; x++)
                    {
                        //check that the next zone in the pattern matches that list item
                        if (list[i + x] == pattern[x])
                        {
                            itis = true;
                        }

                        else
                        {
                            itis = false;
                            break;
                        }
                    }
                }
                
            }
        }
        //print(itis);
        return itis;
    }

    private void intialiseJoints()
    {

        List<string> joints = new List<string>() {
            "HandLeft",
            "HandRight",
        };

        List<int> LocationInfo = new List<int>() { 0 };
        
        for (int i = 0; i < joints.Count; i++)
        {
            jointLocation[joints[i]] = LocationInfo;
        }
            
    }

    public AudioSource checkDanceSong()
    {
        Dictionary<string, List<int>> danceMove = new Dictionary<string, List<int>>();
        danceMove = isitaDance();
        AudioSource song = new AudioSource();
        if (danceManager.getDanceList().ContainsKey(danceMove))
        {
            song = danceManager.getSong(danceMove);
            
        }
        return song;
    }

    public Dictionary<string, List<int>> isitaDance()
    {
        //which dance it is goes here
        Dictionary<string, List<int>> whichDance = new Dictionary<string, List<int>>();

        //we get the full dance list
        Dictionary<Dictionary<string, List<int>>, AudioSource> danceList = danceManager.getDanceList();

        //we look at all the dance moves in the dance list
        foreach (KeyValuePair<Dictionary<string, List<int>>, AudioSource> dance in danceList)
        {
            bool thisDance = false;

            //in each dance move we look at where each joint should be in what zone
            foreach (KeyValuePair<string, List<int>> joints in dance.Key)
            {
                //this is the joint being compared
                string currentJoint = joints.Key;
                if (jointLocation.ContainsKey(currentJoint))
                {
                    //the joints movement through zones
                    List<int> jointPattern = jointLocation[currentJoint];
                    //the expected movement of joint
                    List<int> pattern = joints.Value;
                    //check the pattern matches
                    thisDance = isIt(jointPattern, pattern);
                    //if it ever does not match it will clear whichdance as it is not the dance
                    if (!thisDance)
                    {
                        break;
                    }
                }
            
            }

            //if it goes through the for leoop withot breaking and this dance is true set whichdance to the dance
            if (thisDance)
            {
                // it links to that dances dictionary so if you clear it it clears dance which causes an error
                whichDance = dance.Key;
            }
            
        }

        return whichDance;

    }

}