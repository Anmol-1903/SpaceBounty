using UnityEngine;
using UnityEngine.UI;
public class MusicSound : MonoBehaviour
{
    public static MusicSound instance;
    [SerializeField] private Slider VolumeSlider;
    [SerializeField] private AudioSource _effectSource;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        AudioListener.volume = VolumeSlider.value;
    }
    public void Playsound(AudioClip clip)
    {
        _effectSource.PlayOneShot(clip);
    }
    public void ChangeMasterVol()
    {
        AudioListener.volume = VolumeSlider.value;
    }
}