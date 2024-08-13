using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class WynnPlayerController : MonoBehaviour
{
    public Image healthBar;
    public static float healthAmount;

    [SerializeField] private float walkSpeed = 5f;

    private WynnMovementController movementController;
    [SerializeField]private WynnAnimationController animationController;

    private float dirH = 0.0f;
    private float dirV = 0.0f;

    private bool move = false;
    private int comboCount;

    public Camera mainCamera; // Reference to the main camera
    public Transform hand;
    public SpriteRenderer gun;

    //Dash
    private bool canDash = true;
    private bool isDashing;
    [SerializeField] private float dashingPower = 24f;
    [SerializeField] private float dashingTime = 0.2f;
    [SerializeField] private float dashingCooldown = 1f;
    [SerializeField] private TrailRenderer tr;
    private Vector2 movement;

       [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject barrelTip;
    [SerializeField] private float ProjectileSpeed;

    private Vector2 facingDirection;

    // Start is called before the first frame update
    void Awake()
    {
        healthAmount = 100;
        movementController = GetComponent<WynnMovementController>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Get the mouse position in screen space
        Vector3 mousePosition = Input.mousePosition;

        // Convert the mouse position to world space
        mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0; // Ensure the z-axis is set to 0 for 2D games

        // Calculate the direction from the object to the mouse
        Vector3 direction = mousePosition - transform.position;

        // Calculate the angle to rotate
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Apply the rotation to the object
        hand.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        if (mousePosition.x < hand.transform.position.x)
        {
            gun.flipY = true;
            animationController.FlipSprite(true);
        }
        else
        {
            gun.flipY = false;
            animationController.FlipSprite(false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            GameObject spawnProjectile = Instantiate(projectile, barrelTip.transform.position, hand.transform.rotation);
            Rigidbody2D projectileRigidBody = spawnProjectile.GetComponent<Rigidbody2D>();

            if (projectileRigidBody != null)
            {
                projectileRigidBody.AddForce(direction.normalized * ProjectileSpeed, ForceMode2D.Impulse);
            }
        }

        if (isDashing)
        {
            return;
        }

        dirH = Input.GetAxis("Horizontal");
        dirV = Input.GetAxis("Vertical");
        move = Mathf.Abs(dirH) > 0f || Mathf.Abs(dirV) > 0f;

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
    }
    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        if (move)
        {
            movementController.Move(dirH, dirV, walkSpeed);
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;

        // Normalize the input direction to handle 8-directional dashing
        Vector2 dashDirection = new Vector2(dirH, dirV).normalized;

        // Calculate the dash target position
        Vector2 startPosition = movementController.rb.position;
        Vector2 dashTarget = startPosition + dashDirection * dashingPower;

        // Enable trail effect during dash
        tr.emitting = true;

        float elapsedTime = 0f;

        // Smoothly move the Rigidbody towards the target position
        while (elapsedTime < dashingTime)
        {
            elapsedTime += Time.fixedDeltaTime;
            Vector2 newPosition = Vector2.Lerp(startPosition, dashTarget, elapsedTime / dashingTime);
            movementController.rb.MovePosition(newPosition);
            yield return new WaitForFixedUpdate(); // Wait until the next FixedUpdate frame
        }

        // Disable trail effect after dash
        tr.emitting = false;

        // Reset the velocity to stop any unintended movement after dashing
        movementController.rb.velocity = Vector2.zero;

        isDashing = false;

        // Wait for the cooldown period before allowing another dash
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    public void TakeDamage(int damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100;

        if (healthAmount <= 0)
        {
            Die();
        }
    }

    private void Die()
    {

    }
}
