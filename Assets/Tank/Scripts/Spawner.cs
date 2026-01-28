using UnityEngine;
using UnityEngine.InputSystem;

public class Spawner : MonoBehaviour
{
    [SerializeField] float time = 1.0f;
    [SerializeField] GameObject spawnObject;

    private void Awake()
    {
        
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Vector3 position = transform.position;
            position.x += Random.Range(-5.0f, 5.0f);
            position.z += Random.Range(-5.0f, 5.0f);

            var go = Instantiate(spawnObject, transform.position, transform.rotation);
            Destroy(go, 4);
        }
        
    }
}
