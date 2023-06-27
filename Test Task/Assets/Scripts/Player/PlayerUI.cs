using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    private TextMeshProUGUI promtText;

    private void Awake()
    {
        promtText = GameObject.Find("PromptText").GetComponent<TextMeshProUGUI>();

        if (promtText == null)
        {
            Debug.LogError("Unable to find PromptText object in the scene!");
        }
    }

    public void UpdateText(string promtMessage)
    {
        promtText.text = promtMessage;
    }
}
