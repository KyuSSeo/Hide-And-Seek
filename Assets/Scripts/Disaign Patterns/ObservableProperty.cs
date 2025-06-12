using UnityEngine;
using UnityEngine.Events;


//  ����, �ð� ������ ���
public class ObservableProperty<T>
{
    //  ���� ��
    [SerializeField] private T _value;
    //  �ܺ� ����
    public T Value 
    { 
        get => _value; 
        set { 
            //  ���� ���� Ȯ��
            if (_value.Equals(value)) return; 
            //  ���� �� �˸�
            _value = value; Notify(); 
        } 
    }

    //  �� ���� �� ȣ�� �̺�Ʈ
    private UnityEvent<T> _onValueChanged = new();

    public ObservableProperty(T value = default)
    {
        _value = value;
    }
    //  �̺�Ʈ ����
    public void Subscribe(UnityAction<T> action)
    {
        _onValueChanged.AddListener(action);
    }

    public void Unsubscribe(UnityAction<T> action)
    {
        _onValueChanged.RemoveListener(action);
    }

    public void UnsbscribeAll()
    {
        _onValueChanged.RemoveAllListeners();
    }
    //  �˸�
    private void Notify()
    {
        _onValueChanged?.Invoke(Value);
    }
}

