using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SceneManger : MonoBehaviour
{
    public void ChangeScene(string Scenename)
    {
        Application.LoadLevel(Scenename);
    }
}
