using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

namespace UI
{
    public class ScreenRes : MonoBehaviour
    {
        [SerializeField]
        private TMP_Dropdown resolutionsOptions;

        private Resolution[] resolutions;

        public void ResChange (int resIndex)
        {
            Resolution resolution = resolutions[resIndex];

            Screen.SetResolution (resolution.width, resolution.height, Screen.fullScreen);
        }

        public void SetFullscreen (bool isFullscreen)
        {
            Screen.fullScreen = isFullscreen;
        }

        private void Start ()
        {
            resolutions = Screen.resolutions.Select (resolution => new Resolution
            {
                width = resolution.width,
                height = resolution.height
            }).Distinct ().ToArray ();

            resolutionsOptions.ClearOptions ();

            List<string> options = new List<string> ();
            int currentRes = 0;
            for (int i = 0; i < resolutions.Length; i++)
            {
                string option = resolutions[i].width + " x " + resolutions[i].height;
                options.Add (option);

                if (resolutions[i].width == Screen.currentResolution.width
                    &&
                    resolutions[i].height == Screen.currentResolution.height)
                {
                    currentRes = i;
                }
            }
            resolutionsOptions.AddOptions (options);
            resolutionsOptions.value = currentRes;
            resolutionsOptions.RefreshShownValue ();
        }
    }
}