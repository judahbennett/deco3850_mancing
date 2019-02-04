using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audioManager : MonoBehaviour
{


    public ZoneManager zoneManager;
    public List<AudioSource> backgroundSongs;
    private AudioSource[] allAudioSources;
    public AudioSource backgroundsong1;
    public AudioSource backgroundsong2;
    public AudioSource backgroundsong3;
    public AudioSource backgroundsong4;
    private AudioSource currentSong;
    private Dictionary<AudioSource, bool> pausedSong = new Dictionary<AudioSource, bool>();
    public Text songDetails;

   

    void Start()
    {
        setbackgroundSongs();
        pausedSong[backgroundsong1] = false;
        pausedSong[backgroundsong2] = false;
        pausedSong[backgroundsong3] = false;
        pausedSong[backgroundsong4] = false;

    }

    void Update()
    {
        keypressing();
        AudioSource song = new AudioSource();
        song = zoneManager.checkDanceSong();

        //print(song.ToString());
        if (song)
        {
            print(song.ToString());
            //checks that this current song isnt playing
            if (!song.isPlaying)
            {
                //pausebackground
                pauseBackground();
                //stops all audio so that songs dont play over each other
                zoneManager.StopAllAudio();
                song.Play();
                //reset users movement
                zoneManager.resetDictionary();

            }
        }
        //theres no dance so no sound clip
        else
        {
            //there is no song playing
            if (!checksongON())
            {
                if (currentSong)
                {
                    //if the song has been paused
                    if (pausedSong[currentSong])
                    {
                        pausedSong[currentSong] = false;
                        currentSong.Play();
                    }
                    //if the song isnt playing but has played out
                    else
                    {
                        currentSong = backgroundSongs[Random.Range(0, backgroundSongs.Count)];
                        currentSong.Play();
                    }
                }
                //if there has not been a background song
                else
                {
                    currentSong = backgroundSongs[Random.Range(0, backgroundSongs.Count)];
                    currentSong.Play();
                }
            }

        }
        songDetails.text = songdetails();
    }

    void setbackgroundSongs()
    {
        backgroundSongs.Add(backgroundsong1);
        backgroundSongs.Add(backgroundsong2);
        backgroundSongs.Add(backgroundsong3);
        backgroundSongs.Add(backgroundsong4);
    }

    void pauseBackground()
    {
        if (currentSong)
        {
            if (currentSong.isPlaying)
            {
                pausedSong[currentSong] = true;
                currentSong.Pause();
            }
        }

    }

    public void StopAllAudio()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource aSong in allAudioSources)
        {
            if (aSong.isPlaying)
            {
                aSong.Stop();
            }

        }
    }

    private bool checksongON()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource aSong in allAudioSources)
        {
            if (aSong.isPlaying)
            {
                return true;
            }

        }

        return false;
    }

    private string songdetails()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        string songName = "";
        foreach (AudioSource aSong in allAudioSources)
        {
            if (aSong.isPlaying)
            {
                songName = aSong.ToString();
                songName = songName.Remove(songName.IndexOf(' '), songName.Length - songName.IndexOf(' '));
                songName = songName.Replace("_", " ");
            }

        }

        return songName;
    }
    public void keypressing()
    {
        if (Input.GetKeyUp(KeyCode.Keypad1))
        {
            //pausebackground
            pauseBackground();
            //stops all audio so that songs dont play over each other
            zoneManager.StopAllAudio();
            zoneManager.danceManager.GetASong(1).Play();
        }
        if (Input.GetKeyUp(KeyCode.Keypad2))
        {
            //pausebackground
            pauseBackground();
            //stops all audio so that songs dont play over each other
            zoneManager.StopAllAudio();
            zoneManager.danceManager.GetASong(2).Play();
        }
        if (Input.GetKeyUp(KeyCode.Keypad3))
        {
            //pausebackground
            pauseBackground();
            //stops all audio so that songs dont play over each other
            zoneManager.StopAllAudio();
            zoneManager.danceManager.GetASong(3).Play();
        }
        if (Input.GetKeyUp(KeyCode.Keypad4))
        {
            //pausebackground
            pauseBackground();
            //stops all audio so that songs dont play over each other
            zoneManager.StopAllAudio();
            zoneManager.danceManager.GetASong(4).Play();
        }
        if (Input.GetKeyUp(KeyCode.Keypad5))
        {
            //pausebackground
            pauseBackground();
            //stops all audio so that songs dont play over each other
            zoneManager.StopAllAudio();
            zoneManager.danceManager.GetASong(5).Play();
        }
        if (Input.GetKeyUp(KeyCode.Keypad6))
        {
            //pausebackground
            pauseBackground();
            //stops all audio so that songs dont play over each other
            zoneManager.StopAllAudio();
            zoneManager.danceManager.GetASong(6).Play();
        }
        if (Input.GetKeyUp(KeyCode.Keypad7))
        {
            //pausebackground
            pauseBackground();
            //stops all audio so that songs dont play over each other
            zoneManager.StopAllAudio();
            zoneManager.danceManager.GetASong(7).Play();
        }
        if (Input.GetKeyUp(KeyCode.Keypad8))
        {
            //pausebackground
            pauseBackground();
            //stops all audio so that songs dont play over each other
            zoneManager.StopAllAudio();
            zoneManager.danceManager.GetASong(8).Play();
        }
        if (Input.GetKeyUp(KeyCode.Keypad9))
        {
            //pausebackground
            pauseBackground();
            //stops all audio so that songs dont play over each other
            zoneManager.StopAllAudio();
            zoneManager.danceManager.GetASong(9).Play();
        }
        if (Input.GetKeyUp(KeyCode.Keypad0))
        {
            //pausebackground
            pauseBackground();
            //stops all audio so that songs dont play over each other
            zoneManager.StopAllAudio();
            zoneManager.danceManager.GetASong(0).Play();
        }
    }
}