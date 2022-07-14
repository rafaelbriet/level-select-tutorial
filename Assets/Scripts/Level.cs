using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "Level")]
public class Level : ScriptableObject
{
    [SerializeField]
    private string sceneName;
    [SerializeField]
    private string levelName;
    [SerializeField]
    [TextArea(10, 15)]
    private string levelDescription;
    [SerializeField]
    private bool startUnlocked;
    [SerializeField]
    private Sprite levelLockedImage;
    [SerializeField]
    private Sprite levelUnlockedImage;

    public string SceneName { get { return sceneName; } }
    public string LevelName { get { return levelName; } }
    public string LevelDescription { get { return levelDescription; } }
    public Sprite LevelLockedImage { get { return levelLockedImage; } }
    public Sprite LevelUnlockedImage { get { return levelUnlockedImage; } }

    public bool IsUnlocked { get; set; }

    private void OnEnable()
    {
        IsUnlocked = startUnlocked;
    }
}
