using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomerQuest : QuestManager
{
    public TMP_Text quest_txt;
    public Image bubble_img;
    public Image bread_img;
    public bool isBreadQuest = false;

    private List<int> bread = new List<int>();
    private int wishBreadCount;
    private bool breadmove = false;

    public void WishBreadUI()
    {
        wishBreadCount = Random.Range(1, 7);
        quest_txt.text = wishBreadCount.ToString();
        bubble_img.gameObject.SetActive(true);
        breadmove = true;
    }
    private void GetBread()
    {
        if (guideQuest.Bread.Count < 1) return;

        for (int i = 0; i < guideQuest.Bread.Count; i++)
        {
            if (i == wishBreadCount) return;

            guideQuest.Bread[i].transform.SetParent(gameObject.transform);
            guideQuest.Bread.RemoveAt(i);
        }
    }
    
    private void Update()
    {
        bubble_img.transform.LookAt(Camera.main.transform);

        if (isBreadQuest)
        {
            isBreadQuest = false;
            WishBreadUI();
        }
        if (breadmove)
        {
        }
    }
}
