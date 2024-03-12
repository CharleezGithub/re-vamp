using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioLibraryObject audioLibrary;


    private void OnEnable()
    {
        if (Instance is null)
        {
            Instance = this;
            // TODO: manager itself should not handle this
            // DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(Instance);
            Instance = this;
        }
    }

    private void OnDisable()
    {
        Instance = null;
    }

    public static AudioClip FindAudioClip(string nameOfClip)
    {
        return Instance.audioLibrary.Clips.First(x => x.name == nameOfClip);
    }

    public static AudioSource PlaySound(AudioClip clip, Vector3 sourcePos, bool manuallyHandle = false, bool is3D = true, bool loop = false, bool fadeIn = false)
    {
        return PlaySoundInternal(clip, sourcePos, manuallyHandle, is3D, loop, fadeIn);
    }

    public static AudioSource PlaySound(string nameOfClip, Vector3 sourcePos, bool manuallyHandle = false, bool is3D = true, bool loop = false, bool fadeIn = false)
    {
        AudioClip clip = FindAudioClip(nameOfClip);
        return PlaySoundInternal(clip, sourcePos, manuallyHandle, is3D, loop, fadeIn);
    }

    private static AudioSource PlaySoundInternal(AudioClip clip, Vector3 sourcePos, bool manuallyHandle, bool is3D, bool loop, bool fadeIn)
    {
        if (Instance == null)
        {
            Debug.LogWarning("AudioManager has not been initialized. Please initialize it before use.");
            return null;
        }

        var sourceObject = new GameObject("SoundSource");
        var audioSource = sourceObject.AddComponent<AudioSource>();
        audioSource.loop = loop;
        audioSource.clip = clip;
        sourceObject.transform.position = sourcePos;
        sourceObject.transform.parent = Instance.transform;

        if (is3D)
        {
            audioSource.rolloffMode = AudioRolloffMode.Linear;
            audioSource.spatialBlend = 1f;
        }

        if (!manuallyHandle)
            Instance.StartCoroutine(Instance.StartSound(audioSource, fadeIn));
        return audioSource;
    }

    public static List<SoundSource> AliveSources = new List<SoundSource>();
    IEnumerator StartSound(AudioSource audioSource, bool fadeIn = false)
    {
        AliveSources.Add(new SoundSource(audioSource));

        if (fadeIn)
        {
            audioSource.volume = 0;
            StartCoroutine(StartMusicFadeIn(audioSource));
        }


        audioSource.Play();
        yield return new WaitUntil(() => audioSource.gameObject == null || !audioSource.isPlaying);

        try
        {
            Destroy(audioSource.gameObject);
        }
        catch (SystemException err)
        {

        }
    }

    public IEnumerator StartMusicFadeIn(AudioSource AS)
    {
        while (true)
        {
            if (AS.volume >= 1)
            {
                break;
            }
            AS.volume += 0.01f;
            yield return new WaitForSecondsRealtime(0.05f);
        }
    }

    public void StopAllAudio()
    {
        StopAllCoroutines();
        foreach (SoundSource item in AliveSources)
        {
            if (item == null || item.source == null) continue;

            item.source.Stop();
            Destroy(item.source.gameObject);
        }

        AliveSources.Clear();
    }
}

public class SoundSource
{
    public string Id { get; set; }
    public AudioSource source { get; set; }
    public SoundSource(AudioSource originalSource)
    {
        source = originalSource;
    }
}
