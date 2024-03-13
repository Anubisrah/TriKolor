using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeScript : MonoBehaviour
{
    [SerializeField] AudioClip RedOn;
    [SerializeField] AudioClip RedOff;
    [SerializeField] AudioClip GreenOn;
    [SerializeField] AudioClip GreenOff;
    [SerializeField] AudioClip BlueOn;
    [SerializeField] AudioClip BlueOff;
    AudioSource myAudio;
    enum EyeColor {
        Red = 0,
        Green,
        Blue
    };
    public bool isGreenOn = true;
    public bool isBlueOn = true;
    public bool isRedOn = true;

    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        InputHandler();
    }

    void ToggleColors(EyeColor color)
    {
        switch(color)
        {
            case EyeColor.Red:
                isRedOn = !isRedOn;
            break;

            case EyeColor.Green:
                isGreenOn = !isGreenOn;
            break;

            case EyeColor.Blue:
                isBlueOn  = !isBlueOn;
            break;
        }
    }

    void InputHandler()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            ToggleColors(EyeColor.Red);
            if(isRedOn)
            {
                myAudio.PlayOneShot(RedOn);
            }
            else
            {
                myAudio.PlayOneShot(RedOff);
            }
        }
        if(Input.GetKeyDown(KeyCode.K))
        {
            ToggleColors(EyeColor.Green);
            if(isGreenOn)
            {
                myAudio.PlayOneShot(GreenOn);
            }
            else
            {
                myAudio.PlayOneShot(GreenOff);
            }
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
            ToggleColors(EyeColor.Blue);
            if(isBlueOn)
            {
                myAudio.PlayOneShot(BlueOn);
            }
            else
            {
                myAudio.PlayOneShot(BlueOff);
            }
        }
    }

}
