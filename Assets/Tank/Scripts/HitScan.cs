using UnityEngine;

public class HitScan : Ammo
{
    [SerializeField] float distance;
    [SerializeField] LayerMask layerMask = Physics.AllLayers;
    [SerializeField] GameObject hitEffect;
    void Start()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit raycastHit, distance, layerMask))
        {
            // check if hit object has health component
            Health health = raycastHit.collider.gameObject.GetComponent<Health>();
            if (health != null)
            {
                // deal damage to hit object
                health.onDamage(damage);
            }
            if (hitEffect != null)
            {
                Instantiate(hitEffect, raycastHit.point, Quaternion.identity);
            }
        }
        Destroy(gameObject);
    }
}