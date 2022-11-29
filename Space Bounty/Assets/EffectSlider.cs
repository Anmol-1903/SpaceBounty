using UnityEngine;
using UnityEngine.UI;
public class EffectSlider : MonoBehaviour
{
    [SerializeField] private Slider Eslider;
    void Start()
    {
        Eslider.onValueChanged.AddListener(val => MusicSound.instance.ChangeMasterVol());
    }
}