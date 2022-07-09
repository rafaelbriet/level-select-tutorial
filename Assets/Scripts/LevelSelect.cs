using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    [SerializeField]
    private Level[] levels;
    [SerializeField]
    private GameObject levelCardPrefab;
    [SerializeField]
    private RectTransform levelCardsContainer;

    private void Awake()
    {
        CreateLevelCards();
    }

    private void CreateLevelCards()
    {
        foreach (Level level in levels)
        {
            GameObject levelCardGO = Instantiate(levelCardPrefab, levelCardsContainer);
            LevelCard levelCard = levelCardGO.GetComponent<LevelCard>();
            levelCard.SetCardContent(level);
        }
    }
}
