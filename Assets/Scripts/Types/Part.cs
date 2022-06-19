using UnityEngine;
using UnityEngine.UI;

public class Part : MonoBehaviour
{
    private int _value;
    private float _angle;
    public Text Display => GetComponent<Text>();

    public int Value
    {
        get { return _value; }
        set
        {
            _value = value;
            Display.text = _value.ToString();
        }
    }

    public float Angle
    {
        set { _angle = value; }
        get { return _angle; }
    }
}