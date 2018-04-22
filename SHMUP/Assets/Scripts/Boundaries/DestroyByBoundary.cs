using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
    //As soon as an object leaves the boundary it is removed from the scene.
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("EnemyBullet")|| other.gameObject.CompareTag("Player"))
        {
            return;
        }
        Destroy(other.gameObject);
    }
}
