using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy/Generic")]
public class EnemySO : ScriptableObject
{
    public string enemyId;
    public RuntimeAnimatorController controller;
    public float maxHealth = 100;
    public float movementSpeed = 1.0f;
    public float attackRange = 1.0f;
    public float idleTime = 1.0f;

    private void OnEnable()
    {
        Debug.Log("Called on scriptable object's OnEnable");
    }
    public void PrintEnemyStats()
    {
        Debug.Log($"id: {enemyId}, health: {maxHealth}, speed: {movementSpeed}");
    }

    public void LoadData(string filePath)
    {
        //Read the json file and set our values to the data
    }

    public void SaveData(string filePath)
    {
        //Create a json file and save to filePath
    }
}
