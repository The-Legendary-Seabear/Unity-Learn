using UnityEngine;
using UnityEngine.Events;

public class RaycastPerception : MonoBehaviour
{
    [SerializeField] Transform source;
    [SerializeField] float distance;

    [SerializeField] string tagName;
    [SerializeField] LayerMask layerMask = Physics.AllLayers;
    [SerializeField] UnityEvent perceivedGameObject;

    Ray ray = new Ray();

    void Start()
    {
        // if source not set, use game object transform
        source = source ?? transform;
    }

    void Update()
    {
        ray.origin = source.position;
        ray.direction = source.forward;

        Debug.DrawRay(ray.origin, ray.direction * distance, Color.yellow);

        // check for raycast hit
        if (Physics.Raycast(ray, out RaycastHit raycastHit, distance, layerMask))
        {
            if (tagName == "" || raycastHit.collider.CompareTag(tagName))
            {
                // send event, pass hit game object
                perceivedGameObject?.Invoke();
                Debug.DrawRay(ray.origin, ray.direction * raycastHit.distance, Color.red);
            }
        }
    }
}
