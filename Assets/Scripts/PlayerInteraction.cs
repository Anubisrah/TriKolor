using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{

    [SerializeField] AudioClip deathSound;
    AudioSource myAudio;
    public bool isAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        switch(other.tag)
        {
            case "Finish":
            LoadNextLevel();
            break;

            case "Hazard":
            Bleh();
            break;
        }

    }


    void Bleh()
    {
        isAlive = false;
        myAudio.PlayOneShot(deathSound);
        Invoke("ReloadLevel", 1);
    }
    void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
