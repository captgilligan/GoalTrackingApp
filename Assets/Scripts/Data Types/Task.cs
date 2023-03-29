using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
/// <summary>
/// Used to describe what is a task
/// </summary>
[System.Serializable]
public class Task : MonoBehaviour
{
    [SerializeField]
    public string taskTitle
    {
        get { return taskTitle; }
        set { taskTitle = value;
            title.text = value;
        }
    }
    [SerializeField]
    public string taskDescription {
        get { return taskDescription; }
        set { taskDescription = value;
            description.text = value;
        }
    }
    [SerializeField]
    public bool completeStatus;

    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public Button logButton;

    [SerializeField]
    public Task(string name, string description)
    {
        this.taskTitle = name;
        this.taskDescription = description;
    }

    private bool tempComplete;
}
