using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewBehaviourScript : MonoBehaviour
{
    private int banana = 0;
    [SerializeField] private Text bananaText;
    [SerializeField] private AudioSource colletionSoundEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            colletionSoundEffect.Play();
            Destroy(collision.gameObject); //Destroy o objeto que colidiu(banana)
            banana++;
            bananaText.text = "Bananas: " + banana;
        }
    }

}
