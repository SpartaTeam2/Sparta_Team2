using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DungeonLevelTXTUI : MonoBehaviour
{
    public StageManager _stageManager;
    public TextMeshProUGUI TXTArea;

    private void LateUpdate()
    {
        if (_stageManager._monsterList!= null)
        {
            TXTArea.GetComponent<TextMeshProUGUI>().text = $"{_stageManager.DungeonLevel} 던전 {_stageManager.StageLevel} 스테이지\n남은 몬스터 수 :  {_stageManager?._monsterList.Length}/{_stageManager.MaxMonster}";
        }
    }
}
