using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySimpleFactory
{
    public GameObject NormalEnemy { get; private set; }
    public GameObject EnemyBoss { get; private set; }
    public EnemySimpleFactory()
    {
        NormalEnemy = Resources.Load<GameObject>("Prefabs/NormalEnemy");
        EnemyBoss = Resources.Load<GameObject>("Prefabs/EnemyBoss");
        
    }

    public GameObject CreateEnemy(string type)
    {
        GameObject enemybase = null;
        if (type == "NormalEnemy")
        {
             GameObject.Instantiate(NormalEnemy, new Vector3(ScreenXY.MinX, ScreenXY.MaxY, 0), Quaternion.identity);
            
            
        }
        if (type == "EnemyBoss")
        {
            GameObject.Instantiate(EnemyBoss, new Vector3((ScreenXY.MinX + ScreenXY.MaxX) * 0.5f, ScreenXY.MaxY + Vector3.down.y, 0), Quaternion.identity);
           
        
        }
        return enemybase;
    }
}

