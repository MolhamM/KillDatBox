using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public KeyCode Rotate;
    public KeyCode Rotate2;
    public KeyCode Shoot;
    public KeyCode Rewind;
    public KeyCode RocketShot;
    public GameObject bullet;
    public GameObject shootPoint;
    public GameObject rocket;
    int speed;
    bool IsPlayerActive;
    void Start()
    {
        speed = 5;
        IsPlayerActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPlayerActive)
        {
            CheckMovments();
        }
    }
   public void CheckMovments()
    {
        if (Input.GetKey(Rotate))
        {
            gameObject.transform.eulerAngles += new Vector3(0, 0, gameObject.transform.rotation.z + speed);
        }
        if (Input.GetKey(Rotate2))
        {
            gameObject.transform.eulerAngles += new Vector3(0, 0, gameObject.transform.rotation.z - speed);
        }
        if (Input.GetKeyDown(Shoot))
        {
            Instantiate(bullet, gameObject.transform.position ,Quaternion.identity);
        }
        if (Input.GetKeyDown(Rewind)&& gameObject.GetComponent<PlayerStats>().CanRewind())
        {
            SetPlayerDeActivated();
            gameObject.GetComponent<PlayerStats>().RewindPlayer();
        }
        if (Input.GetKeyDown(RocketShot) && gameObject.GetComponent<PlayerStats>().isThereRocket())
        {
            Instantiate(rocket, this.transform.position, Quaternion.identity);
            gameObject.GetComponent<PlayerStats>().DecreaseRockets();
        }
    }
   public void SetPlayerActive()
    {
        IsPlayerActive = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
    void SetPlayerDeActivated()
    {
        IsPlayerActive = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
    public bool GetPlayerState()
    {
        return IsPlayerActive;
    }
}
