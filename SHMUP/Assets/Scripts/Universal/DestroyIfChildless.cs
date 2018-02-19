using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIfChildless : MonoBehaviour
{
	// Update is called once per frame
	void LateUpdate ()
    {
		if(transform.childCount <= 0)
        {
            Destroy(gameObject);
        }
	}
}
