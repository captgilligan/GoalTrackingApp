using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Functionality:
/// - Singleton that manages pulling and sending data through googlesheetscommunicator
/// - Holds the data for the tasks
/// - triggers panel changes
/// </summary>

public class App : MonoBehaviour
{
    public static App Instance { get; private set; }


    public HashSet<Entry> entries = new HashSet<Entry>();

    public Button logHomeButton;
    public GameObject loadingCircle;

    public bool fileRead;
    public string todaysDate;
    public Logger logger;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        loadingCircle.SetActive(true);
        logHomeButton.interactable = false;

        todaysDate = System.DateTime.Now.ToString("MM-dd-yyyy");
    }

    public void CanLog()
    {
        loadingCircle.SetActive(false);
        logHomeButton.interactable = true;
    }

    private void Update()
    {
        if (!fileRead && loadingCircle.activeSelf)
        {
            loadingCircle.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, 1), 10);
        }
    }

    public void LoadLoggingInformation()
    {
        Debug.Log("load logging info for this date");



        //logger.SetupLogData(toda)
    }
}
