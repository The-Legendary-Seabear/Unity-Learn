using UnityEngine;
using UnityEngine.Events;


public class Trigger : MonoBehaviour
{
    [SerializeField] UnityEvent triggerEvent;
    [SerializeField, Tooltip("Tag of object to trigger.")] string tagName;
    private void OnTriggerEnter(Collider other)
    {
        if (tagName == "" || other.CompareTag(tagName))
        {
            triggerEvent.Invoke();
        }
    }
}
