using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Function:
/// - used to switch between different panels
/// - tells the app so it triggers the correct information to load 
/// </summary>
public class PanelChanger : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject homePanel;
    public GameObject logPanel;

    [Header("Status")]
    [SerializeField]
    private GameObject currentActivePanel;

    private App app;

    private void Start()
    {
        app = App.Instance;

        StartupPanel();
    }

    public void StartupPanel()
    {
        if (homePanel.activeSelf)
            currentActivePanel = homePanel;
        if (logPanel.activeSelf)
            currentActivePanel = logPanel;
    }

    //switch to the logging panel
    public void ToLoggingPage()
    {
        currentActivePanel.SetActive(false);
        logPanel.SetActive(true);
        currentActivePanel = logPanel;

        app.LoadLoggingInformation();

    }

}
