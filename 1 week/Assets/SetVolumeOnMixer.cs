using UnityEngine;
using UnityEngine.Audio;

namespace UI
{
    public class SetVolumeOnMixer : MonoBehaviour
    {
        public AudioMixer audioMixer;

        public void SetVolume (float volume)
        {
            audioMixer.SetFloat ("Volume", volume);
        }
    }
}