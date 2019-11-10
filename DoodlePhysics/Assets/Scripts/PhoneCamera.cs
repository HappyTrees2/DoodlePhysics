using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PhoneCamera : MonoBehaviour
{
    private bool camAvailable;
    private Texture defaultBackground;
    private WebCamTexture camera;

    public RawImage background;
    public AspectRatioFitter fit;

    /// <summary>
    /// The web cam texture
    /// </summary>
    private WebCamTexture m_texture = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!camAvailable)
        {
            string cameraName = PlayerPrefs.GetString("ActiveCamera");
            camera = new WebCamTexture(cameraName, Screen.width, Screen.height);

            camera.Play();
            background.texture = camera;

            camAvailable = true;
        }

        if (camAvailable == true)
        {
            float ratio = (float)camera.width / (float)camera.height;
            fit.aspectRatio = ratio;

            float scaleY = camera.videoVerticallyMirrored ? -1f : 1f;
            background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

            int orient = -camera.videoRotationAngle;
            background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
        }


        //UnityEngine.Texture2D newTexture = (UnityEngine.Texture2D)defaultBackground;
        //background.texture = newTexture;
    }
}
