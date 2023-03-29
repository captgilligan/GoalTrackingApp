using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// Function:
/// -loaded the logging page tasks / information from the database
/// -populated the tasks with the correct information
/// -triggers the pushing to the google sheet if information is changed
/// 
/// </summary>
public class Logger : MonoBehaviour
{
    private App app;

    public TextMeshProUGUI dateField;
    public List<Task> taskPrefabs = new List<Task>();

    private void Start()
    {
        app = App.Instance;
    }


    public void SetupLogData(Entry thisWeeksEntry)
    {
        for(int i = 0; i < thisWeeksEntry.tasks.Count; i++)
        {
            taskPrefabs[i].gameObject.SetActive(true);
            taskPrefabs[i].taskTitle = thisWeeksEntry.tasks[i].taskTitle;
            taskPrefabs[i].taskDescription = thisWeeksEntry.tasks[i].taskDescription;
        }
    }
}
