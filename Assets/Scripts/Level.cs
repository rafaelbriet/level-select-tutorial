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
    private bool isUnolocked;
    [SerializeField]
    private Sprite levelLockedImage;
    [SerializeField]
    private Sprite levelUnlockedImage;

    public bool IsUnolocked
    {
        get
        {
            return isUnolocked;
        }
        set
        {
            isUnolocked = value;
        }
    }

    public string SceneName { get { return sceneName; } }
    public string LevelName { get { return levelName; } }
    public string LevelDescription { get { return levelDescription; } }
    public Sprite LevelLockedImage { get { return levelLockedImage; } }
    public Sprite LevelUnlockedImage { get { return levelUnlockedImage; } }
}
