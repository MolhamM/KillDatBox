using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletShot : MonoBehaviour
{
    public string targetTag;
    public string allayTag;
    public string allayShootPoint;
    public string enemyRocketTag;
    GameObject shoot;
    GameObject player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag(allayTag);
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        if(allayTag == "player1")
        {
            enemyRocketTag = "rocket2";
        }
        else if (allayTag == "player2")
        {
            enemyRocketTag = "rocket1";
        }

    }
    void Start()
    {
        shoot = GameObject.FindGameObjectWithTag(allayShootPoint);

        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2((shoot.transform.position.x - player.transform.position.x ), (shoot.transform.position.y- player.transform.position.y)) * 500);
        player.GetComponent<Rigidbody2D>().AddForce(new Vector2((player.transform.position.x - shoot.transform.position.x), (player.transform.position.y - shoot.transform.position.y)) * 50);
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == targetTag)
        {
            GameObject.FindGameObjectWithTag(allayTag).gameObject.GetComponent<PlayerStats>().IncreaseRewindValue();
        }
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == enemyRocketTag)
        {
            Destroy(collision.gameObject);
        }
    }
}
