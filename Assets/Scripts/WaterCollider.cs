using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollider : MonoBehaviour
{
    AudioManager audioManager;
    bool canPlaySound = true;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Player" && canPlaySound) || (other.tag == "Wall" && canPlaySound))
        {
            audioManager.PlayVoice(Random.Range(0, 6));
            audioManager.PlaySFX(3);
            canPlaySound = false;
            StartCoroutine(SoundDelay());
        }
    }

    IEnumerator SoundDelay()
    {
        yield return new WaitForSeconds(1);
        canPlaySound = true;
    }
}
