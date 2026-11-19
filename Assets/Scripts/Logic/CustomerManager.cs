using System;
using UnityEngine;

[RequireComponent(typeof(CustomerMovement))]
public class CustomerManager : MonoBehaviour
{
    private CustomerMovement movement;

    public event Action<CustomerManager> Finished;

    private void Awake()
    {
        movement = GetComponent<CustomerMovement>();
        movement.RouteCompleted += OnRouteCompleted;
    }

    private void OnRouteCompleted()
    {
        Finished?.Invoke(this);
    }

    private void OnDestroy()
    {
        if (movement != null)
        {
            movement.RouteCompleted -= OnRouteCompleted;
        }
    }
}