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
            TXTArea.GetComponent<TextMeshProUGUI>().text = $"{_stageManager.DungeonLevel} ���� {_stageManager.StageLevel} ��������\n���� ���� �� :  {_stageManager?._monsterList.Length}/{_stageManager.MaxMonster}";
        }
    }
}
