using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PointInTime

{
	public float time;
	public Vector3 position;
	public Quaternion rotation;

	public PointInTime(float _time, Vector3 _position, Quaternion _rotation)
    {
		time = _time;
		position = _position;
		rotation = _rotation; 
    }


}
