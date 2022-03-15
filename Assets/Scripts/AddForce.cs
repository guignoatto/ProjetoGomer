using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    [SerializeField] private CharacterAttributes charAttributes;
    [SerializeField] private Transform firstClickTransform;
    [SerializeField] private Transform mouseUpTransform;

    private PhysicsMaterial2D physicsMaterial;
    private Rigidbody2D rbd;
    private void Start()
    {
        physicsMaterial = GetComponent<PhysicsMaterial2D>();
        rbd = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstClickTransform.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButtonUp(0))
        {
            mouseUpTransform.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 direction = CalculateDirection(firstClickTransform.transform.position, mouseUpTransform.transform.position);
            rbd.AddForce(direction * charAttributes.PullForce);
            Debug.Log(direction);
        }
    }

    private Vector2 CalculateDirection(Vector3 pointA, Vector3 pointB)
    {
        Vector2 direction = pointA - pointB;
        if (Mathf.Abs(direction.y) > 5)
        {
            direction.y = Mathf.Sign(direction.y) * 5;
        }
        if (Mathf.Abs(direction.x) > 3)
        {
            direction.x = Mathf.Sign(direction.x) * 3;
        }
        return direction;
    }
}


