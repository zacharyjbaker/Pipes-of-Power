using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Button : MonoBehaviour
{
    //[SerializeField] private AudioClip note;
    [SerializeField] private AudioClip longNote;
    [SerializeField] private Hitter hitter;
    [SerializeField] public AudioClip[] notes;
    [SerializeField] public AudioClip[] chords;
    private bool hold = false;
    public bool tapActive = false;
    public bool holdActive = false;
    // Start is called before the first frame update
    IEnumerator delaySound(AudioClip clip, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (hold == true)
        {
            tapActive = false;
            hitter.moveOver();
            GetComponent<AudioSource>().PlayOneShot(clip);
        }
    }
    public void playNote()
    {
        int rnd = Random.Range(0, 6);
        GetComponent<AudioSource>().PlayOneShot(notes[rnd]);
        tapActive = true;
    }
    public void playLong()
    {
        int rnd = Random.Range(0, 5);
        StartCoroutine(delaySound(chords[rnd], 0.12f));
        hold = true;
        tapActive = false;

    }
    public void unPlayLong()
    {
        hold = false;
        holdActive = false;
    }

    private void Update()
    {
        tapActive = false;
    }
}
