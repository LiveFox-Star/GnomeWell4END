using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//加速度センサーの値を左右方向に揺らすための情報に変換
public class InputManager : Singleton<InputManager> {

	//どれくらい移動しているか
	//-1.0は完全に左、+1.0は完全に右に表す
	private float _sidewaysMotion = 0.0f;

	//このプロパティーは読み取り専用で宣言されているので、
	//他のクラスはこれを変更できない
	public float sidewaysMotion {
		get {
			return _sidewaysMotion;
		}
	}

	//毎フレーム傾きを格納
	void Update () {
		Vector3 accel = Input.acceleration;

		_sidewaysMotion = accel.x;
		if (Input.GetKey(KeyCode.RightArrow)) _sidewaysMotion = 0.15f;
		if (Input.GetKey(KeyCode.LeftArrow)) _sidewaysMotion = -0.15f;
	}
}