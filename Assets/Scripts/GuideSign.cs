using UnityEngine;

public class GuideSign : MonoBehaviour , IQuestBase
{
    private QuestManager QuestManager;
    private void Awake()
    {
        QuestManager = GameObject.Find("Quest").GetComponent<QuestManager>();
    }

    public void Quest()
    {
        QuestManager.NextQuest(this.gameObject.name);
    }
}