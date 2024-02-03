using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeedManager 
{
    public float GameSpeed { get; set; }



    public void Build()
    {
        GameSpeed = ManagerContainer.Instance.GameSpeed;
    }
}
