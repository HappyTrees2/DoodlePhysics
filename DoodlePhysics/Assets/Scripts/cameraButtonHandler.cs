using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class cameraButtonHandler : MonoBehaviour
{
    static public bool[,] binArray;

    public void captureDoodle(RawImage background)
    {
        #region image capture
        WebCamTexture capture = (UnityEngine.WebCamTexture)background.texture;
        Color[] Pixels = capture.GetPixels();
        binArray = new bool[capture.width, capture.height];

        Debug.Log(capture.width);
        Debug.Log(capture.height);

        for (int i = 0; i < Pixels.Length; i++)
        {
            float avgColor = (Pixels[i][0] + Pixels[i][1] + Pixels[i][2]) / 3;
            if (avgColor >= 0.3)
            {
                binArray[(capture.width - 1) - (i % capture.width), i / capture.width] = false;
            }
            else
            {
                binArray[(capture.width - 1) - (i % capture.width), i / capture.width] = true;
            }
        }
        #endregion
        /*
                #region array output
                string row;
                for (int i = 0; i < capture.width; i++)
                {
                    row = "";
                    for (int j = 0; j < capture.height; j++)
                    {
                        if (binArray[i, j])
                        {
                            row += "1";
                        }
                        else
                        {
                            row += "0";
                        }
                    }
                    Debug.Log(row);
                }
                #endregion
            */
        SceneManager.LoadScene(3);
    }
}
