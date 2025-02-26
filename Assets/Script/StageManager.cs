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

    [SerializeField]
    GameObject _canvas;

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
        if ((_monsterList.Length <= 0)&&(Player))
        {
            if (StageLevel < 10)
            {
                EndGame();
            }
            else
            {
                SuccessDungeon();
            }
        }
        if (!Player)
        {
            FailedDungeon();
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
                MapSpriteRenderer.sprite = MapSprite[Random.Range(3, 6)];
                break;

            case 3:
                MapSpriteRenderer.sprite = MapSprite[Random.Range(6, 9)];
                break;

            default:
                MapSpriteRenderer.sprite = MapSprite[Random.Range(0, MapSprite.Length)];
                break;
        }
    }
    void SpawnMonster()
    {
        if (StageLevel %5 ==0)
        {
            _spawnType = SpawnType.Boss;
        }
        else
        {
            int SpawnTypeIndex = Random.Range(0, 2);
            switch (SpawnTypeIndex)
            {
                case 0:
                    _spawnType = SpawnType.Clean;
                    break;

                case 1:
                    _spawnType = SpawnType.Wave;
                    break;

                default:
                    Debug.Log("NoCase");
                    break;
            }
        }
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
        }
    }
    void InsWaveType()
    {
        for (int i = 0; i < MaxMonster; i++)
        {
            GameObject _insMons = Instantiate(GetComponent<MonsterManager>().MonsterArr[Random.Range(0, 3)], new Vector2(Random.Range(-3, 3), Random.Range(-3, 3)), Quaternion.identity);
        }
    }
    void InsBossType()
    {
        GameObject _insMons = Instantiate(GetComponent<MonsterManager>()._boss[Random.Range(0, 3)], Vector2.zero , Quaternion.identity);
    }
    void EndGame()
    {
        if(Player.GetComponent<PlayerCtrl>().canLvlUp)
            Player.GetComponent<PlayerCtrl>().GetExp();
        Portal.SetActive(true);
    }
    public void Upstage()
    {
        StageLevel++;
        SpawnMonster();
    }

    void SuccessDungeon()
    {
            _canvas.GetComponent<PanelUI>().GameClear();

    }
    void FailedDungeon()
    {
            _canvas.GetComponent<PanelUI>().GameOver();

    }
}
