using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport: MonoBehaviour
{
    private AudioSource finishSoundEffect;
    private bool tele = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !tele)
        {
            tele = true;
            Invoke("Secret", 2f);
        }
    }

    private void Secret()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}
