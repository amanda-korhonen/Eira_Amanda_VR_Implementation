using System.Diagnostics.CodeAnalysis;
using TMPro;
using UnityEngine;

public class TaskProgress : MonoBehaviour
{
    public static TaskProgress Instance;

    //use this to see if both tasks are completed
    public bool bedTaskCompleted = false;
    public bool potatoTaskCompleted = false;

    //[SerializeField] private TMP_Text done;
    //[SerializeField] private TMP_Text donePotato;
    //[SerializeField] private TMP_Text doneBed;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    /*
    //set done texts to false / hide them at the start of the game 
    private void Start()
    {
        done.gameObject.SetActive(false);
        //donePotato.gameObject.SetActive(false);
        //doneBed.gameObject.SetActive(false);
    }

    public void Update()
    {
        if (bedTaskCompleted && potatoTaskCompleted)
        {
            done.gameObject.SetActive(true);
        }
    }*/

    /*
    public void CompletePotatoTask()
    {
        potatoTaskCompleted = true;
        donePotato.gameObject.SetActive(true);
    }

    public void CompleteBedTask()
    {
        bedTaskCompleted = true;
        doneBed.gameObject.SetActive(true);
    }*/

}
