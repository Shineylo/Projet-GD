using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class EnemyData
{
    private float spawnRate;
    private int attack ;
    private int defense ;
    private int hp ;

    public float SpawnRate { get { return spawnRate; } }

    public int Attack { get { return attack; } }

    public int Defense { get { return defense; } }

    public int Hp { get { return hp; } }

    public EnemyData(Enemy enemy)
    {
        spawnRate = enemy.SpawnRate;
        attack = enemy.Attack;
        defense = enemy.Defense;
        hp = enemy.Hp;
    }

}
