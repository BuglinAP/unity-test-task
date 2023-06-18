using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI promtText;

    void Start()
    {
        
    }
    
    public void UpdateText(string promtMessage)
    {
        promtText.text = promtMessage;
    }
}
