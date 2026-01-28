using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;



public class Rotator : MonoBehaviour

{

    [SerializeField, Tooltip("Rotation speed in degrees per second (X, Y, Z)")]

    private Vector3 rotationSpeed;

    [SerializeField, Tooltip("Rotation space (Self = local, World = global)")]

    Space rotationSpace = Space.Self;



    void Update()

    {

        transform.Rotate(rotationSpeed * Time.deltaTime, rotationSpace);//< rotation make sure to use time delta >, < space >);

    }

}