
using System.Collections;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    [Header("Day Settings")]
    [SerializeField] private float dayDuration = 20f;
    public GameObject endOfDayPanel;

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
    }
}
