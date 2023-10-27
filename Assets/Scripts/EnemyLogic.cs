using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private float health = 10f;
    SpriteRenderer enemySprite;
    [SerializeField] public AudioClip clip;
    [SerializeField] public End end;
    Color def;

    void Start()
    {
        enemySprite = GetComponent<SpriteRenderer>();
        def = enemySprite.color;
        animator = this.GetComponent<Animator>();
    }
    
    IEnumerator Shake()
    {
        enemySprite.color = Color.red;
        for (int i = 0; i < 12; i++)
        {
            transform.localPosition += new Vector3(0.06f, 0, 0);
            yield return new WaitForSeconds(0.01f);
            transform.localPosition -= new Vector3(0.06f, 0, 0);
            yield return new WaitForSeconds(0.01f);
        }
        enemySprite.color = def;    
    }

    IEnumerator Death()
    {
        animator.SetTrigger("Death");
        GetComponent<AudioSource>().clip = clip;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1.0f);
        end.Win();
        Destroy(gameObject);
        //Time.timeScale = 0;
    }

        public void TakeHit(float damage)
    {
        health -= damage;
        GetComponent<AudioSource>().Play();
        if (health <= 0)
        {
            Debug.Log("You Win!");
            StartCoroutine(Death());
            //Time.timeScale = 0;
        }
        StartCoroutine(Shake());

    }

}
