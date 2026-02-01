using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearBehavior : MonoBehaviour
{
    public PlayerMovement player;
    public Transform weaponHolder;
    public Transform playerPos;
    public Rigidbody2D rb;
    public float speed;
    private float travelTime = 3f;
    private bool hasLaunched;
    
    void Awake()
    {
        playerPos = transform.parent;
    }

    void Update()
    {
        if (player.hasthrown)
        {
            StartCoroutine(SpearTravel());
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {

    }*/

    private IEnumerator SpearTravel()
    {
        hasLaunched = true;
        transform.parent = null;
        yield return new WaitForSeconds(travelTime);
        gameObject.SetActive(false);
        rb.linearVelocity = Vector2.zero;
        transform.position = new Vector3(playerPos.position.x + 1, playerPos.position.y, -1);
        gameObject.SetActive(true);
        transform.SetParent(playerPos, true);
        hasLaunched = false;

    }
}
