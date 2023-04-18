using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTester : MonoBehaviour
{
    public int activationInt;

    private void Update()
    {

        if (activationInt == 1)
        {
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }
}
