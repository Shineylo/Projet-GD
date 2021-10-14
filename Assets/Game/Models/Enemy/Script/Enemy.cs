using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    [SerializeField] private float spawnRate = 0.10f;
    [SerializeField] private int attack = 0;
    [SerializeField] private int defense = 0;
    [SerializeField] private int hp = 10;

    public float SpawnRate
    {
        get { return spawnRate; }
    }

    public int Attack
    {
        get { return Attack; }
    }

    public int Defense
    {
        get { return Defense; }
    }

    public int Hp
    {
        get { return hp; }
    }

    private void OnMouseDown()
    {
        GeoRpgSceneManager[] managers = FindObjectsOfType<GeoRpgSceneManager>();
        foreach(GeoRpgSceneManager geoRpgSceneManager in managers)
        {
            if (geoRpgSceneManager.gameObject.activeSelf)
            {
                geoRpgSceneManager.enemyTapped(this.gameObject);
            }
        }
    }
}
