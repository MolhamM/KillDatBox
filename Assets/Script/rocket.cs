using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket : MonoBehaviour
{
    public string targetTag;
    public string allayTag;
    GameObject target;
    GameObject allay;
    float speed;
    void Start()
    {
        speed = .1f;
        target = GameObject.FindGameObjectWithTag(targetTag);
        allay = GameObject.FindGameObjectWithTag(allayTag);
        Physics2D.IgnoreCollision(allay.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        StartCoroutine(DestroyThis(3));
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
        gameObject.transform.eulerAngles += new Vector3(0, 0, gameObject.transform.rotation.z + 15);
    }
        
    IEnumerator DestroyThis(float sec)
    {
        yield return new WaitForSeconds(sec);
        Destroy(this.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == targetTag)
        {
            GameObject.FindGameObjectWithTag(allayTag).gameObject.GetComponent<PlayerStats>().IncreaseRewindValue();
        }
        Destroy(gameObject);
    }
}
