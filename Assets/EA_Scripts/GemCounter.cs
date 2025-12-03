using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GemCounter : MonoBehaviour
{
    public int collected = 0;
    public int toBeCollected = 10;
    public TMP_Text counterText;
    public static GemCounter Instance;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        UpdateUI();
    }

    public void AddGem()
    {
        collected++;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (counterText != null)
        {
            counterText.text = $"{collected}/{toBeCollected}";
        }
    }
}
