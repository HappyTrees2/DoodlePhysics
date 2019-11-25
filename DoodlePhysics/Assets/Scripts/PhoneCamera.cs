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
    private float backHeight;
    public float backWidth;
    public RectTransform canvasDims;

    public RawImage background;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!camAvailable)
        {
            backHeight = canvasDims.rect.height;
            backWidth = canvasDims.rect.width;

            string cameraName = PlayerPrefs.GetString("ActiveCamera");
            camera = new WebCamTexture(cameraName, (int)backWidth, (int)backHeight);

            camera.Play();

            background.texture = camera;

            camAvailable = true;
        }

        if (camAvailable == true)
        {
            backHeight = canvasDims.rect.height;
            backWidth = canvasDims.rect.width;

            float scaleY = camera.videoVerticallyMirrored ? -1f : 1f;
            background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

            int orient = -camera.videoRotationAngle;
            background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);

            if (orient != 0)
            {
                background.rectTransform.sizeDelta = new Vector2(backHeight, backWidth);
            }
            else
            {
                background.rectTransform.sizeDelta = new Vector2(backWidth, backHeight);
            }

            background.rectTransform.position = new Vector3(canvasDims.position.x, canvasDims.position.y, 0);
        }
    }
}
