using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelCard : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI levelName;
    [SerializeField]
    private TextMeshProUGUI levelDescription;
    [SerializeField]
    private Image levelImage;

    public void SetCardContent(Level level)
    {
        levelName.SetText(level.LevelName);
        levelDescription.SetText(level.LevelDescription);

        if (level.IsUnolocked)
        {
            levelImage.sprite = level.LevelUnlockedImage;
        }
        else
        {
            levelImage.sprite = level.LevelLockedImage;
        }
    }
}
