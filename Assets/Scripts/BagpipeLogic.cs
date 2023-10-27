using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BagpipeLogic : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject target;

    [SerializeField] private GameObject projectile;
    public AudioClip[] notes;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var keyJ = Input.GetKey(KeyCode.J);

        if (keyJ)
        {
            animator.SetTrigger("Blast");
            StartCoroutine(ShootDelay(1.44f));
            GetComponent<AudioSource>().Play();
        }

    }

    IEnumerator ShootDelay(float delay)
    {
        yield return new WaitForSeconds(0.35f);
        int rnd = Random.Range(0, 3);
        Debug.Log("RANDOM: " + rnd);
        GetComponent<AudioSource>().PlayOneShot(notes[rnd]);
        yield return new WaitForSeconds(delay);
        Debug.Log("Delay Done");
        GameObject bullet = Instantiate(projectile, transform);
        bullet.GetComponent<Projectile>().SetTarget(enemy.transform);
        yield return new WaitForSeconds(0.05f);
        GameObject bullet1 = Instantiate(projectile, transform);
        bullet1.GetComponent<Projectile>().SetTarget(enemy.transform);
        yield return new WaitForSeconds(0.05f);
        GameObject bullet2 = Instantiate(projectile, transform);
        bullet2.GetComponent<Projectile>().SetTarget(enemy.transform);
        yield return new WaitForSeconds(0.05f);
        GameObject bullet3 = Instantiate(projectile, transform);
        bullet3.GetComponent<Projectile>().SetTarget(enemy.transform);
        //bullet.GetComponent<Projectile>().SetIntroTarget(target.transform);
    }

    public void Shoot()
    {
        animator.SetTrigger("Blast");
        StartCoroutine(ShootDelay(1.24f));
        
    }
}
