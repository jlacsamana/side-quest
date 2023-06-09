using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI.MessageBox;

public class NavController : MonoBehaviour
{
    [SerializeField]
    UIDocument startMenu;

    Button startBtn;

    [SerializeField]
    UIDocument questMenu;

    Button dismissQuestView;
    Button continueQuest;

    [SerializeField]
    UIDocument userInfoPanel;
    [SerializeField]
    UIDocument settingsPanel;

    [SerializeField]
    UIDocument IngameUI;

    Button currentQuestButton;

    //alerts
    [SerializeField]
    UIDocument questAccept;

    Button declineQuest;
    Button acceptQuest;

    [SerializeField]
    UIDocument noQuestTaken;

    Button noQuestBackButton;

    [SerializeField]
    UIDocument questCompleted;

    public Quest currentQuestSelectedInView;

    private void Awake()
    {
        currentQuestSelectedInView = null;

        startBtn = startMenu.rootVisualElement.Q("StartButton") as Button;
        startBtn.clicked += StartBtnClicked;

        currentQuestButton = IngameUI.rootVisualElement.Q("QuestMenuBtn") as Button;
        currentQuestButton.clicked += CheckActiveQuest;

        noQuestBackButton = noQuestTaken.rootVisualElement.Q("BackButton") as Button;
        noQuestBackButton.clicked += AcknowledgeBeingDumb;

        declineQuest = questAccept.rootVisualElement.Q("BackButton") as Button;
        declineQuest.clicked += DeclineQuest;

        acceptQuest = questAccept.rootVisualElement.Q("StartButton") as Button;
        acceptQuest.clicked += AcceptQuest;

        dismissQuestView = questMenu.rootVisualElement.Q("AbandonButton") as Button;
        dismissQuestView.clicked += AbandonQuest;

        continueQuest = questMenu.rootVisualElement.Q("ContinueButton") as Button;
        continueQuest.clicked += ContinueQuest;
    }

    private void StartBtnClicked()
    {
        SceneManager.LoadScene("MapViewScene");
        startMenu.rootVisualElement.style.display = DisplayStyle.None;
        IngameUI.rootVisualElement.Q("root").style.visibility = Visibility.Visible;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //
    }

    //
    void CheckActiveQuest()
    {
        if (gameObject.GetComponent<PlayerData>().GetCurrentQuest() == null)
        {
            //show alert
            noQuestTaken.rootVisualElement.Q("NoQuestAlert").style.visibility = Visibility.Visible;

        }
        else
        {
            //show quest data
            questMenu.rootVisualElement.Q("QuestView").style.visibility = Visibility.Visible;
            (questMenu.rootVisualElement.Q("GPT_TITLE") as Label).text = GetComponent<PlayerData>().GetCurrentQuest().questTitle;
            (questMenu.rootVisualElement.Q("GPT_TXT") as Label).text = GetComponent<PlayerData>().GetCurrentQuest().questDescription;

        }
    }

    void AcknowledgeBeingDumb()
    {
        noQuestTaken.rootVisualElement.Q("NoQuestAlert").style.visibility = Visibility.Hidden;
    }

    public void UpdateAcceptQuestData(Quest quest)
    {
        currentQuestSelectedInView = quest;
        (questAccept.rootVisualElement.Q("GPT_TITLE") as Label).text = quest.questTitle;
        (questAccept.rootVisualElement.Q("GPT_TXT") as Label).text = quest.questDescription;
        questAccept.rootVisualElement.Q("AcceptQuest").style.visibility = Visibility.Visible;
    }

    void DeclineQuest()
    {
        questAccept.rootVisualElement.Q("AcceptQuest").style.visibility= Visibility.Hidden;
    }

    void AcceptQuest()
    {
        questAccept.rootVisualElement.Q("AcceptQuest").style.visibility = Visibility.Hidden;
        //sets the current quest as active
        GetComponent<PlayerData>().SetCurrentQuest(currentQuestSelectedInView);
    }

    void AbandonQuest()
    {

        questMenu.rootVisualElement.Q("QuestView").style.visibility = Visibility.Hidden;
        gameObject.GetComponent<PlayerData>().RemoveQuest();
        Debug.Log("working");
    }

    void ContinueQuest()
    {
        questMenu.rootVisualElement.Q("QuestView").style.visibility = Visibility.Hidden;
        Debug.Log("working");

    }


}
