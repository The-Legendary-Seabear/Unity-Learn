using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Ammo ammo;
    [SerializeField] Transform muzzle;

    [SerializeField] float fireRate = 1.0f;
    [SerializeField] int maxAmmoCount = 200;

    private int ammoCount;
    public int AmmoCount
    {
        get { return ammoCount; }
        set { ammoCount = Mathf.Clamp(value, 0, maxAmmoCount); }
    }

    public bool IsReadyToFire { get; set; } = true;

    void Start()
    {
        AmmoCount = maxAmmoCount;
    }

    public void OnFire()
    {
        if (IsReadyToFire && AmmoCount > 0)
        {
            AmmoCount--;
            Instantiate(ammo, muzzle.position, muzzle.rotation);
            IsReadyToFire = false;
            StartCoroutine(ResetFireCR());
        }
    }

    IEnumerator ResetFireCR()
    {
        yield return new WaitForSeconds(fireRate);
        IsReadyToFire = true;
    }
}
