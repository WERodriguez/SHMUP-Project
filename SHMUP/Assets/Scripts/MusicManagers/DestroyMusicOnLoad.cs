﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMusicOnLoad : MonoBehaviour
{
    void Start()
    {
        Destroy(GameObject.Find("MenuMusicController"));
        Destroy(GameObject.Find("HangarMusicController"));
    }
}
