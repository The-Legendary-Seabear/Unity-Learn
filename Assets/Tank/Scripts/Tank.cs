using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Tank : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    [SerializeField] float rotationSpeed = 90.0f; // rotation in degrees per second

    [SerializeField] GameObject ammo;
    [SerializeField] GameObject muzzle;

    [SerializeField] Slider healthBar;

    InputAction moveAction;
    InputAction attackAction;

    Health health;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        attackAction = InputSystem.actions.FindAction("Attack");

        attackAction.started += ctx => OnAttack();

        health = GetComponent<Health>();

        if (health == null)
            Debug.LogError("Health component missing!");
        if (healthBar == null)
            Debug.LogError("HealthBar is not assigned!");
    }

    void Update()
    {
        // direction (forward/backward movement)
        float direction = moveAction.ReadValue<Vector2>().y;
        //if (Keyboard.current.wKey.isPressed) direction = +1.0f;
        //if (Keyboard.current.sKey.isPressed) direction = -1.0f;

        // translate (move) the tank in the forward direction
        // moves the tank in the relative direction (direction tank is facing)
        transform.Translate(Vector3.forward * direction * speed * Time.deltaTime);

        // rotation (left/right)
        float rotation = moveAction.ReadValue<Vector2>().x;

        // rotate the tank, around the up axis (y-axis)
        transform.Rotate(Vector3.up * rotation * rotationSpeed * Time.deltaTime);

        // check if "Fire" key is pressed, if so instantiate the ammo (rocket)
        // ammo is instantiate at the muzzle position and rotation
        //if (attackAction.WasPressedThisFrame())
        //{
        // Instantiate(ammo, muzzle.transform.position, muzzle.transform.rotation);
        //}

        healthBar.value = health.CurrentHealthPercent;
    }

    void OnAttack()
    {
        Instantiate(ammo, muzzle.transform.position, muzzle.transform.rotation);
    }
}
