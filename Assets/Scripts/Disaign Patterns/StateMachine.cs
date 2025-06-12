using System.Collections;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    protected State _currentState;

    // 상태 전환 중인지 여부
    protected bool _inTransition;

    // 현재 상태 접근자
    public virtual State CurrentState
    {
        get { return _currentState; }
        set { Transition(value); }
    }

    public virtual T GetState<T>() where T : State
    {
        T target = GetComponent<T>();
        if (target == null)
            target = gameObject.AddComponent<T>();
        return target;
    }

    // 상태를 전환
    public virtual void ChangeState<T>() where T : State
    {
        CurrentState = GetState<T>();  // 지정된 상태로 전환
    }

    // 상태 전환
    protected virtual void Transition(State value)
    {
        // 현재 상태와 같거나 전환 중이면 무시
        if (_currentState == value || _inTransition)
            return;

        _inTransition = true;

        // 기존 상태 종료
        if (_currentState != null)
            _currentState.Exit();

        // 새 상태
        _currentState = value;

        // 새 상태 진입
        if (_currentState != null)
            _currentState.Enter();

        _inTransition = false;
    }
}