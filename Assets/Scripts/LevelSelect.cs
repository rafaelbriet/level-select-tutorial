using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    [SerializeField]
    private Level[] levels;

    [Header("Level cards")]
    [SerializeField]
    private GameObject levelCardPrefab;
    [SerializeField]
    private RectTransform levelCardsContainer;
    [SerializeField]
    private ToggleGroup levelCardToggleGroup;

    [Header("Pagination")]
    [SerializeField]
    private int levelsPerPage;
    [SerializeField]
    private Button nextPageButton;
    [SerializeField]
    private Button previousPageButton;

    private int currentPage = 0;
    private Level selectedLevel;

    private void Awake()
    {
        CreateLevelCards();
        RefreshPageContent();
    }

    private void CreateLevelCards()
    {
        foreach (Level level in levels)
        {
            GameObject levelCardGO = Instantiate(levelCardPrefab, levelCardsContainer);
            LevelCard levelCard = levelCardGO.GetComponent<LevelCard>();
            levelCard.SetCardContent(level);
            levelCard.SetToggleGroup(levelCardToggleGroup);
            levelCard.Toggle.onValueChanged.AddListener(isOn => LevelSelected(isOn, levelCard));
        }
    }

    private void LevelSelected(bool isOn, LevelCard levelCard)
    {
        if (isOn == false)
        {
            return;
        }

        selectedLevel = levelCard.LevelInfo;
    }

    private void RefreshPageContent()
    {
        int startIndex = currentPage * levelsPerPage;
        int endIndex = startIndex + levelsPerPage;

        for (int i = 0; i < levels.Length; i++)
        {
            if (i >= startIndex && i < endIndex)
            {
                levelCardsContainer.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                levelCardsContainer.GetChild(i).gameObject.SetActive(false);
            }
        }

        CheckPaginationButtons();
    }

    public void NextPage()
    {
        currentPage++;
        RefreshPageContent();
    }

    public void PreviousPage()
    {
        currentPage--;
        RefreshPageContent();
    }

    private void CheckPaginationButtons()
    {
        int totalPages = levels.Length / levelsPerPage;

        nextPageButton.interactable = currentPage != totalPages;
        previousPageButton.interactable = currentPage != 0;
    }

    public void StartSelectedLevel()
    {
        SceneManager.LoadScene(selectedLevel.SceneName);
    }
}
