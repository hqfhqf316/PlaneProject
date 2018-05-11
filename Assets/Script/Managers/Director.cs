using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Director : SingleTon<Director>
{
    private Director director;
    private int score = 0;
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private GameObject Golds;
    
    private float timer = 0;
    private float timer2 = 0;
    private EnemySimpleFactory enemySimpleFactory;
    public event Action OnPlayerDead;
    public event Action OnPlayerRespawn;
    private int liftcount = 3;
    public int PlayerLiftcount
    {
        get { return liftcount; }
    }
    void Start()
    {
        director = Director.Instance;
    }
    public int Score
    {
        get { return score; }
        set { score = value; }
    }
    protected override void Awake()
    {
        enemySimpleFactory = new EnemySimpleFactory();
        enemySimpleFactory.CreateEnemy("EnemyBoss");
        Instantiate(Player, Player.transform.position, Quaternion.identity);
    }
    private void Update()
    {

        timer += Time.deltaTime;
        timer2 += Time.deltaTime;
        if (timer2 > 8)
        {
            Golds.transform.position = new Vector3(UnityEngine.Random.Range(ScreenXY.MinX, ScreenXY.MaxX), ScreenXY.MaxY, 0);
            Instantiate(Golds, Golds.transform.position, Quaternion.identity);
            timer2 = 0;
        }
        if (timer > 5)
        {
            enemySimpleFactory.CreateEnemy("EnemyBoss");
            enemySimpleFactory.CreateEnemy("NormalEnemy");
            timer = 0;
        }
    }

    //玩家死亡事件
    public void PlayerDead()
    {
        if (OnPlayerDead != null) { 
        OnPlayerDead.Invoke();
        }
        
            liftcount--;
        if (liftcount > 0)
        {
            StartCoroutine(WaitPlayerDead());
        }
        else
            Debug.Log("GAMEOVER");
           
    }

    //死亡延迟复活
    private IEnumerator WaitPlayerDead()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(Player, Player.transform.position, Quaternion.identity);
       
        
        if (OnPlayerRespawn != null)
        {
            OnPlayerRespawn.Invoke();
        }
       
    }
    //复活无敌时间
    //private IEnumerator Invincible()
    //{
    //    yield return new WaitForSeconds(2f);

    //    AppConst.IsDebugMode = false;
    //    yield return null;
    //}
    
    private void Revive()
    {
        Instantiate(Player, Player.transform.position, Quaternion.identity);
    }

    private void OnEnable()
    {
        if (InputManger.Instance)
        {
            InputManger.Instance.OnRevive += Revive;
        }
    }
    private void OnDisable()
    {
        if (InputManger.Instance)
        {
            InputManger.Instance.OnRevive += Revive;
        }
    }
}

