using System.Collections;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    protected State _currentState;

    // ���� ��ȯ ������ ����
    protected bool _inTransition;

    // ���� ���� ������
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

    // ���¸� ��ȯ
    public virtual void ChangeState<T>() where T : State
    {
        CurrentState = GetState<T>();  // ������ ���·� ��ȯ
    }

    // ���� ��ȯ
    protected virtual void Transition(State value)
    {
        // ���� ���¿� ���ų� ��ȯ ���̸� ����
        if (_currentState == value || _inTransition)
            return;

        _inTransition = true;

        // ���� ���� ����
        if (_currentState != null)
            _currentState.Exit();

        // �� ����
        _currentState = value;

        // �� ���� ����
        if (_currentState != null)
            _currentState.Enter();

        _inTransition = false;
    }
}