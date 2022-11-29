using UnityEngine;
public class PlaySound : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;
    void Start()
    {
        MusicSound.instance.Playsound(_clip);
    }
}