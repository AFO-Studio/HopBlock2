using UnityEngine;


//Tutorial was used as a basic guide to the groundworks of this script.
//https://www.youtube.com/watch?v=HhFKtiRd0qI
//Channel is Brackeys, video title: 25. How to Make a  2D Platformer - AUDIO MANAGER - Unity Tutorial.
//Many things were modified, but the starting point came from here. 

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume = 0.7f;
    [Range(0.5f, 1.5f)]
    public float pitch = 1f;

    [Range(0f, 0.5f)]
    public float randomVolume = 0.1f;
    [Range(0f, 0.5f)]
    public float randomPitch = 0.1f;

    private AudioSource source;

    public void SetSource(AudioSource _source)
    {
        source = _source;
        source.clip = clip;
    }


    public void Play(bool _loop)
    {
        source.volume = volume * (1+ Random.Range(-randomVolume/2f, randomVolume/2f));
        source.pitch = pitch * (1 + Random.Range(-randomPitch/2f, randomPitch/2f));
        source.loop = _loop;
        source.Play();
    }

    //allows looping
    public void Play()
    {
        source.volume = volume * (1 + Random.Range(-randomVolume / 2f, randomVolume / 2f));
        source.pitch = pitch * (1 + Random.Range(-randomPitch / 2f, randomPitch / 2f));
        source.Play();

    }
}

//[System.Serializable]
public class MusicManager : MonoBehaviour
{

    public static MusicManager instance;

    [SerializeField]
    Sound[] sounds;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one SongManager in the scene.");
        }

        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject _go = new GameObject("Sound_" + i + "_" + sounds[i].name);
            _go.transform.SetParent(this.transform);
            sounds[i].SetSource(_go.AddComponent<AudioSource>());
        }
    }


    public void PlaySound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                sounds[i].Play();
                return;
            }
        }

        //not found
        Debug.Log("That song doesn't exist: " + _name);
    }

    //allows looping
    public void PlaySound(string _name, bool _loop)
    {
        //searches for song of the same name as given before playing it.
        for (int i = 0; i < sounds.Length; i++)
        {
            if(sounds[i].name == _name)
            {
                sounds[i].Play(_loop);
                return;
            }
        }

        //not found
        Debug.Log("That song doesn't exist: " + _name);
    }
}
