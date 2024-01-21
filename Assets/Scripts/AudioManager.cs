using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    private void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.volume = s.volume;
            s.audioSource.pitch = s.pitch;
            s.audioSource.loop = s.loop;
            s.audioSource.clip = s.audioClip;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playAudio(string name)
    {
        for(int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].audioName.Equals(name))
            {
                sounds[i].audioSource.Play();
            }
        }
    }

    public void stopAudio()
    {
        for(int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].audioName.Equals(name))
            {
                sounds[i].audioSource.Stop();
            }
        }
    }
}
