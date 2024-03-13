using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ColoredObject : MonoBehaviour
{

    EyeScript eyeScript;

    // Update is called once per frame
    void Start()
    {
        eyeScript = Object.FindObjectOfType<EyeScript>();
    }
    void Update()
    {
        CheckColors();
    }

    void CheckColors()
    {
        if(this.gameObject.layer == LayerMask.NameToLayer("Red"))
        {
            ToggleCollider(eyeScript.isRedOn);
            ToggleSprites(eyeScript.isRedOn);
        }
        if(this.gameObject.layer == LayerMask.NameToLayer("Green"))
        {
            ToggleCollider(eyeScript.isGreenOn);
            ToggleSprites(eyeScript.isGreenOn);
        }
        if(this.gameObject.layer == LayerMask.NameToLayer("Blue"))
        {
            ToggleCollider(eyeScript.isBlueOn);
            ToggleSprites(eyeScript.isBlueOn);
        }
    }

    void ToggleCollider(bool isColorOn)
    {
       this.GetComponent<Collider2D>().enabled = isColorOn;

    }

    void ToggleSprites(bool isColorOn)
    {
        SpriteRenderer[] spriteRenderers =  this.gameObject.GetComponentsInChildren<SpriteRenderer>();
        for(int i = 0; i < spriteRenderers.Length; i++)
        {
            spriteRenderers[i].enabled = isColorOn;
        }
    }

}
