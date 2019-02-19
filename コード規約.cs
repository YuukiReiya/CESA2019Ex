using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//コード規約について説明する
//詳細は:http://unitygeek.hatenablog.com/entry/2017/04/13/130343 を参考

/*
 * パスカルケースとは
 * 複合語の先頭を、大文字で書き始める。
 * 例）GetInputReader
 * 
 * キャメルケースとは
 * 複合語の先頭を、小文字で書き始める。
 * 例）getInputReader
 * 
 * スネークケースとは
 * アンダースコア（_）を区切記号として単語をつなげる。
 * 例）quoted_printable_encode
 * 
 * システムハンガリアンケースとは
 * 接頭字をアンダースコア(_)で始める。
 * 例）_hoge ← システムハンガリアン + キャメルケース
*/

/*
 * まとめ （名前）
 * 
 * 名前はそれが何か分かるように命名する
 * 
 * 名前空間　は　Scene名.機能名 もしくは 機能名 でパスカルケース(ブランド名固有の記法がある場合、そちらを優先)
 * 例) × title.sample 〇 Title.Sample ，× Ui 〇 UI ，× Api 〇 API etc...
 * 
 * クラス名　は　パスカルケース
 * メンバ名　は　キャメルケース
 * 定数　　　は　すべて大文字のスネークケース
 * プロパティは　パスカルケース
 * enum名　　は　パスカルケース
 * enumの中　は　すべて大文字
 * 関数名　　は　パスカルケース
 * /
 
/*　
 *　まとめ　（細かな）
 *　
 *クラスは名前空間を使って名前修飾する(namespaceに含める)
 * private は明示的に宣言する
 * メンバ変数を使うときはthis.を使う
 * 
 */

/* 
 * まとめ　（unity）
 * private , protectedな値をインスペクター上で変更できるようにする　 [SerializeField]を書く
 * ※[SerializeField]やpublicは極力控え、インスペクターが分かりにくくなることを防ぐ。
 * 
*/

//96行目からunity用のサンプルコード

//以下サンプルコード

//名前はそれが何か分かるように命名する


namespace Sample.Hoge //Scene名.機能名
{
    public class TestClass  //クラス名はパスカルケース
    {
        //メンバ変数にpublicは使わないこと
        //private は明示的に宣言する

        //メンバ名はシステムキャメルケース
        private int _moveSpeed;

        //定数はpublicを使ってもよい
        //定数はすべて大文字のスネークケース
        public const int MAX_MOVE_SPEED = 10;

        //enum名はパスカルケース
        private enum Youbi
        {
            //中はすべて大文字
            MONDAY, TUSEDAY, WEDNESDAY   //...
        }

        //関数名はパスカルケース
        public void SetMoveSpeed(int moveSpeed)
        {
            //メンバ変数を使うときはthis.を使う
            this._moveSpeed = moveSpeed;
        }

        public TestClass()
        {

        }
    }
}