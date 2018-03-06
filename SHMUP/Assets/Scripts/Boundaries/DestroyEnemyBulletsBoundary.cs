using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemyBulletsBoundary : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            Destroy(other.gameObject);
        }
    }
}
