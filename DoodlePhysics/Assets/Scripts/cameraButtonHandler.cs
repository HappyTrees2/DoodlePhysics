using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class cameraButtonHandler : MonoBehaviour
{
    static public bool[,] binArray;
    private Color[] Pixels;
    private float[,] avgColor;
    const float _edgeThreshold = 0.1F;

    public void captureDoodle(RawImage background)
    {
        #region image capture
        WebCamTexture capture = (UnityEngine.WebCamTexture)background.texture;
        Pixels = capture.GetPixels();
        binArray = new bool[capture.width, capture.height];
        avgColor = new float[capture.width, capture.height];

        Debug.Log(capture.width);
        Debug.Log(capture.height);

        for (int i = 0; i < Pixels.Length; i++)
        {
            int x = (capture.width - 1) - (i % capture.width);
            int y = i / capture.width;
            _getAverageColor(x, y, i);
            if(x > 0)
            {
                _getAverageColor(x - 1, y, i + 1);
            }
            if((y + 1) < capture.height)
            {
                _getAverageColor(x, y + 1, i + capture.width);
            }

            binArray[x, y] = _isEdge(x, y, capture.width, capture.height);
        }
        #endregion
        SceneManager.LoadScene(3);
    }

    private bool _isEdge(int x, int y, int width, int height)
    {
        if (y < (height - 1) && _checkBottomEdge(x, y))
        {
            return true;
        }

        if (y > 0 && _checkTopEdge(x, y))
        {
            return true;
        }

        if (x < (width - 1) && _checkRightEdge(x, y))
        {
            return true;
        }

        if (x > 0 && _checkLeftEdge(x, y))
        {
            return true;
        }

        return false;
    }

    private bool _checkBottomEdge(int x, int y)
    {
        if(Mathf.Abs(avgColor[x,y] - avgColor[x,y+1]) > _edgeThreshold)
        {
            return true;
        }
        return false;
    }

    private bool _checkTopEdge(int x, int y)
    {
        if (Mathf.Abs(avgColor[x, y] - avgColor[x, y - 1]) > _edgeThreshold)
        {
            return true;
        }
        return false;
    }

    private bool _checkRightEdge(int x, int y)
    {
        if (Mathf.Abs(avgColor[x, y] - avgColor[x + 1, y]) > _edgeThreshold)
        {
            return true;
        }
        return false;
    }

    private bool _checkLeftEdge(int x, int y)
    {
        if (Mathf.Abs(avgColor[x, y] - avgColor[x - 1, y]) > _edgeThreshold)
        {
            return true;
        }
        return false;
    }

    private void _getAverageColor(int x, int y, int i)
    {
        if(!(avgColor[x,y] > 0.0))
        {
            avgColor[x,y] = (Pixels[i][0] + Pixels[i][1] + Pixels[i][2]) / 3;
        }
    }
}
