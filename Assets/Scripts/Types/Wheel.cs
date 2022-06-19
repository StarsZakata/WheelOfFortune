using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Wheel : MonoBehaviour
{
    public List<AnimationCurve> AnimCurves;

    private Transform _transform;
    [SerializeField] private List<Part> PartsList;
    private float _anglePart;
    private bool _isSpin;
    private int[] _partValues = { 10, 100, 1000, 10000 };

    public UnityAction<int> WheelStoped;

    public void InitWheel()
    {
        _transform = transform;
        SearchAllPath();
        InitDataWheel();
    }

    public void StartSpinWheele()
    {
        if (!_isSpin) StartCoroutine(Spining());
    }

    private void InitDataWheel() {
        _isSpin = false;
        _anglePart = 360f / PartsList.Count;
        for (int i = 0; i < PartsList.Count; i++)
        {
            Part p = PartsList[i];
            p.Value = _partValues[Random.Range(0, _partValues.Length)];
            p.Angle = _anglePart * i;
        }
        _transform.eulerAngles = Vector3.zero;
    }

    private void SearchAllPath() { 
        for (int i = 0; i < _transform.childCount; i++)
        {
            if (_transform.GetChild(i).TryGetComponent(out Part part)) {
                PartsList.Add(part);
            }
        }
    }

    private IEnumerator Spining()
    {
        _isSpin = true;
        int randomTime = Random.Range(1, 4);

        //maxAngle - коеф. скорости
        float maxAngle = 360 * randomTime + (PartsList.Count * _anglePart);
        float timer = 0.0f;
        float startAngle = _transform.eulerAngles.z;

        maxAngle = maxAngle - startAngle;
        int indexAnimCurv = Random.Range(0, AnimCurves.Count);

        while (timer < 5 * randomTime)
        {
            float angle = maxAngle * AnimCurves[indexAnimCurv].Evaluate(timer / (randomTime * 5));
            _transform.eulerAngles = new Vector3(0.0f, 0.0f, angle + startAngle);
            timer += Time.deltaTime;
            yield return 0;
        }

        // относительно угла вычисляем ближайший Part
        float angleStop = _transform.eulerAngles.z;
        Part part = PartsList.OrderBy(v => Math.Abs(v.Angle - angleStop)).First();

        _isSpin = false;
        EventStopedWheel(part.Value);
    }

    private void EventStopedWheel(int scorePlayer)
    {
        Debug.Log(scorePlayer);
        StopAllCoroutines();
        WheelStoped.Invoke(scorePlayer);
    }
}
