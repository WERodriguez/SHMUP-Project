using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDropRoller : MonoBehaviour
{
    //Array of loot items. Can hold up to five!
    public GameObject[] loot = new GameObject[5];

    private Transform parentTransform;

    private void Start()
    {
        //Grabs the parent transform. In case you forgot.
        parentTransform = gameObject.GetComponent<Transform>();
    }

    public void LootRoll(float roll)
    {
        //Chances of what loot will drop from highest to lowest!
        if(roll <= 50)
        {
            if(loot[0] == null)
            {
                return;
            }
            Instantiate(loot[0], parentTransform.position, parentTransform.rotation);
        }
        else if(roll> 50 && roll <= 65)
        {
            if (loot[1] == null)
            {
                return;
            }
            Instantiate(loot[1], parentTransform.position, parentTransform.rotation);
        }
        else if(roll > 65 && roll <= 80)
        {
            if (loot[2] == null)
            {
                return;
            }
            Instantiate(loot[2], parentTransform.position, parentTransform.rotation);
        }
        else if(roll > 80 && roll <= 95)
        {
            if (loot[3] == null)
            {
                return;
            }
            Instantiate(loot[3], parentTransform.position, parentTransform.rotation);
        }
        else if(roll > 95)
        {
            if (loot[4] == null)
            {
                return;
            }
            Instantiate(loot[4], parentTransform.position, parentTransform.rotation);
        }

    }
}
