using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerData 
{
    private float attack;
    private float defence;
    private float stamina;
    private int xp;
    private int requiredXp;
    private int hp;
    private int hpMax;
    private int levelBase;
    private int lvl;
    private List<EnemyData> enemys;

    public float Attack { get { return attack; } }
    public float Defence { get { return defence; } }
    public float Stamina { get { return stamina; } }
    public int XP { get { return xp; } }
    public int RequiredXP { get { return requiredXp; } }
    public int Hp { get { return hp; } }
    public int HpMax { get { return hpMax; } }
    public int LevelBase { get { return levelBase; } }
    public int Lvl { get { return lvl; } }
    public List<EnemyData> Enemys { get { return enemys; } }

    public PlayerData(Player player)
    {
        attack = player.Attack;
        defence = player.Defence;
        stamina = player.Stamina;
        xp = player.Xp;
        requiredXp = player.RequiredXp;
        hp = player.Hp;
        hpMax = player.MaxHp;
        levelBase = player.LevelBase;
        lvl = player.Lvl;

        foreach(GameObject enemyObject in player.Enemys)
        {
            Enemy enemy = enemyObject.GetComponent<Enemy>();
            if(enemy!= null)
            {
                EnemyData data = new EnemyData(enemy);
                enemys.Add(data);
            }
        }
    }

}
