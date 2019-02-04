using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SavedData 
{
    // Start is called before the first frame update
    static string Background = "Mountain";
    
    public static void ChangeToMountain()
    {
        Background = "Mountain";
    }
    public static void  ChangeToDesert()
    {
        Background = "Desert";
    }
    public static string GetBackground()
    {
        return Background;
    }
}
