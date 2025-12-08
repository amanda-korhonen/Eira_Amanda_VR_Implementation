using UnityEngine;
using TMPro;

public class TaskCompletionUI : MonoBehaviour
{
    [SerializeField] private TMP_Text doneText;

    private void Start()
    {
        // hide text at the start
        doneText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (TaskProgress.Instance != null)
        {
            if (TaskProgress.Instance.bedTaskCompleted &&
                TaskProgress.Instance.potatoTaskCompleted)
            {
                doneText.gameObject.SetActive(true);
            }
        }
    }
}