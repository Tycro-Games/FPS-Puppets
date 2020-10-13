using UnityEngine;

namespace UnityStandardAssets.Characters.FirstPerson
{
    public class PlayFootstetpsSounds : MonoBehaviour
    {
        [SerializeField]
        private AudioClip[] m_FootstepSounds;

        private AudioSource m_AudioSource;

        public void PlayFootStepAudio ()
        {
            // pick & play a random footstep sound from the array, excluding sound at index 0
            int n = Random.Range (1, m_FootstepSounds.Length);
            m_AudioSource.clip = m_FootstepSounds[n];
            m_AudioSource.PlayOneShot (m_AudioSource.clip);
            // move picked sound to index 0 so it's not picked next time
            m_FootstepSounds[n] = m_FootstepSounds[0];
            m_FootstepSounds[0] = m_AudioSource.clip;
        }

        private void Start ()
        {
            m_AudioSource = GetComponent<AudioSource> ();
        }
    }
}