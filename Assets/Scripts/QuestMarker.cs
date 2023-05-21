using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestMarker : MonoBehaviour
{

    [SerializeField] 
    Quest attachedQuest;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(showThisQuest);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void showThisQuest()
    {
        FindObjectOfType<NavController>().UpdateAcceptQuestData(attachedQuest);
    }
}
