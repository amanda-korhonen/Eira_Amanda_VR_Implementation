using UnityEngine;
using TMPro;

public class TaskCompletionUI : MonoBehaviour
{
    [SerializeField] private TMP_Text bedDoneText;
    [SerializeField] private TMP_Text potatoDoneText;

    private void OnEnable()
    {
        if (TaskProgress.Instance != null)
        {
            TaskProgress.Instance.OnTaskCompleted += RefreshUI;
            RefreshUI();
        }
    }

    private void OnDisable()
    {
        if (TaskProgress.Instance != null)
        {
            TaskProgress.Instance.OnTaskCompleted -= RefreshUI;
        }
    }

    private void RefreshUI()
    {
        bedDoneText.gameObject.SetActive(TaskProgress.Instance.bedTaskCompleted);
        potatoDoneText.gameObject.SetActive(TaskProgress.Instance.potatoTaskCompleted);
    }
}