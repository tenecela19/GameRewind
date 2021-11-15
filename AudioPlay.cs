using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
public void PlayButtonSong(string Song)
    {
        FindObjectOfType<AudioManager>().Play(Song);
    }
}
