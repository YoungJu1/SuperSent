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

    private List<GameObject> bread = new List<GameObject>();
    private CustomerMove customerMove;
    private int wishBreadCount;
    private bool breadclear = false;

    private void Start()
    {
        customerMove = GetComponent<CustomerMove>();
    }
    public void WishBreadUI()
    {
        wishBreadCount = Random.Range(1, 7);
        quest_txt.text = wishBreadCount.ToString();
        bubble_img.gameObject.SetActive(true);
    }
    private void GetBread()
    {
        if (guideQuest.Bread.Count < 1) return;

        for (int i = 0; i < guideQuest.Bread.Count; i++)
        {
            if (i == wishBreadCount) return;

            bread.Add(guideQuest.Bread[i]);
            guideQuest.Bread[i].transform.SetParent(gameObject.transform);
            guideQuest.Bread.RemoveAt(i);
        }

        if (wishBreadCount == bread.Count)
        {
            breadclear = true;
            customerMove.ChangeMovePoint(GameControl.Instance.BasketPosition[3].gameObject.transform, GameObject.FindGameObjectWithTag("Pos"));
            customerMove.Ani.SetBool("walk", true);
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            customerMove.ChangeMovePoint(GameControl.Instance.BasketPosition[3].gameObject.transform, GameObject.FindGameObjectWithTag("Pos"));
            customerMove.Ani.SetBool("walk", true);
        }
    }
}
