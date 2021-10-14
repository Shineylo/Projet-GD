using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GeoRpgSceneManager : MonoBehaviour
{
    public abstract void playerTapped(GameObject player);
    public abstract void enemyTapped(GameObject enemy);
}
