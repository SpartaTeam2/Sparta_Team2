using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MonsterData
{
    public int MonsterIndex;
    public string MonsterName;
    public float MonsterMaxHP;
    public float MonsterSpeed;
    public float ChaseDis;
    public float FightDis;
    public enum MonsterState
    {
        Idle,
        Chase,
        Fight,
        Die
    }
    public MonsterState _monsterState = MonsterState.Chase;
    public Sprite MonsterImage;

    [Header("애니메이션")]
    public AnimationClip Idle_Anim;
    public AnimationClip Chase_Anim;
    public AnimationClip Fight_Anim;
    public AnimationClip Die_Anim;

    public MonsterData (int _monsterIndex, string _monsterName, float _monsterMaxHP)
    {

    }
}