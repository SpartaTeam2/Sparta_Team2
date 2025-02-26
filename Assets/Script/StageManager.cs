using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public int DungeonLevel;
    public int StageLevel;
    public int MaxMonster;

    public GameObject Map;
    public Sprite[] MapSprite;
    public GameObject[] Monsters;

    public GameObject Portal;

    GameObject Player;
    SpriteRenderer MapSpriteRenderer;

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
        MapSpriteRenderer = Map.GetComponent<SpriteRenderer>();
        Player = GameObject.FindWithTag("Player");
        Portal.SetActive(false);
        InsMap();
        SpawnMonster();
    }

    private void LateUpdate()
    {
        GameObject[] _monsterList = GameObject.FindGameObjectsWithTag("Monster");
        if (_monsterList.Length <= 0)
        {
            if (StageLevel <= 10)
            {
                EndGame();
            }
            else
            {
                EndGame();
            }
        }
    }
    void InsMap()
    {
        switch(DungeonLevel)
        {
            case 1:
                MapSpriteRenderer.sprite = MapSprite[Random.Range(0, 3)];
                break;

            case 2:
                MapSpriteRenderer.sprite = MapSprite[Random.Range(0, 3)];
                break;

            case 3:
                MapSpriteRenderer.sprite = MapSprite[Random.Range(0, 3)];
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
        for (int i =0; i< MaxMonster; i++)
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
        Player.GetComponent<PlayerCtrl>().GetExp();
        Portal.SetActive(true);
    }
    public void Upstage()
    {
        StageLevel++;
        SpawnMonster();
    }
    void ExitDungeon()
    {
        if (StageLevel >10)
        {
            //게임 승리 처리, 승리 패널 켜기
        }
        else
        {
            //게임 패배 처리, 패배 패널 켜기
        }
    }
}
