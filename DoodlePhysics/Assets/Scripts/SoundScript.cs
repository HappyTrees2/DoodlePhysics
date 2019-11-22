using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Controls Music On and Off 
public class SoundScript : MonoBehaviour
{
    private Music music;
    public GameObject musicToggleButton;
    public Sprite musicOn;
    public Sprite musicOff;

    void Start()
    {
        music = GameObject.FindObjectOfType<Music>();
        if(AudioListener.pause == true)
        {
            musicToggleButton.GetComponent<Image>().sprite = musicOff;
        }
        else
        {
            musicToggleButton.GetComponent<Image>().sprite = musicOn;
        }
    }


    public void SoundControl()
    {
        if (AudioListener.pause == true)
        {
            AudioListener.pause = false;
            musicToggleButton.GetComponent<Image>().sprite = musicOn;
        }
        else
        {
            AudioListener.pause = true;
            musicToggleButton.GetComponent<Image>().sprite = musicOff;
        }
    }
}
