using UnityEngine;
using UnityEngine.UI;
public class PlayerMove : MonoBehaviour
{
    public static float speed = 15f;
    public float currentSpeed;
    public float brake;
    public float friction;
    public float CamDelay;
    private Rigidbody2D rb;
    public Camera cam;
    public Transform target;
    private Vector2 movement;
    private Vector2 mouse;
    public Vector3 CamOffset;
    private Vector3 velocity = Vector3.zero;

    public Slider Left, Right;

    public float dashSpeed;
    public float dashLength;
    public float dashCooldown;
    public float dashCounter, dashCoolCounter;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = 0f;
    }

    void Update()
    {
        dashSpeed = speed * 2;
        Left.maxValue = dashCooldown;
        Left.value = dashCooldown - dashCoolCounter;
        Right.maxValue = dashCooldown;
        Right.value = dashCooldown - dashCoolCounter;
        Vector3 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos.z = 0;
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, currentSpeed * Time.deltaTime);
            if (currentSpeed > speed)
            {
                currentSpeed = speed;
            }
            else
            {
                currentSpeed += speed * Time.deltaTime;
            }
        }
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, currentSpeed * Time.deltaTime);
            if(currentSpeed < 0)
            {
                currentSpeed = 0;
            }
            else
            {
                currentSpeed -= friction * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, currentSpeed * Time.deltaTime);
            if (currentSpeed < 0)
            {
                currentSpeed = 0;
            }
            else
            {
                currentSpeed -= brake * Time.deltaTime;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(dashCoolCounter <= 0 && dashCounter <= 0)
            {
                currentSpeed = dashSpeed;
                dashCounter = dashLength;
            }
        }
        if(dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if(dashCounter <= 0)
            {
                currentSpeed = speed;
                dashCoolCounter = dashCooldown;               
            }
        }
        if(dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }

        mouse = cam.ScreenToWorldPoint(Input.mousePosition);
        moveCharacter(movement);
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        Vector2 look = mouse - rb.position;
        float angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
    private void LateUpdate()
    {
        Vector3 movePosition = target.position + CamOffset;
        cam.transform.position = Vector3.SmoothDamp(cam.transform.position, movePosition, ref velocity, CamDelay);
    }
    private void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }
}