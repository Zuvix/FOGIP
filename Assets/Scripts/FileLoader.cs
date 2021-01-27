using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleFileBrowser;
using System;
using System.Text.RegularExpressions;

public class FileLoader : MonoBehaviour
{
    void Start()
    {
        FileBrowser.SetFilters(true, new FileBrowser.Filter("Objects", ".obj"));
        FileBrowser.SetDefaultFilter(".obj");
        FileBrowser.SetExcludedExtensions(".lnk", ".tmp", ".zip", ".rar", ".exe");
        FileBrowser.AddQuickLink("Resources", @"Assets\", null);
    }
    public void OpenBrowser()
    {
        StartCoroutine(ShowLoadDialogCoroutine());
    }
    IEnumerator ShowLoadDialogCoroutine()
    {
        // Show a load file dialog and wait for a response from user
        // Load file/folder: file, Initial path: default (Documents), Title: "Load File", submit button text: "Load"
        yield return FileBrowser.WaitForLoadDialog(false, @"Assets\","Load Object","Load");

        // Dialog is closed
        // Print whether a file is chosen (FileBrowser.Success)
        // and the path to the selected file (FileBrowser.Result) (null, if FileBrowser.Success is false)
        Debug.Log(FileBrowser.Success + " " + FileBrowser.Result);

        if (FileBrowser.Success)
        {
            IndexedFace.Instance.UpdateModel(FileBrowser.Result,FileBrowserHelpers.GetFilename(FileBrowser.Result).Replace(".obj", ""));
        }
    }
}
