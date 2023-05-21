using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    Quest currentActiveQuest;

    // Start is called before the first frame update
    void Start()
    {
        currentActiveQuest = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Quest GetCurrentQuest()
    {
        return currentActiveQuest;
    }

    public void SetCurrentQuest(Quest quest)
    {
        currentActiveQuest = quest;
    }

    public void RemoveQuest()
    {
        currentActiveQuest = null;
    }
}
