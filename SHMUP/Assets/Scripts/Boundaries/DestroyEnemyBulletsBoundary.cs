using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemyBulletsBoundary : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Stores scripts and components from bullets.
        ForwardMover otherThingsMover;
        EnemyHoming otherThingsHoming;
        Rigidbody otherRB;

        
        if (other.CompareTag("EnemyBullet"))
        {
            //Grabs said scripts and components.
            otherRB = other.GetComponent<Rigidbody>();
            otherThingsMover = other.GetComponent<ForwardMover>();
            otherThingsHoming = other.GetComponent<EnemyHoming>();

            //Disables the homing and forward mover scripts so things don't decide to move again.
            //Also prevents it from throwing a hissifit over not finding a component.
            if(otherThingsMover != null)
            {
                otherThingsMover.enabled = false;
            }
            else if (otherThingsHoming != null)
            {
                otherThingsHoming.enabled = false;
            }
            
            //Stops the bullets from moving.
            otherRB.velocity = new Vector3(0, 0, 0);
            //Destroys the bullets after 2 seconds so they can finish playing their sounds.
            Destroy(other.gameObject, 2);
        }
        else if(other.CompareTag("LightEnemy") || other.CompareTag("MediumEnemy"))
        {
            Destroy(other.gameObject);
        }
    }
}
