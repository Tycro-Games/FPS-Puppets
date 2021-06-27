using UnityEngine;

namespace UI
{
    public class SetQuality : MonoBehaviour
    {
        public void SetQualitySettings (int index)
        {
            QualitySettings.SetQualityLevel (index);
        }
    }
}