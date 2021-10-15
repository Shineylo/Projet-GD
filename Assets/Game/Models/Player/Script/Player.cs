using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private int xp = 0;
    [SerializeField] private float attack = 5.0f;
    [SerializeField] private float defence = 5.0f;
    [SerializeField] private float stamina = 1.0f;
    [SerializeField] private int hp = 20;
    [SerializeField] private int maxhp = 20;
    [SerializeField] private int requiredXp = 100;
    [SerializeField] private int levelBase = 100;
    [SerializeField] private List<GameObject> enemys = new List<GameObject>();
    private int lvl = 1;

    private string path;

    public int Xp
    {
        get { return xp; }
    }

    public float Attack
    {
        get { return attack; }
    }

    public float Defence
    {
        get { return defence; }
    }

    public float Stamina
    {
        get { return stamina; }
    }

    public int Hp
    {
        get { return hp; }
    }

    public int MaxHp
    {
        get { return maxhp; }
    }

    public int RequiredXp
    {
        get { return requiredXp; }
    }

    public int LevelBase
    {
        get { return levelBase; }
    }

    public List<GameObject> Enemys
    {
        get { return enemys; }
    }

    public int Lvl
    {
        get { return lvl; }
    }

    private void Start()
    {
        path = Application.persistentDataPath + "/player.dat";
        Load();
    }

    public void AddXp(int xp)
    {
        xp = Mathf.Max(0, xp);
        //InitLevelData();
    }

    public void AddEnemy(GameObject enemy)
    {
        enemys.Add(enemy);
    }

    private void InitLevelData()
    {
        lvl = (xp / levelBase) + 1;
        requiredXp = levelBase * lvl;
    }

    private void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(path);
        PlayerData data = new PlayerData(this);
        bf.Serialize(file, data);
        file.Close();
    }

    private void Load()
    {
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            attack = data.Attack;
            defence = data.Defence;
            stamina = data.Stamina;
            xp = data.XP;
            requiredXp = data.RequiredXP;
            hp = data.Hp;
            maxhp = data.HpMax;
            levelBase = data.LevelBase;
            lvl = data.Lvl;

        }
        else
        {
            InitLevelData();
        }
    }

    private void OnApplicationQuit()
    {
        Save();
    }
}
