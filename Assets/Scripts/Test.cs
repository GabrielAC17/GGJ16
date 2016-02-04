using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour
{

    private KeyCombo falconPunch = new KeyCombo(new string[] { "B1", "B2", "B3" , "B1"});
    private KeyCombo falconKick = new KeyCombo(new string[] { "B3", "B2", "B1", "B1" });

    void Update()
    {
        if (falconPunch.Check())
        {
            // do the falcon punch
            Debug.Log("PUNCH");
        }
        if (falconKick.Check())
        {
            // do the falcon punch
            Debug.Log("KICK");
        }
    }
}