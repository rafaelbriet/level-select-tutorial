using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class LevelCard : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI levelName;
    [SerializeField]
    private TextMeshProUGUI levelDescription;
    [SerializeField]
    private Image levelImage;
    
    public Level LevelInfo { get; private set; }
    public Toggle Toggle { get; private set; }

    private void Awake()
    {
        Toggle = GetComponent<Toggle>();
    }

    public void SetCardContent(Level level)
    {
        LevelInfo = level;
        levelName.SetText(level.LevelName);
        levelDescription.SetText(level.LevelDescription);

        if (level.IsUnolocked)
        {
            levelImage.sprite = level.LevelUnlockedImage;
        }
        else
        {
            levelImage.sprite = level.LevelLockedImage;
            Toggle.interactable = false;
        }
    }

    public void SetToggleGroup(ToggleGroup toggleGroup)
    {
        Toggle.group = toggleGroup;
    }
}
