using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraSelector : MonoBehaviour
{
    /// <summary>
    /// The selected device index
    /// </summary>
    private int m_indexDevice = -1;

    /// <summary>
    /// The web cam texture
    /// </summary>
    private WebCamTexture m_texture = null;


    // Start is called before the first frame update
    void Start()
    {
        Application.RequestUserAuthorization(UserAuthorization.WebCam);
    }

    void OnGUI()
    {
        if (m_indexDevice >= 0 && WebCamTexture.devices.Length > 0)
        {
        }

        if (Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            GUILayout.BeginArea(new Rect(10, Screen.height / 8, 1500, 2500));
            if (null == WebCamTexture.devices)
            {
            }
            else
            {
                for (int index = 0; index < WebCamTexture.devices.Length; ++index)
                {
                    var device = WebCamTexture.devices[index];
                    if (string.IsNullOrEmpty(device.name))
                    {
                        GUILayout.Label("unnamed web cam device");
                        continue;
                    }

                    if (GUILayout.Button(string.Format("{0}{1}{2}",
                                                       m_indexDevice == index
                                                       ? "["
                                                       : string.Empty,
                                                       device.name,
                                                       m_indexDevice == index ? "]" : string.Empty),
                                         GUILayout.MinWidth(Screen.width - 20),
                                         GUILayout.MinHeight(Screen.height / 8),
                                         GUILayout.MaxHeight(Screen.height / 8),
                                         GUILayout.MaxWidth(Screen.width - 20)))
                    {
                        m_indexDevice = index;

                        // stop playing
                        if (null != m_texture)
                        {
                            if (m_texture.isPlaying)
                            {
                                m_texture.Stop();
                            }
                        }

                        // destroy the old texture
                        if (null != m_texture)
                        {
                            UnityEngine.Object.DestroyImmediate(m_texture, true);
                        }

                        // use the device name
                        //m_texture = new WebCamTexture(device.name, Screen.width, Screen.height);

                        PlayerPrefs.SetString("ActiveCamera", device.name);

                        SceneManager.LoadScene(2);
                    }
                }
                GUILayout.EndArea();
            }
        }
        else
        {
            GUILayout.Label("Pending WebCam Authorization...");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
