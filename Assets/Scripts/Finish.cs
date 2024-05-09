using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSoundEffect;
    private bool levelComplete = false;
    public int lvl;
    // Start is called before the first frame update
    void Start()
    {
        this.lvl = PlayerPrefs.GetInt("scene", 0);
        finishSoundEffect= GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name== "Player" && !levelComplete)
        {
            lvl++;
            PlayerPrefs.SetInt("scene", lvl);
            finishSoundEffect.Play();
            levelComplete = true;
            Invoke("CompleteLevel", 2f);
        }
    }
    
    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
