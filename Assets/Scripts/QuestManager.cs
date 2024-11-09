using System.Collections.Generic;
using UnityEngine;

public class QuestManager : GameControlBase
{
    public GuideSignQuest guideQuest;


    [SerializeField] private GameObject ArrowObj;

    private GameObject arrow;

    [SerializeField] private List<GameObject> questObjs;

    public int questNum;

    private void Awake()
    {
        questNum = 0;
    }

    public void AddQuestObj(GameObject obj)
    {
        questObjs.Add(obj);
    }

    public override void Init(ManagerType _type)
    {
        base.Init(_type);
    }

    public override void Open()
    {
        base.Open();
        guideQuest = GameObject.FindGameObjectWithTag("GuideSign").GetComponentInChildren<GuideSignQuest>();
        arrow = Instantiate(ArrowObj);
        arrow.GetComponent<Arrow>()
            .SetArrowAnimation(questObjs[questNum].transform.position +
                               new Vector3(0f, 1f, 0f));
    }

    public void NextQuest(string _questName)
    {
        if (questObjs[questNum].name != _questName) return;
        questNum++;
        arrow.GetComponent<Arrow>()
            .SetArrowAnimation(questObjs[questNum].transform.position +
                               new Vector3(0f, 1f, 0f));
    }
    public Vector3 GetTargetPos()
    {
        return questObjs[questNum].transform.position;
    }
}