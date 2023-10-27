using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitter : MonoBehaviour
{

    [SerializeField] Button button;
    [SerializeField] BagpipeLogic bard;

    [SerializeField] private int count = 3;
    [SerializeField] private int hitsNeeded = 5;
    bool colliderState = false;
    // Update is called once per frame
    IEnumerator deactivateCollider()
    {
        Debug.Log("Active");
        GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(0.2f);
        Debug.Log("Unactive");
        GetComponent<BoxCollider2D>().enabled = false;
    }
    void Update()
    {
        colliderState = button.tapActive;
        if (colliderState)
        {
            Debug.Log("True");
            StartCoroutine(deactivateCollider());
        }
    }

    public void moveOver()
    {
        double y_pos = transform.position.y;
        Debug.Log(y_pos);

        if (y_pos < 0) {
            transform.position += new Vector3(0f, 4.07f, 0f);
        }
        else if (y_pos > 0 && y_pos < 4)
        {
            transform.position += new Vector3(0f, 3.88f, 0f);
        }
        else {
            transform.position += new Vector3(0f, -7.95f, 0f);
        }
    }

    public void destroyedCount()
    {
        count++;
        Debug.Log(count);
        if (count >= hitsNeeded)
        {
            bard.Shoot();
            count = 0;
        }
    }
}
