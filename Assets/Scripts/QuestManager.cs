using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : GameControlBase
{
    public GuideSignQuest guideQuest;

    [SerializeField] private GameObject ArrowObj;
    
    private int questIndex;
    
    private List<GameObject> questObjs;
    public override void Init(ManagerType _type)
    {
        base.Init(_type);
    }

    private void Awake()
    {
        
    }

    public override void Open()
    {
        base.Open();
        
        guideQuest = GameObject.FindGameObjectWithTag("GuideSign").GetComponentInChildren<GuideSignQuest>();
    }
}
