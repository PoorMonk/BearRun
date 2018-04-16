using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoSingleton<Sound> {

    private AudioSource m_bg;
    private AudioSource m_effect;

    public string ResourcesDir = "";

    protected override void Awake()
    {
        base.Awake();
        m_bg = gameObject.AddComponent<AudioSource>();
        m_bg.playOnAwake = false;
        m_bg.loop = true;

        m_effect = gameObject.AddComponent<AudioSource>();
    }

    public void PlayBG(string audioName)
    {     
        string oldName;
        if (m_bg.clip == null)
            oldName = "";
        else
            oldName = m_bg.clip.name;

        if (oldName != audioName)
        {
            string path = ResourcesDir + "/" + audioName;
            AudioClip clip = Resources.Load<AudioClip>(path);
            if (clip != null)
            {
                m_bg.clip = clip;
                m_bg.Play();
            }
        }
    }

    public void PlayEffect(string audioName)
    {
        string path = ResourcesDir + "/" + audioName;
        AudioClip clip = Resources.Load<AudioClip>(path);
        if(clip != null)
        {
            m_effect.PlayOneShot(clip);
        }
    }
}
