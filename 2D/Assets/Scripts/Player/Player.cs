using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int maxHealth = 2;
    public float movementSpeed;
    public float maxVelocity = 5.0f;
    public float decelRate = 0.1f;
    public float aimOffset = 45.0f;
    public float fireRate = 1.0f;
    public float bulletSpeed = 1.0f;
    public GameObject bulletPrefab;
    public GameObject bulletSpawn;
    public float altFireWait = 1.0f;
    public float altBulletSpeed = 5.0f;
    public GameObject altBulletPrefab;
    public GameObject altFireVisual;
    public GameObject healthBox;

    private Rigidbody2D rb;
    private Vector2 movementDir;
    private bool mouseIdle;
    private Vector3 lastMousePos;
    private float fireTime = 0.0f;
    private float altFireCharge = 0.0f;
    private SpriteRenderer altFireVisualSp;
    private int health;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;

        altFireVisualSp = altFireVisual.GetComponent<SpriteRenderer>();
        altFireVisualSp.enabled = false;

        decelRate += 1.0f;

        health = maxHealth;
        healthBox.SendMessage("SetHealth", health);
    }

    private void FixedUpdate()
    {
        movePlayer();
        ClampLinearVelocity();
    }

    private void movePlayer()
    {
        Vector2 move = movementDir * movementSpeed * Time.fixedDeltaTime;
        rb.AddForce(move, ForceMode2D.Impulse);
    }

    void Update()
    {
        movementDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (Input.GetAxis("Vertical") <= 0.01f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / decelRate);
        }

        if (Input.GetAxis("Horizontal") <= 0.01f)
        {
            rb.velocity = new Vector2(rb.velocity.x / decelRate, rb.velocity.y);
        }

        if (fireTime < fireRate)
        {
            fireTime += Time.deltaTime;
        }

        if (!(Input.GetMouseButton(1) || Input.GetKey(KeyCode.JoystickButton4)) && (Input.GetMouseButton(0) || Input.GetKey(KeyCode.JoystickButton5)) && fireTime >= fireRate)
        {
            GameObject obj = GameObject.Instantiate(bulletPrefab, bulletSpawn.transform.position, 
                Quaternion.Euler(new Vector3(0.0f, 0.0f, rb.rotation - aimOffset)));

            Rigidbody2D objRb = obj.GetComponent<Rigidbody2D>();
            objRb.AddForce((transform.up + transform.right) * bulletSpeed, ForceMode2D.Impulse);

            fireTime = 0.0f;
        }

        if (!(Input.GetMouseButton(0) || Input.GetKey(KeyCode.JoystickButton5)) && Input.GetMouseButton(1) || Input.GetKey(KeyCode.JoystickButton4))
        {
            if(altFireCharge < altFireWait)
            {
                altFireCharge += Time.deltaTime;
                altFireVisualSp.enabled = true;
            }
            else
            {
                altFireVisualSp.color = Color.red;
            }
        }
        else
        {
            if(altFireCharge >= altFireWait)
            {
                altFire();
            }
            
            altFireVisualSp.enabled = false;
            altFireVisualSp.color = Color.white;

            altFireCharge = 0.0f;
        }
        
        if (Input.mousePosition == lastMousePos)
        {
            mouseIdle = true;
        }
        else
        {
            mouseIdle = false;
        }
        lastMousePos = Input.mousePosition;

        Aim();
    }

    private void ClampLinearVelocity()
    {
        if (rb.velocity.x > maxVelocity)
        {
            rb.velocity = new Vector2(maxVelocity, rb.velocity.y);
        }

        if (rb.velocity.y > maxVelocity)
        {
            rb.velocity = new Vector2(rb.velocity.x, maxVelocity);
        }

        if (rb.velocity.x < -maxVelocity)
        {
            rb.velocity = new Vector2(-maxVelocity, rb.velocity.y);
        }

        if (rb.velocity.y < -maxVelocity)
        {
            rb.velocity = new Vector2(rb.velocity.x, -maxVelocity);
        }
    }

    private void Aim()
    {
        if (!mouseIdle)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 5.23f;

            Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
            mousePos.x = mousePos.x - objectPos.x;
            mousePos.y = mousePos.y - objectPos.y;

            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, angle - aimOffset));
        }
        else if (Mathf.Abs(Input.GetAxis("Horizontal2")) > 0.1f && Mathf.Abs(Input.GetAxis("Vertical2")) > 0.1f)
        {
            float targetRot = Mathf.Atan2(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2")) * Mathf.Rad2Deg;

            Quaternion rot = Quaternion.Slerp(Quaternion.Euler(0.0f, 0.0f, targetRot - 135.0f), 
                transform.rotation, 1.0f * Time.deltaTime);

            transform.rotation = rot;
        } else
        {
            return;
        }
        rb.angularVelocity = 0.0f;
    }

    void altFire()
    {
        GameObject obj = GameObject.Instantiate(altBulletPrefab, bulletSpawn.transform.position,
                Quaternion.Euler(new Vector3(0.0f, 0.0f, rb.rotation - aimOffset)));

        Rigidbody2D objRb = obj.GetComponent<Rigidbody2D>();
        objRb.AddForce((transform.up + transform.right) * altBulletSpeed, ForceMode2D.Impulse);
    }

    void ApplyDamage(float damage)
    {
        if (damage > 0)
        {
            health--;
            healthBox.SendMessage("SetHealth", health);

            if (health <= 0)
            {
                death();
            }
        }
    }

    void death()
    {
        SceneManager.LoadScene("TitleScene");
    }
}