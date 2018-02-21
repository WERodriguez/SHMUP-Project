using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSize;

    public GameObject nextTile;

    public Vector3 endPosition = new Vector3(0, 0, -85);
    public Vector3 spawnNextTilePosition = new Vector3(0, 0, -17);
    private Vector3 startPosition;
    public Transform nextTileSpawn;

    private bool didISpawnNextTile;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        float translation = Time.deltaTime * scrollSpeed;

        if (transform.position.z <= spawnNextTilePosition.z && !didISpawnNextTile)
        {
            Instantiate(nextTile, nextTileSpawn.position, nextTileSpawn.rotation);
            didISpawnNextTile = true;
        }
        else if (transform.position.z <= endPosition.z)
        {
            Destroy(gameObject);
        }
        else
        {
            //transform.Translate(0, 0, Time.deltaTime * translation);
            transform.Translate(Vector3.forward * translation);
        }
	}
}
