using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class NavController : MonoBehaviour
{
    [SerializeField]
    UIDocument startMenu;

    Button startBtn;

    [SerializeField]
    UIDocument questMenu;
    [SerializeField]
    UIDocument userInfoPanel;
    [SerializeField]
    UIDocument settingsPanel;

    //alerts
    [SerializeField]
    UIDocument IngameUI;
    [SerializeField]
    UIDocument questAccept;
    [SerializeField]
    UIDocument noQuestTaken;
    [SerializeField]
    UIDocument questCompleted;



    private void Awake()
    {
        startBtn = startMenu.rootVisualElement.Q("StartButton") as Button;
        startBtn.clicked += StartBtnClicked;
    }

    private void StartBtnClicked()
    {
        SceneManager.LoadScene("MapViewScene");
        startMenu.enabled = false;
        IngameUI.enabled = true;
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


}
