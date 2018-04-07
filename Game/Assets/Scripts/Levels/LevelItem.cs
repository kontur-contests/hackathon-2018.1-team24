using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCoreLibrary;
using Assets.Scripts.Enemy;
using System;

public class LevelItem : MonoBehaviour
{   
    public LevelItemSerializable levelItem;

    [Serializable]
    public class LevelItemSerializable
    {
        public ObjectType baseGameObject;
        public Pos pos;
        public EnemyParams enemyParams;
    }

    public void UpdateParams ()
    {
        levelItem.pos = new Pos(transform.position.x, transform.position.y);
        var enemyObject = GetComponent<EnemyBase>();

        if (enemyObject != null)
        {
            levelItem.enemyParams.speed = enemyObject.Speed;
            levelItem.enemyParams.hit = enemyObject.Hit;
            levelItem.enemyParams.hp = enemyObject.Hp;
        }

    }
	
	
	void Update ()
    {
		
	}
}
