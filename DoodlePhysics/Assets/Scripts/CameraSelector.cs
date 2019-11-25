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

                    GUIStyle customButton = new GUIStyle("button");
                    customButton.fontSize = 40;
                    customButton.font = (UnityEngine.Font)Resources.Load("Tioem-Handwritten");
                    customButton.imagePosition = ImagePosition.TextOnly;

                    GUIContent buttonContent = new GUIContent(device.name);
                    buttonContent.image = (UnityEngine.Texture)Resources.Load("nicole_button");

                    if (GUILayout.Button(buttonContent,
                                         customButton,
                                         GUILayout.MinWidth(Screen.width - 20),
                                         GUILayout.MinHeight(Screen.height / 8),
                                         GUILayout.MaxHeight(Screen.height / 8),
                                         GUILayout.MaxWidth(Screen.width - 20)))
                    {
                        PlayerPrefs.SetString("ActiveCamera", device.name);

                        SceneManager.LoadScene(2);
                    }
                }
                GUILayout.EndArea();
            }
        }
        else
        {
            GUILayout.Label("Pending Camera Authorization...");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
