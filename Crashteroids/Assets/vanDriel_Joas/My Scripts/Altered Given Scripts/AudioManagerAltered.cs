using UnityEngine;

public class AudioManagerAltered : MonoBehaviour
{
    // reference to prefab for new audio sources
    [SerializeField] private AudioSource sourcePrefab;

    // singleton for easy access 
    private static AudioManagerAltered instance;
    public static AudioManagerAltered Instance { get { return instance; } }

    private void Awake()
    {
        // setup singleton so that the new one will be destroyed
        // meaning sounds will keep playing on the old one
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayClip(AudioClip clip, float volume)
    {
        // create a new audio source
        AudioSource source = Instantiate(sourcePrefab);

        // set its variables
        source.clip = clip;
        source.volume = volume;

        // play the sound
        source.Play();

        // ensure it stays alive, say when we reload RN
        DontDestroyOnLoad(source);

        // destroy GO after play time
        Destroy(source.gameObject, clip.length);
    }

    public void PlayRandomClip(AudioClip[] clips, float volume)
    {
        // pick a random clip and pass it as the to be played clip
        PlayClip(clips[Random.Range(0, clips.Length)], volume);
    }
}
