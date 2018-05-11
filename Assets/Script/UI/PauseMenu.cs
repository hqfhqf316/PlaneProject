using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    [SerializeField]
    private CanvasGroup pauseGroup;
    [SerializeField]
    private CanvasGroup settingGroup;
    [SerializeField]
    private string scenename = "MainMenu";
    private Stack<CanvasGroup> canvasGroupStack = new Stack<CanvasGroup>();
    private List<CanvasGroup> canvasGroupList = new List<CanvasGroup>();
    private void Start()
    {
        canvasGroupList.Add(pauseGroup);
        canvasGroupList.Add(settingGroup);
        DisplayMenu();
        
    }
    public void Esc()
    {
        if (canvasGroupStack.Count==0)
        {
            print("pause");
            Pause();
        }
        else if (canvasGroupStack.Count>0)
            {
                canvasGroupStack.Pop();
            DisplayMenu();
                if (canvasGroupStack.Count==0)
                {
                    UnPause();
                }
            }
        
    }
    private void OnEnable()
    {
        if (InputManger.Instance)
        {
            InputManger.Instance.OnEsc += Esc;
            InputManger.Instance.OnSetting += Setting;
        }
    }
    private void OnDisable()
    {
        if (InputManger.Instance)
        {
            InputManger.Instance.OnEsc -= Esc;
            InputManger.Instance.OnSetting -= Setting;
        }
    }
    
    public void Pause()
    {
        GameManger.Instance.Pause();
        canvasGroupStack.Push(pauseGroup);
        DisplayMenu();
    }
    public void UnPause()
    {
        GameManger.Instance.Pause();
        if (canvasGroupStack.Count>0)
        {
            canvasGroupStack.Pop();
        }
        DisplayMenu();
    }
    public void Setting()
    {
        canvasGroupStack.Push(settingGroup);
        DisplayMenu();
    }
    public void Exit()
    {
      StartCoroutine(LoadGame());
    }

    private IEnumerator LoadGame()
    {
        Uimanger.Instance.FadeOn(false);
        yield return new WaitForSecondsRealtime(1f);
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
        if (canvasGroupStack.Count>0)
        {
            CanvasGroup cg = canvasGroupStack.Peek();
            cg.alpha = 1;
            cg.interactable = true;
            cg.blocksRaycasts = true;
        }
    }
    //private void DisplaySetting()
    //{
    //    foreach (var item in canvasGroupList)
    //    {
    //        item.alpha = 0;
    //        item.interactable = false;
    //        item.blocksRaycasts = false;
    //    }
    //    if (canvasGroupStack.Count > 0)
    //    {
    //        CanvasGroup cg = canvasGroupStack.Peek();
    //        cg.alpha = 1;
    //        cg.interactable = true;
    //        cg.blocksRaycasts = true;
    //    }
    //}
}
