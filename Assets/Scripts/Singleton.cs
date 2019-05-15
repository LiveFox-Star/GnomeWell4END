using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//このクラスは他のオブジェクトが単一の共有オブジェクトを
//参照することを実現する。GameManagerクラスとinputManagerクラスが
//これを使用する

//これを使うためのサブクラスの宣言は以下のようになる
//public class MyManager : Singleton<MyManager> {  }

//そのあと、クラスの単一の共有インスタンスには以下のようにアクセスできる
//MyManager.instance.DoSomething();

public class Singleton<T> : MonoBehaviour
	where T : MonoBehaviour {

	//このクラスの単一のインスタンス
	private static T _instance;

	//アクセサリー。初めてこれが呼ばれたときに?instanceが準備される
	//適切なオブジェクトが見つからない場合にはエラーをログに出力する
	public static T instance {
		get {
			//もしまだ_instanceが準備されていないなら
			if (_instance == null)
			{
				//オブジェクトを探す
				_instance = FindObjectOfType<T>();

				//見つけられないときはログに出力する
				if (_instance == null) {
					Debug.LogError("Cant't fint " +
						typeof(T) + "!");
				}
			}

			//インスタンスが使えるのでリターンする！
			return _instance;
		}
	}
}