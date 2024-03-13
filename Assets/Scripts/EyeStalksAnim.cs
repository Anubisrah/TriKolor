using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeStalksAnim : MonoBehaviour
{
    [SerializeField] PlayerInteraction playerInteraction;
    Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        myAnimator.SetBool("isAlive", playerInteraction.isAlive);
    }
}
