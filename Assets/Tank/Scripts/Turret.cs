using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 45.0f;
    [SerializeField] float fireRate = 1.0f;
    [SerializeField] Ammo ammo;
    [SerializeField] Transform muzzle;

    float fireTimer = 0;
    void Start()
    {
        fireTimer = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer -= Time.deltaTime;
        if(fireTimer <= 0)
        {
            fireTimer += fireRate;
            Instantiate(ammo, muzzle.position, muzzle.rotation);
        }

        //transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        Transform player = playerObj.transform;

        Vector3 direction = player.position - transform.position;
        direction.y = 0f;

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );
    }
}
