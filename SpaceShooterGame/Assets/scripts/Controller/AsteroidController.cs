﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    #region Public Variable
    [Range(5,100)]
    public float Speed = 5, RotaionSpeed = 20;
    #endregion

    #region Private Functions
    private void Update()
    {
        //  سقوط سیاره
        transform.position += Vector3.down * Speed * Time.deltaTime;
        transform.Rotate(Vector3.forward * RotaionSpeed * Time.deltaTime);
    }
    #endregion

}
