using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : GameControlBase
{
    public GuideSignQuest guideQuest;

    public override void Init(ManagerType _type)
    {
        base.Init(_type);
    }

    public override void Open()
    {
        base.Open();

        guideQuest = GameObject.FindGameObjectWithTag("GuideSign").GetComponentInChildren<GuideSignQuest>();
    }


}
