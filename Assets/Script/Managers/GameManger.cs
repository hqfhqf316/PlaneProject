using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : ContinuousSingleTon<GameManger> {
    public float TimeScale { get; private set; }
    private bool paused;
    public bool Paused { get { return paused; }set { paused = value; } }
    private float saveTimeScale = 1f;
    public void Pause()
    {
        if (Time.timeScale > 0)
        {
            Instance.SetTimeScale(0);
            Instance.Paused = true;
        }
        else UnPause();
    }
    public void UnPause()
    {
        Instance.ResetTimeScale();
        Instance.Paused = true;

    }
    public void SetTimeScale(float newTimeScale)
    {
        saveTimeScale = Time.timeScale;
        Time.timeScale = newTimeScale;
    }
    public void ResetTimeScale()
    {
        Time.timeScale = saveTimeScale;
    }
}
