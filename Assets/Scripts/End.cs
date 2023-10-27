using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    [SerializeField] private int hearts = 3;
    [SerializeField] private Camera main_camera;
    [SerializeField] private TMP_Text gameOver;
    [SerializeField] private TMP_Text gameOverShadow;
    [SerializeField] public AudioClip clip;
    [SerializeField] public AudioClip winClip;

    public void LoseHeart()
    {
        hearts--;
        if (hearts <= 0)
        {
            Debug.Log("Game Over!");
            gameOver.color = new Color32(200, 0, 0, 255);
            gameOverShadow.color = new Color32(0, 0, 0, 255);
            GetComponent<AudioSource>().PlayOneShot(clip);
            Time.timeScale = 0;

        }
        else
        {
            GetComponent<AudioSource>().Play();
            main_camera.GetComponent<CameraShake>().Shake();
        }
        
        
    }

    public void Win()
    {
        gameOver.color = new Color32(60, 175, 168, 255);
        gameOver.SetText("VICTORY!");
        gameOverShadow.color = new Color32(0, 0, 0, 255);
        gameOverShadow.SetText("VICTORY!");
        GetComponent<AudioSource>().PlayOneShot(winClip);
        Time.timeScale = 0;
    }
}
