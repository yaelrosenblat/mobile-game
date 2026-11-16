
using System.Collections.Generic;
using UnityEngine;

public class CustomerPoolingSystem : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private CostumerManager customerPrefab;

    [Header("Pool Settings")]
    [SerializeField, Min(1)] private int poolSize = 5;

    private readonly List<CostumerManager> customers =
        new List<CostumerManager>();

    private void Awake()
    {
        if (customerPrefab == null)
        {
            Debug.LogError(
                "CustomerPoolingSystem: Customer Prefab is missing."
            );

            enabled = false;
            return;
        }

        CreatePool();
    }

    private void CreatePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            CostumerManager customer = Instantiate(
                customerPrefab,
                transform
            );

            customer.gameObject.SetActive(false);

            customers.Add(customer);
        }

        Debug.Log(
            $"<color=cyan>POOL CREATED: {customers.Count} customers</color>"
        );
    }

    public CostumerManager GetCustomer()
    {
        foreach (CostumerManager customer in customers)
        {
            if (!customer.gameObject.activeSelf)
            {
                return customer;
            }
        }

        return null;
    }

    public void ReturnCustomer(CostumerManager customer)
    {
        if (customer == null || !customers.Contains(customer))
        {
            return;
        }

        customer.gameObject.SetActive(false);
    }

    public int PoolSize => customers.Count;
}
