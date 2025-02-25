using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public List<GameObject> MonsterArr;
    public List<GameObject> _boss;

    public int DungeonLevel;
    public int StageLevel;

    public int MaxMonster;

    public enum SpawnType
    {
        Clean,
        Wave,
        Boss
    }
    SpawnType _spawnType;

    // Start is called before the first frame update
    void Start()
    {
        SetMonsterStat(MonsterArr,StageLevel);
        switch (_spawnType)
        {
            case SpawnType.Clean:
                InsCleanType();
                break;

            case SpawnType.Wave:
                InsWaveType();
                break;

            case SpawnType.Boss:
                InsBossType();
                break;

            default:
                Debug.Log("Null SpawnType");
                break;
        }
        RandomSpawnMonster(1, 3);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void InsCleanType ()
    {
        //Instantiate(MonsterArr[]);
        //RandomSpawnMonster();
    }

    void InsWaveType()
    {
        RandomSpawnMonster((StageLevel-1)*3, (StageLevel* 3));
    }

    void InsBossType()
    {
        Instantiate(_boss[0]);
    }

    public void SetMonsterStat(List<GameObject> _monster, int Level)
    {

    }

    public void RandomSpawnMonster(int _minNum, int _maxNum)
    {
        for (int i = 0; i>= MaxMonster; i++)
        {
            int j = UnityEngine.Random.Range(_minNum, _maxNum);
            Instantiate(MonsterArr[j]);
        }
        //Monster Mondata = MonsterPre.GetComponent<MonsterData>
    }
}
