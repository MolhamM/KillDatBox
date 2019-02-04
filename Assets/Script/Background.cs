using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    public Sprite Desert;
    public Sprite Mountain;
    
    void Update()
    {
        if(SavedData.GetBackground() == "Desert")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Desert;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Mountain;
        }
    }
    public void ChooseDesert()
    {
        SavedData.ChangeToDesert();
    }
    public void ChooseMountain()
    {
        SavedData.ChangeToMountain();
    }
}
