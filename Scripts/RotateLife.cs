﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLife : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 200) * Time.deltaTime);
    }
}
