using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


//Common script for buttons, triggers the desired event when it´s pushed. Nothing needs to be modified


public class Physicsbutton : MonoBehaviour
{
    [SerializeField] private float threshold = .1f;
    [SerializeField] private float deadZone = .025f;
    private bool _isPressed;
    private Vector3 _startPos;
    private ConfigurableJoint _joint;
    public UnityEvent onPressed, onReleased;

    void Start()
    {
        _startPos = transform.localPosition;
        _joint = GetComponent<ConfigurableJoint>();
    }

    void Update()
    {
        if (!_isPressed && GetValue() + threshold >= 1)
            Pressed();
        if (_isPressed && GetValue() - threshold <= 0)
            Released();
    }

    private float GetValue() 
    {
        var value = Vector3.Distance(_startPos, transform.localPosition) / _joint.linearLimit.limit;//Calcula distancia entre dos punts

        if (Mathf.Abs(value) < deadZone)
            value = 0;
        return Mathf.Clamp(value,  -1f, 1f);
   
    }

    private void Pressed()
    {
        //Aqui ficar aqccio que vull que passi quan estigui presionat
        _isPressed = true;
        onPressed.Invoke();
   
        Debug.Log("Pressed");
    }

    private void Released()
    {

        _isPressed = false;
        onReleased.Invoke();
        Debug.Log("Released");
    }

}
