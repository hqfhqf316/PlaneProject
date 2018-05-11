using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu2 : MonoBehaviour {

    [SerializeField]
    private CanvasGroup pauseGroup;
    [SerializeField]
    private CanvasGroup settingGroup;
    [SerializeField]
    private CanvasGroup creditGroup;
    [SerializeField]
    private string scenename = "Lv01";
    private Stack<CanvasGroup> canvasGroupStack = new Stack<CanvasGroup>();
    private List<CanvasGroup> canvasGroupList = new List<CanvasGroup>();
    private void Start()
    {
        Uimanger.Instance.FadeOn(true);
        canvasGroupList.Add(pauseGroup);
        canvasGroupList.Add(settingGroup);
        canvasGroupList.Add(creditGroup);
        canvasGroupStack.Push(pauseGroup);
        DisplayMenu();

    }
    public void Esc()
    {
        if (canvasGroupStack.Count <= 1) return;
            canvasGroupStack.Pop();
            DisplayMenu();
    }
    public void Setting()
    {
        canvasGroupStack.Push(settingGroup);
        DisplayMenu();
    }

    public void StartGame()
    {
        
        Time.timeScale = 1;
         Uimanger.Instance.FadeOn(false);
        StartCoroutine(LoadGame());
    }
    
    private IEnumerator LoadGame()
    {
        Uimanger.Instance.FadeOn(true);
        yield return new WaitForSeconds(1f);
        LoadManger.LoadScene(scenename);
           
    }
    private void DisplayMenu()
    {
       
        foreach (var item in canvasGroupList)
        {
            item.alpha = 0;
            item.interactable = false;
            item.blocksRaycasts = false;
        }
        if (canvasGroupStack.Count > 0)
        {
            CanvasGroup cg = canvasGroupStack.Peek();
            cg.alpha = 1;
            cg.interactable = true;
            cg.blocksRaycasts = true;
        }
    }

}
