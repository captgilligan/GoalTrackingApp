using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using static System.Net.WebRequestMethods;
/// <summary>
/// Function:
/// - used to communicate with Google sheets
/// - outputs data found and can make new requests
/// </summary>
public class GoogleSheetsCommunicator : MonoBehaviour
{
    public string APIKEY = "AIzaSyCnd4xGS714VsdZdeQFnFc6O_6EP-J3X2w";
    public string sheetURL = "https://sheets.googleapis.com/v4/spreadsheets/";
    public string sheetName = "Sheet1";
    public string spreadSheetID = "1t-AybQLW4jdM6TUKlS67WCA4xBc-zz1mMT7EFl0jUZ4";

    private App app;

    public List<Task> tempList = new List<Task>();


    public bool SheetRead;

    private void Start()
    {
        app = App.Instance;

        StartCoroutine(ReadSheet());
    }


    private string URLGenerator()
    {
        string newURL = sheetURL + spreadSheetID + "/values/" + sheetName + "?key=" + APIKEY;
        Debug.Log("Trying to Connect to: " + newURL);
        return newURL;
    }

    public IEnumerator ReadSheet()
    {
        UnityWebRequest www = UnityWebRequest.Get(URLGenerator());

        yield return www.SendWebRequest();

        //there was a possible error
        if(www.isNetworkError || www.isHttpError || www.timeout > 2)
        {
            Debug.LogError("Error: " + www.error);
        }

        // was able to connect... parse information
        else
        {
            string dataAsJson = www.downloadHandler.text;
            //Debug.Log(dataAsJson);

            UpdateFullData(dataAsJson);
        }
    }

    private void UpdateFullData(string data)
    {
        var info = JSON.Parse(data);

        foreach(var item in info["values"])
        {


            string[] details = JSON.Parse(item.ToString()).ToString().Split(',');

            for(int i = 0; i<details.Length;i++)
            {
                details[i] = details[i].Replace("[", "");
                details[i] = details[i].Replace("]", "");
                details[i] = details[i].Replace("\"", "");
            }

            //Debug.Log(details[0]);
            //add the task titles
            if (details[0].Contains("Title"))
            {
                
                for (int i = 1; i < details.Length; i++)
                {
                    Task tempTask = new Task(details[i], "");
                    tempList.Add(tempTask); 
                }
                continue;
            }

            //add the task decriptions
            if (details[0].Contains("Description"))
            {
                for (int i = 1; i < details.Length; i++)
                {
                    tempList[i - 1].taskDescription = details[i];
                }
                continue;
            }

            //are entries
            //else
            //{
            //    Entry tempEntry = new Entry();
            //    for (int i = 1; i < details.Length; i++)
            //    {
            //        Task task = new Task(tempList[i - 1].taskTitle, tempList[i-1].taskDescription);

            //        if (details[i] == "1")
            //        {
            //            task.completeStatus = true;
            //        }
            //        else
            //        {
            //            task.completeStatus = false;
            //        }

            //        tempEntry.tasks.Add(task);

            //    }

            //    app.entries.Add(tempEntry);
            //}



        }

        app.fileRead = true;
        app.CanLog();
    }
}
