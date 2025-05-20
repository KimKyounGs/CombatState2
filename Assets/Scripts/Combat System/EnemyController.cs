using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

// EnemyController
//    └─ StateMachine<EnemyController>
//          ├─ IdleState : State<EnemyController>
//          ├─ ChaseState : State<EnemyController>


public enum EnemyStates { Idle, Chase }
public class EnemyController : MonoBehaviour
{
    public StateMachine<EnemyController> StateMachine { get; private set; }

    Dictionary<EnemyStates, State<EnemyController>> stateDict;


    private void Start()
    {
        stateDict = new Dictionary<EnemyStates, State<EnemyController>>();
        stateDict[EnemyStates.Idle] = GetComponent<IdleState>();
        stateDict[EnemyStates.Chase] = GetComponent<ChaseState>();

        StateMachine = new StateMachine<EnemyController>(this);
        StateMachine.ChanageState(stateDict[EnemyStates.Idle]);
    }

    void Update()
    {
        StateMachine.Execute();
    }

    public void ChangeState(EnemyStates state)
    {
        StateMachine.ChanageState(stateDict[state]);
    }

}
