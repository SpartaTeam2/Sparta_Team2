using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBoss : MonoBehaviour
{
    // FSM
    protected BossFSM bossFSM;

    // Component
    protected Animator animator;
    protected Rigidbody2D rigidBody;

    // layerMask
    protected LayerMask playerLayer;

    // 보스 데이터
    // 체력, 공격력, 이동속도, 공격속도/딜레이, 

    private void Start()
    {
        bossFSM = new BossFSM(this);
    }

    private void Update()
    {
        bossFSM.Execute();

        //if(Input.GetKeyDown(KeyCode.Alpha1))
        //    bossFSM.ChangeState(BossState.Idle);
        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //    bossFSM.ChangeState(BossState.Tracking);
        //if (Input.GetKeyDown(KeyCode.Alpha3))
        //    bossFSM.ChangeState(BossState.Attack);
    }

    protected abstract void InitBoss();
}
