using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_Control : MonoBehaviour
{
    public int numSound = 4;
    public AudioClip[] bgm_music;
    public GameControl control;

    private AudioSource soundSource;

    // Start is called before the first frame update
    private void Start()
    {
        soundSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (control.isStart)
        {
            StartCoroutine("Playlist");
        }
        else
        {
            //Debug.Log("소리 꺼져야 함");
            soundSource.Stop();
        }
    }

    private IEnumerator Playlist()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            if (!soundSource.isPlaying)
            {
                for (int i = 0; i < numSound; i++)
                {
                    soundSource.clip = bgm_music[i];
                    soundSource.Play();
                }

                soundSource.loop = true;
            }
        }
    }
}