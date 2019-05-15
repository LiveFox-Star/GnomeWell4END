using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//InputManagerを使用して、左右方向の力をオブジェクトに適応する
//これでノームを左右に揺らす
public class Swinging : MonoBehaviour{

	//どのくらい揺らすか？数値が大きいほど大きく振れる
	public float swingSensitivity = 100.0f;

	//物理エンジンの処理をましにするため、Updateの代わりにFixedUpdateを使う
	void FixedUpdate() {

		//もし、もうリジッドボディを持っていないならコンポーネントを破棄する
		if (GetComponent<Rigidbody2D>() == null) {
			Destroy (this);
			return;
		}

		//傾きの度合いをInputManagerから取得する
		float swing = InputManager.instance.sidewaysMotion;

		//適応する力を計算する
		Vector2 force =
			new Vector2(swing * swingSensitivity, 0);

		//力を適応する
		GetComponent<Rigidbody2D>().AddForce(force);
	}
}