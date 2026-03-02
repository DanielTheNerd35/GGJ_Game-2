using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public float FollowSpeed = 1f;

    [Header("Camera Bounds")]
    [SerializeField] private Vector2 minBounds;
    [SerializeField] private Vector2 maxBounds;

    private Transform target;
    private Camera cam;

    private float camHalfHeight;
    private float camHalfWidth;

     private void Awake()
    {
        cam = Camera.main;

        camHalfHeight = cam.orthographicSize;
        camHalfWidth = camHalfHeight * cam.aspect;
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y, -5f);

        float clampedX = Mathf.Clamp(newPos.x, minBounds.x + camHalfWidth, maxBounds.x - camHalfWidth);
        float clampedY = Mathf.Clamp(newPos.y,  minBounds.y + camHalfHeight, maxBounds.y - camHalfHeight);

         Vector3 clampedPosition = new Vector3(clampedX, clampedY, -5f);
        
        transform.position = Vector3.Lerp(transform.position, clampedPosition, FollowSpeed * Time.deltaTime);
    }

    private void OnEnable()
    {
        GameManager.OnPlayerSpawned += SetTarget;
    }

    private void OnDisable()
    {
        GameManager.OnPlayerSpawned -= SetTarget;
    }

    private void SetTarget(GameObject player)
    {
        target = player.transform;
    }
}
