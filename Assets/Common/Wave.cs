using UnityEngine;



public class Wave : MonoBehaviour

{

    [SerializeField, Range(0, 5), Tooltip("Wave frequency (speed of oscillation)")]

    float frequency = 1;

    [SerializeField, Range(0, 5), Tooltip("Wave amplitude (distance traveled)")]

    float amplitude = 1;

    [SerializeField, Tooltip("Direction of wave movement")]

    Vector3 waveDirection = Vector3.up;



    [SerializeField, Range(0, 100), Tooltip("Random phase offset range")]

    float randomStart = 0;



    Vector3 position;

    float phase = 0;



    void Start()

    {

        // store starting postion, wave will be about this position 

        position = gameObject.transform.position;//< game object transform position >;

        // Random.value returns a random value between 0.0-1.0 

        // the random value is multiplied by randomStart to set starting phase value 

        phase = Random.value * randomStart; //< multiply random value *random start >;

    }





    void Update()

    {

        // update the phase using frequency (speed of phase) * delta time 

        phase += (frequency * Time.deltaTime);

        // set current position to start postion + normalize wave direction scaled by sine wave * amplitude 

        transform.position = position + waveDirection.normalized * Mathf.Sin(phase) * amplitude;

    }

}