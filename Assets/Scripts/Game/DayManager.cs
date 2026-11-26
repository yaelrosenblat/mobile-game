
using System.Collections;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    [Header("Day Settings")]
    [SerializeField] private float dayDuration = 20f;
    public GameObject endOfDayPanel;
    private CustomerMovement customerMovement;
    private CustomerSpawner customerSpawner;

    public bool dayEnded;

    private void Start()
    {
        endOfDayPanel.SetActive(false);
        StartCoroutine(StartDay());
    }

    private IEnumerator StartDay()
    {
        yield return new WaitForSeconds(dayDuration);

        EndDay();
    }

    private void EndDay()
    {
        if (dayEnded) return;

        dayEnded = true;
        endOfDayPanel.SetActive(true);
        customerMovement = FindAnyObjectByType<CustomerMovement>();
        customerSpawner = FindAnyObjectByType<CustomerSpawner>();
        customerMovement.StopMovement();
        customerSpawner.StopCurrentSequence();

    }
}
