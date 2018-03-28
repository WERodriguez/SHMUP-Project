using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHangarMusicManagerOnLoad : MonoBehaviour
{

	void Start ()
    {
        Destroy(GameObject.Find("HangarMusicController"));
    }
}
