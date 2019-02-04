using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceManager : MonoBehaviour {

    public Dictionary<Dictionary<string, List<int>>, AudioSource> danceList = new Dictionary<Dictionary<string, List<int>>, AudioSource>();
    

    //dance move list
    public Dictionary<string, List<int>> popCultureDance = new Dictionary<string, List<int>>();
    public Dictionary<string, List<int>> backNForthDance = new Dictionary<string, List<int>>();
    public Dictionary<string, List<int>> machoManDance = new Dictionary<string, List<int>>();
    public Dictionary<string, List<int>> ymcaDance = new Dictionary<string, List<int>>();
    public Dictionary<string, List<int>> greasedLightningDance = new Dictionary<string, List<int>>();
    public Dictionary<string, List<int>> goodFeelingDance = new Dictionary<string, List<int>>();
    public Dictionary<string, List<int>> shapeOfYouDance = new Dictionary<string, List<int>>();
    public Dictionary<string, List<int>> badRomance1Dance = new Dictionary<string, List<int>>();
    public Dictionary<string, List<int>> badRomance2Dance = new Dictionary<string, List<int>>();
    public Dictionary<string, List<int>> sayALittlePrayerDance = new Dictionary<string, List<int>>();
    public Dictionary<string, List<int>> beatItDance = new Dictionary<string, List<int>>();

    //audio file list
    public AudioSource popCultureSong;
    public AudioSource backNForthSong;
    public AudioSource machoManSong;
    public AudioSource ymcaSong;
    public AudioSource greasedLightningSong;
    public AudioSource goodFeelingSong;
    public AudioSource shapeOfYouSong;
    public AudioSource badRomanceSong;
    public AudioSource sayALittlePrayerSong;
    public AudioSource beatItSong;

    // Use this for initialization
    void Start () {
        setPopCulture();
        setBackNForth();
        setMachoMan();
        setYMCA();
        setGreasedLightning();
        setGoodFeeling();
        setShapeOfYou();
        setBadRomance1();
        setBadRomance2();
        setSayALittlePrayer();
        setBeatIt();
    }
	
	// Update is called once per frame
	void Update () {
      
    }

        void setPopCulture()
    {
        List<int> pattern2 = new List<int>() { 2, 5, 8, 5, 2 };
        List<int> pattern3 = new List<int>() { 2, 5, 8, 5, 2 };
        popCultureDance["HandRight"] = pattern2;
        popCultureDance["HandLeft"] = pattern3;
        danceList[popCultureDance] = popCultureSong;

    }

    void setBackNForth()
    {
        List<int> pattern2 = new List<int>() { 11, 12, 11 };
        List<int> pattern3 = new List<int>() { 11, 10, 11 };
        List<int> pattern4 = new List<int>() { 5, 6, 5, 6 };
        List<int> pattern5 = new List<int>() { 5, 4, 5, 4 };
        backNForthDance["AnkleRight"] = pattern2;
        backNForthDance["AnkleLeft"] = pattern3;
        backNForthDance["HandRight"] = pattern4;
        backNForthDance["HandLeft"] = pattern5;
        danceList[backNForthDance] = backNForthSong;

    }

        void setMachoMan()
    {
        List<int> pattern1 = new List<int>() { 1, 2, 3 };
        List<int> pattern2 = new List<int>() { 5 };
        machoManDance["HandRight"] = pattern1;
        machoManDance["HandLeft"] = pattern2;
        danceList[machoManDance] = machoManSong;

    }

    void setYMCA()
    {
        List<int> pattern1 = new List<int>() { 3, 2, 1};
        List<int> pattern2 = new List<int>() { 1, 2, 1, 4 };
        ymcaDance["HandRight"] = pattern1;
        ymcaDance["HandLeft"] = pattern2;
        danceList[ymcaDance] = ymcaSong;

    }

    void setGreasedLightning()
    {
        List<int> pattern1 = new List<int>() { 5, 2, 5, 6, 5 };
        greasedLightningDance["HandRight"] = pattern1;
        danceList[greasedLightningDance] = greasedLightningSong;

    }

    void setGoodFeeling()
    {
        List<int> pattern1 = new List<int>() { 9, 6, 3, 2, 5 };
        List<int> pattern2 = new List<int>() { 7, 4, 1, 2, 5 };
        goodFeelingDance["HandRight"] = pattern1;
        goodFeelingDance["HandLeft"] = pattern2;
        danceList[goodFeelingDance] = goodFeelingSong;

    }

    void setShapeOfYou()
    {
        List<int> pattern1 = new List<int>() { 6, 5, 4, 5 };
        List<int> pattern2 = new List<int>() { 4, 5, 6, 5 };
        shapeOfYouDance["HandRight"] = pattern1;
        shapeOfYouDance["HandLeft"] = pattern2;
        danceList[shapeOfYouDance] = shapeOfYouSong;

    }

    void setBadRomance1()
    {
        List<int> pattern1 = new List<int>() { 5, 6, 3, 6, 9};
        List<int> pattern2 = new List<int>() { 5, 4, 1, 4, 7 };
        badRomance1Dance["HandRight"] = pattern1;
        badRomance2Dance["HandLeft"] = pattern2;
        danceList[badRomance1Dance] = badRomanceSong;

    }

    void setBadRomance2()
    {
        List<int> pattern1 = new List<int>() { 5, 3, 6, 9 };
        List<int> pattern2 = new List<int>() { 5, 1, 4, 7 };
        badRomance2Dance["HandRight"] = pattern1;
        badRomance2Dance["HandLeft"] = pattern2;
        danceList[badRomance2Dance] = badRomanceSong;

    }

    void setSayALittlePrayer()
    {
        List<int> pattern1 = new List<int>() { 5, 6, 9, 8, 5, 2 };
        List<int> pattern2 = new List<int>() { 5, 4, 7, 8, 5, 2 };
        sayALittlePrayerDance["HandRight"] = pattern1;
        sayALittlePrayerDance["HandLeft"] = pattern2;
        danceList[sayALittlePrayerDance] = sayALittlePrayerSong;

    }

    void setBeatIt()
    {
        List<int> pattern1 = new List<int>() { 5, 6, 5, 6, 5, 6, 5};
        beatItDance["HandRight"] = pattern1;
        danceList[beatItDance] = beatItSong;

    }

    public Dictionary<Dictionary<string, List<int>>, AudioSource> getDanceList()
    {
        return danceList;
    }

    public AudioSource getSong(Dictionary<string, List<int>> dance)
    {
        return danceList[dance];
    }

    public AudioSource GetASong(int num)
    {
        AudioSource theSong = null;
        if (num == 1)
        {
            theSong = danceList[popCultureDance];
        }
        if (num == 2)
        {
            theSong = danceList[backNForthDance];
        }
        if (num == 3)
        {
            theSong = danceList[machoManDance];
        }
        if (num == 4)
        {
            theSong = danceList[ymcaDance];
        }
        if (num == 5)
        {
            theSong = danceList[greasedLightningDance];
        }
        if (num == 6)
        {
            theSong = danceList[goodFeelingDance];
        }
        if (num == 7)
        {
            theSong = danceList[shapeOfYouDance];
        }
        if (num == 8)
        {
            theSong = danceList[badRomance1Dance];
        }
        if (num == 9)
        {
            theSong = danceList[sayALittlePrayerDance];
        }
        if (num == 0)
        {
            theSong = danceList[beatItDance];
        }
        return theSong;
    }
}
