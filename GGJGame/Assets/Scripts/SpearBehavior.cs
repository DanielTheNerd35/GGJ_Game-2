using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearBehavior : MonoBehaviour
{
    public PlayerMovement player;
    public Transform playerPos;
    public Rigidbody2D rb;
    public float speed;
    private float travelTime = 3f;
    private bool hasLaunched;
    

    void Update()
    {
        if (player.hasthrown)
        {
            transform.parent = null;
            StartCoroutine(SpearTravel());
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {

    }*/

    private IEnumerator SpearTravel()
    {
        hasLaunched = true;
        yield return new WaitForSeconds(travelTime);
        gameObject.SetActive(false);
        rb.linearVelocity = Vector2.zero;
        transform.position = new Vector3(playerPos.position.x + 1, playerPos.position.y, -1);
        gameObject.SetActive(true);
        transform.SetParent(playerPos.transform);
        hasLaunched = false;

    }
}
