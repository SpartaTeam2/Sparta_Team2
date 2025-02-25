using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public int DungeonLevel;
    public int StageLevel;
    public int MaxMonster;

    public GameObject[] Maps;
    public GameObject[] Monsters;

    public enum SpawnType
    {
        Clean,
        Wave,

        Boss
    }
    public SpawnType _spawnType;

    // Start is called before the first frame update
    void Start()
    {
        InsMap();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        GameObject[] _monsterList = GameObject.FindGameObjectsWithTag("Monster");
        if (_monsterList.Length <= 0)
        {
            if (StageLevel <= 10)
            {
                StageLevel++;
                SpawnMonster();
            }
            else
            {
                EndGame();
            }
        }
    }

    void InsMap()
    {
        if (GameObject.Find("Field") != null)
        {
            Destroy(GameObject.Find("Field"));
        }
        switch(DungeonLevel)
        {
            case 1:
                Instantiate(Maps[Random.Range(0, 4)]).name =("Field");
                break;

            case 2:

                break;

            case 3:

                break;

            default:
                break;
        }
    }

    void SpawnMonster()
    {
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
    }
    void InsCleanType()
    {
        for (int i =0; i<= MaxMonster; i++)
        {
            GameObject _insMons = Instantiate(GetComponent<MonsterManager>().MonsterArr[Random.Range(0, 3)], new Vector2(Random.Range(-3, 3), Random.Range(-3, 3)), Quaternion.identity);
            //_insMons.GetComponent<UglyEnemy>().maxHP = maxHP * 10;
        }
    }

    void InsWaveType()
    {
        //RandomSpawnMonster((StageLevel - 1) * 3, (StageLevel * 3));
        {
            GameObject _insMons = Instantiate(GetComponent<MonsterManager>().MonsterArr[Random.Range(0, 3)], new Vector2(Random.Range(-3, 3), Random.Range(-3, 3)), Quaternion.identity);
            //_insMons.GetComponent<UglyEnemy>().maxHP = maxHP * 10;
        }

    }

    void InsBossType()
    {
        GameObject _insMons = Instantiate(GetComponent<MonsterManager>().MonsterArr[Random.Range(0, 3)], new Vector2(Random.Range(-3, 3), Random.Range(-3, 3)), Quaternion.identity);

        //Instantiate(_boss[0]);
    }

    public void RandomSpawnMonster(int _minNum, int _maxNum)
    {
        //for (int i = 0; i >= MaxMonster; i++)
        //{
        //    int j = UnityEngine.Random.Range(_minNum, _maxNum);
        //    Instantiate(MonsterArr[j]);
        //}
        ////Monster Mondata = MonsterPre.GetComponent<MonsterData>
    }

    void EndGame()
    {
        SceneManager.LoadScene("Lobby");
    }
}
