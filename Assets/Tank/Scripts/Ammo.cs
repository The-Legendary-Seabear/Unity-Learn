using UnityEngine;

public abstract class Ammo : MonoBehaviour
{
    [SerializeField, Range(0.1f, 10.0f)] protected float damage = 1;
}
