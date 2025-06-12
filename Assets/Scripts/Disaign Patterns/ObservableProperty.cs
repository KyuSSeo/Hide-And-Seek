using UnityEngine;
using UnityEngine.Events;


//  점수, 시간 관리에 사용
public class ObservableProperty<T>
{
    //  저장 값
    [SerializeField] private T _value;
    //  외부 접근
    public T Value 
    { 
        get => _value; 
        set { 
            //  변경 여부 확인
            if (_value.Equals(value)) return; 
            //  변경 시 알림
            _value = value; Notify(); 
        } 
    }

    //  값 변경 시 호출 이벤트
    private UnityEvent<T> _onValueChanged = new();

    public ObservableProperty(T value = default)
    {
        _value = value;
    }
    //  이벤트 구독
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
    //  알림
    private void Notify()
    {
        _onValueChanged?.Invoke(Value);
    }
}

