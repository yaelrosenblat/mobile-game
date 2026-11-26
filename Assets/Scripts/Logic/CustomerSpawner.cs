
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public enum TestRoute
    {
        Successful,
        Failed
    }

    [Header("References")]
    [SerializeField] private CustomerPoolingSystem poolingSystem;
    [SerializeField] private LevelManager levelManager;

    [Header("Routes - Temporary Testing")]
    [SerializeField] private TestRoute testRoute;
    [SerializeField] private RectTransform[] successfulRoute;
    [SerializeField] private RectTransform[] failedRoute;

    [SerializeField, Min(0f)]
    private float failedRouteWait = 3f;

    // [Header("Spawn Settings")]
    // [SerializeField, Min(0.1f)]
    // private float initialSpawnDelay = 2f;

    // [SerializeField, Min(0f)]
    // private float spawnDelayDecrease = 0.5f;

    // [SerializeField, Min(0.1f)]
    // private float minimumSpawnDelay = 0.5f;

    private float currentSpawnDelay;
    private Coroutine spawnCoroutine;

    private readonly HashSet<CustomerManager> activeCustomers =
        new HashSet<CustomerManager>();

    private void Start()
    {
        StartCustomerSequence();
    }

    public void StartCustomerSequence()
    {
        if (poolingSystem == null || levelManager == null)
        {
            Debug.LogError(
                "CustomerSpawner: Missing references."
            );
            return;
        }

        RectTransform[] route = GetSelectedRoute();

        if (!IsValidRoute(route))
        {
            Debug.LogError(
                "CustomerSpawner: Route is not configured."
            );
            return;
        }

        StopCurrentSequence();

        //levelManager.OnLevelChanged += UpdateSpawnDelay;
        

        UpdateSpawnDelay(levelManager.CurrentLevel);

        spawnCoroutine = StartCoroutine(SpawnSequence());
    }

    private RectTransform[] GetSelectedRoute()
    {
        return testRoute == TestRoute.Successful
            ? successfulRoute
            : failedRoute;
    }

    private bool IsValidRoute(RectTransform[] route)
    {
        if (route == null || route.Length < 2)
            return false;

        foreach (RectTransform point in route)
        {
            if (point == null)
                return false;
        }

        return true;
    }

    private void UpdateSpawnDelay(int level)
    {
        // currentSpawnDelay = Mathf.Max(
        //     minimumSpawnDelay,
        //     initialSpawnDelay -
        //     (level - 1) * spawnDelayDecrease
        // );

        currentSpawnDelay = 0.5f;

        Debug.Log(
            $"<color=cyan>LEVEL {level} | " +
            $"SPAWN DELAY: {currentSpawnDelay:F2}s</color>"
        );
    }

    private IEnumerator SpawnSequence()
    {
        while (true)
        {
            CustomerManager customer = poolingSystem.GetCustomer();

            if (customer == null)
            {
                yield return null;
                continue;
            }

            CustomerMovement movement =
                customer.GetComponent<CustomerMovement>();

            if (movement == null)
            {
                Debug.LogError(
                    "CustomerSpawner: CustomerMovement missing."
                );
                yield break;
            }

            customer.Finished += OnCustomerFinished;
            activeCustomers.Add(customer);

            customer.gameObject.SetActive(true);

            RectTransform[] route = GetSelectedRoute();

            int pausePoint =
                testRoute == TestRoute.Failed ? 2 : -1;

            movement.StartRoute(
                route,
                pausePoint,
                failedRouteWait
            );

            /*Debug.Log(
                "<color=cyan>CUSTOMER ACTIVATED</color>"
            );*/

            yield return new WaitForSeconds(currentSpawnDelay);
        }
    }

    private void OnCustomerFinished(CustomerManager customer)
    {
        if (!activeCustomers.Remove(customer))
            return;

        customer.Finished -= OnCustomerFinished;
        poolingSystem.ReturnCustomer(customer);

        /*Debug.Log(
            "<color=yellow>CUSTOMER RETURNED TO POOL</color>"
        );*/
    }

    public void StopCurrentSequence()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
            spawnCoroutine = null;
        }

        if (levelManager != null)
        {
            levelManager.OnLevelChanged -= UpdateSpawnDelay;
        }

        foreach (CustomerManager customer in activeCustomers)
        {
            if (customer == null)
                continue;

            customer.Finished -= OnCustomerFinished;
            poolingSystem.ReturnCustomer(customer);
        }

        activeCustomers.Clear();
    }

    private void OnDisable()
    {
        StopCurrentSequence();
    }
}
