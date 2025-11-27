using UnityEngine;
using TMPro;

public class BoxOfPotatoes : MonoBehaviour
{
    public int collected = 0;
    public int toBeCollected = 5;
    public TMP_Text counterText;

    private void UpdateUI()
    {
        counterText.text = $"{collected}/{toBeCollected}";
    }
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        var potato = other.GetComponent<PotatoType>();
        if (potato != null && potato.type == PotatoQuality.Good)
        {
            collected++;
            UpdateUI();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var potato = other.GetComponent<PotatoType>();
        if (potato != null && potato.type == PotatoQuality.Good)
        {
            collected--;
            UpdateUI();
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }
}
