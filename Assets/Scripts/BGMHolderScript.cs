using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMHolderScript : MonoBehaviour
{
    public bool isMute;

    private static BGMHolderScript _instance;
    public static BGMHolderScript Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }
    
    void Update()
    {
        if (isMute) transform.GetComponent<AudioSource>().mute = true;
        else if (!isMute) transform.GetComponent<AudioSource>().mute = false;
    }
}
