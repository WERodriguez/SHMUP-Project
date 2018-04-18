using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KerberosStage2 : MonoBehaviour
{
    //Speed at which boss lerps between objects.
    public float speed;
    //Speed at which boss rotates.
    public float spinSpeed;
    //Time before moves again.
    public float timeToMoveAgain;
    //Array of positions to move between.
    public Vector3[] positions;
    //Where the boss goes when HP is 0 or less;
    public Vector3 deathPosition;
    //Currently selected position.
    private Vector3 desiredPosition;
    private Vector3 currentPositionHeight;

    //How long the boss takes before the boss starts moving.
    public float startDelay;

    //Contains all child object renderers for manipulation.
    public Component[] childRenderers;
    //Does not include the turrets.
    public Component[] shipHullRenderers;
    //Controls the ship collider.
    private CapsuleCollider shipCollider;

    //Lets the ship know it can move
    public bool canIMove;
    //Because otherwise explosions go off literally every frame. It's hilarious but wrong.
    public bool stopDying;

    //Keeps track of all the guns so the boss knows when to die.
    public GameObject[] gunArray;
    //Holds next boss stage
    public GameObject nextStage;

    public float appearDuration;

    //Holds explosions to play during an overly dramatic instance switch.
    public GameObject[] explosions;
    //What it says.
    public float timeBetweenExplosions;
    //Ranges that explosions can spawn at during overly dramatic switch. 
    //Used with Random.Range(minimum Float, max Float)
    public float xRange;
    public float yRange;
    public float zRange;

    // Use this for initialization
    void Start ()
    {
        currentPositionHeight = gameObject.transform.position;
        for(int i = 0; i < positions.Length; i++)
        {
            positions[i].y = currentPositionHeight.y;
        }
        canIMove = false;
        //Gathers all of the child renderers
        childRenderers = GetComponentsInChildren<Renderer>();
        desiredPosition = gameObject.transform.position;
        StartCoroutine(BossAppears());

        Invoke("BossMovement", appearDuration);
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if every single gun in the array is destroyed before starting the death coroutine.
        if (gunArray[0] == null && gunArray[1] == null && gunArray[2] == null && gunArray[3] == null && gunArray[4] == null && gunArray[5] == null && gunArray[6] == null && gunArray[7] == null && !stopDying)
        {
            stopDying = true;
            StartCoroutine(DeadStage());
        }
    }

    void FixedUpdate ()
    {
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * speed);

        transform.position = smoothedPosition;
        if(canIMove)
        {
            transform.Rotate(0, Time.deltaTime * spinSpeed, 0);
        }
    }

    IEnumerator BossAppears()
    {
        yield return new WaitForSeconds(appearDuration);
        foreach (Renderer childObjectColor in childRenderers)
        {
            //SetFloat Changes the material shader.
            //("_Mode", float) I haven't figured out why the first part is needed yet but it is Second part sets the mode.
            // 0 = Opaque, 1 = Cutout, 2 = Fade, 3 = Transparent
            childObjectColor.material.SetFloat("_Mode", 0);
            childObjectColor.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
            childObjectColor.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
            childObjectColor.material.SetInt("_ZWrite", 1);
            childObjectColor.material.DisableKeyword("_ALPHATEST_ON");
            childObjectColor.material.DisableKeyword("_ALPHABLEND_ON");
            childObjectColor.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            childObjectColor.material.renderQueue = -1;
        }

        yield return new WaitForSeconds(startDelay);
        StartCoroutine(BossMovement());
    }

    IEnumerator DeadStage()
    {
        canIMove = false;
        speed = 0.5f;
        StartCoroutine(dramaticExplosions());
        desiredPosition = deathPosition;
        yield return new WaitForSeconds(3);

        yield return new WaitForSeconds(appearDuration);
        Instantiate(nextStage, gameObject.transform.position, Quaternion.Euler(0,180,0));
        Destroy(gameObject);
    }

    IEnumerator BossMovement()
    {
        canIMove = true;
        while(canIMove)
        {
            desiredPosition = positions[Random.Range(0, positions.Length)];

            yield return new WaitForSeconds(Random.Range(1.0f, timeToMoveAgain));
        }
    }

    IEnumerator dramaticExplosions()
    {
        while (true)
        {
            //Instantiates explosions from an array that holds 3 explosions.
            //X and Z coordinates of explosions are random. Y and rotation are static.            
            Instantiate(explosions[Random.Range(0, 3)], new Vector3(gameObject.transform.position.x + Random.Range(-xRange, xRange),
                gameObject.transform.position.y + Random.Range(-yRange, yRange),
                gameObject.transform.position.z + Random.Range(-zRange, zRange)), gameObject.transform.rotation);

            yield return new WaitForSeconds(timeBetweenExplosions);
        }
    }
}
