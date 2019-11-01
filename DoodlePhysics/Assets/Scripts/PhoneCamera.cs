using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneCamera : MonoBehaviour
{
    private bool camAvailable;
    private Texture defaultBackground;
    private WebCamTexture backCam;

    public RawImage background;
    public AspectRatioFitter fit;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!camAvailable)
        {
            defaultBackground = background.texture;
            WebCamDevice[] devices = WebCamTexture.devices;

            if (devices.Length == 0)
            {
                Debug.Log("No camera detected");
                camAvailable = false;
                return;
            }

            for (int i = 0; i < devices.Length; i++)
            {
                Debug.Log(devices[i].name);
                if (devices[i].name == "Back Camera" || devices[i].name == "Remote Back Camera")
                {
                    Debug.Log(devices[i].name);
                    backCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
                }
            }

            if (backCam == null)
            {
                Debug.Log("Unable to find back camera");
                return;
            }

            backCam.Play();
            background.texture = backCam;

            camAvailable = true;
        }

        if (camAvailable == true)
        {
            float ratio = (float)backCam.width / (float)backCam.height;
            fit.aspectRatio = ratio;

            float scaleY = backCam.videoVerticallyMirrored ? -1f : 1f;
            background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

            int orient = -backCam.videoRotationAngle;
            background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
        }


        //UnityEngine.Texture2D newTexture = (UnityEngine.Texture2D)defaultBackground;
        //background.texture = newTexture;
    }
}
