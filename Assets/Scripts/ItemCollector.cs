using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    //private int cherries =0;
    [SerializeField] private Text cherriesText;
    [SerializeField] private AudioSource collectSoundEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            Health health = this.GetComponent<Health>();
            health.Healing(30);
            health.Experience(40);
        }
    }
}
