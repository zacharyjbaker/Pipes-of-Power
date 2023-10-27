using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Pool;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 20;
    private Rigidbody2D rigidbody_2D;
    private UnityEngine.Transform target;
    //private Transform introTarget;
    private UnityEngine.Transform start;
    public AnimationCurve curve;
    private Coroutine coroutine;
    [SerializeField] private float dmgValue = 1f;

    IEnumerator shoot(UnityEngine.Transform start)
    {
        /*yield return new WaitForSeconds(delay);
        speed *= 2;
        transform.position = Vector3.MoveTowards(transform.position, introTarget.position, speed * Time.deltaTime); */

        float duration = 2f;
        float time = 0f;
        Vector3 p = start.position;
        p.y += 1.6f;
        p.x -= 0.5f;

        Vector3 end = target.position; // lead the target a bit to account for travel time, your math will vary

        while (time < duration)
        {
            time += Time.deltaTime;

            float linearT = time / duration;
            float heightT = curve.Evaluate(linearT);

            float height = Mathf.Lerp(0f, 6.5f, heightT); // change 3 to however tall you want the arc to be
            transform.position = Vector2.Lerp(p , end, linearT) + new Vector2(0f, height);
            Vector3 dir = end - transform.position;
            dir.y += 3;

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            yield return null;
        }

        // impact

        coroutine = null;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hit!");
        if (other.CompareTag("Enemy"))
        {
            // Call script method on enemy
            other.gameObject.GetComponent<EnemyLogic>().TakeHit(0.25f);
            Destroy(gameObject);
        }
        if (other.CompareTag("End"))
        {
            other.gameObject.GetComponent<End>().LoseHeart();
            Destroy(gameObject);
        }
    }

    public void SetTarget(UnityEngine.Transform t)
    {
        this.target = t;
        Debug.Log("intro: ", target);
    }

    /*public void SetIntroTarget(Transform t)
    {
        this.introTarget = t;
        Debug.Log("intro: ", introTarget);
    }*/

    void Start()
    {
        rigidbody_2D = this.GetComponent<Rigidbody2D>();
        start = this.transform;
        coroutine = StartCoroutine(shoot(start));

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
        }
        else
        {
            float target_x = target.transform.position.x - this.transform.position.x;
            float target_y = target.transform.position.y - this.transform.position.y;
            //transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            //float angle = Mathf.Atan2(target_y, target_x) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
}
