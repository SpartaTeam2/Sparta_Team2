using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public GameObject MonsterPre;
    public MonsterData[] _monster;

    public int MaxMonster;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// MinNum과 MaxNum을포함합니다.
    /// </summary>
    /// <param name="MinNum"></param>
    /// <param name="MaxNum"></param>
    /// <returns></returns>
    int RandomMonster(int _minNum, int _maxNum, int _maxMonster)
    {
        for (int MN = 0; MN >= _maxMonster; MN++)
        {
            SpawnMonster(MN);
        }
        int i = Random.Range(_minNum, _maxNum);
        return i ;
    }

    void SpawnMonster(int _monsterIndex)
    {

        for (int i = 0; i>= MaxMonster;i++)
        {
            Instantiate(MonsterPre);
        }
        //Monster Mondata = MonsterPre.GetComponent<MonsterData>
    }
}
