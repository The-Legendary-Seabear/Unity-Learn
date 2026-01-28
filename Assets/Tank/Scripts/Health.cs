using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth = 10;
    [SerializeField] GameObject hitEffect;
    [SerializeField] GameObject destroyEffect;
    [SerializeField] UnityEvent destroyEvent;

    public float CurrentHealth {
        get { return health; }
        set { health = Mathf.Clamp(value, 0, maxHealth); }
    }

    public float CurrentHealthPercent
    {
        get { return CurrentHealth / maxHealth; }
    }

    float health = 0;
    bool destroyed = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentHealth = maxHealth;
    }

    public void onDamage(float damage)
    {
        Debug.Log("Damaged");
        if (destroyed) return;

        CurrentHealth -= damage;
        if (CurrentHealth <= 0) destroyed = true;

        if(!destroyed && hitEffect != null)
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity);
        }

        if(destroyed)
        {
            TankGameManager.Instance.Score += 100;
            if(destroyEffect != null)
            {
                Instantiate(destroyEffect, transform.position, Quaternion.identity);
            }
            destroyEvent?.Invoke();

            Destroy(gameObject);
        }
    }

    public void onHeal(float amount)
    {
        CurrentHealth += amount;
    }
}
