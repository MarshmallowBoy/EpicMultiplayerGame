using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class Quest : ScriptableObject
{
    [System.Serializable]

    public struct QuestInformation
    {
        public string Name;
        public string Description;
    }

    [Header("QInfo")] public QuestInformation Info;

    [System.Serializable]

    public struct Stat
    {
        public int Currency;
        public int Exp;
    }

    [Header("Rewards")] public Stat Reward = new Stat{Currency = 0, Exp = 75};

    public bool Completed {  get; protected set; }
    public QuestCompletion QuestCompleted;

    public abstract class QuestObjectives : ScriptableObject
    {
        protected string Description;
        public int CurrentAmount {  get; protected set; }
        public int RequiredAmount = 1;

        public bool Completed { get; protected set; }
        public UnityEvent QuestCompleted;

        public virtual string GetDescription() 
        { 
            return Description; 
        }

        public virtual void Initialize()
        {
            Completed = false;
            QuestCompleted = new UnityEvent();
        }

        protected void Evaluate()
        {
            if(CurrentAmount >= RequiredAmount)
            {
                Completion();
            }
        }

        private void Completion()
        {
            Completed = true;
            QuestCompleted.Invoke();
            QuestCompleted.RemoveAllListeners();
        }

    }

    public List<QuestObjectives> Objectives;

    public void Initialize()
    {
        Completed = false;
        QuestCompleted = new QuestCompletion();

        foreach(var objective in Objectives) 
        {
            objective.Initialize();
            objective.QuestCompleted.AddListener(delegate { CheckObjectives(); });
        }
    }
    private void CheckObjectives()
    {
        Completed = Objectives.All(g: QuestObjectives => g.Completed);
        if (Completed)
        {
            QuestCompleted.Invoke(arg0: this);
            QuestCompleted.RemoveAllListeners();
        }
    }
}

public class QuestCompletion : UnityEvent<Quest>
{

}