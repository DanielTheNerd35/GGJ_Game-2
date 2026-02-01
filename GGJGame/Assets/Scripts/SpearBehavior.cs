using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearBehavior : MonoBehaviour
{
    public PlayerMovement player;
    public Transform playerPos;
    public Rigidbody2D rb;
    public Camera cam;
    public float speed;
    public int damage;
    private float travelTime = 3f;
    private bool hasLaunched;
    
    void Awake()
    {

    }

    void Start()
    {
        // START AS CHILD
        transform.SetParent(playerPos, false);
    }

    void Update()
    {
        if (player.hasthrown && !hasLaunched)
        {
            StartCoroutine(SpearTravel());
        }
        
        beyondScreen();

    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyLogic enemy = hitInfo.GetComponent<EnemyLogic>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        ReturnPlayer();
    }

    private void beyondScreen()
    {
        Vector3 viewPos = cam.WorldToViewportPoint(this.gameObject.transform.position);

        if (viewPos.x >= 1.1F)
        {
            ReturnPlayer();
        }
    }

    private void ReturnPlayer()
    {
        hasLaunched = false;
        this.transform.SetParent(playerPos, false);
        transform.position = new Vector3(playerPos.position.x + 1, playerPos.position.y, -1);
        rb.linearVelocity = Vector2.zero;
    }

    private IEnumerator SpearTravel()
    {
        hasLaunched = true;
        yield return new WaitForSeconds(travelTime);
    }
}