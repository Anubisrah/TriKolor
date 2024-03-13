using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesAnimationScript : MonoBehaviour
{

    [SerializeField] EyeScript eyeScript;
    Animator myAnimator;

   // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ColorsUpdate();
    }

    void ColorsUpdate()
    {
        myAnimator.SetBool("isRedOn", eyeScript.isRedOn);
        myAnimator.SetBool("isGreenOn", eyeScript.isGreenOn);
        myAnimator.SetBool("isBlueOn", eyeScript.isBlueOn);
    }

}
