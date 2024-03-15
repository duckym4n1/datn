using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSecret: MonoBehaviour
{
    private AudioSource finishSoundEffect;
    private bool end = false;
    // Start is called before the first frame update
    void Start()
    {
        finishSoundEffect = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !end)
        {
            finishSoundEffect.Play();
            end = true;
            Invoke("Secret", 2f);
        }
    }

    private void Secret()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -2);
    }
}
