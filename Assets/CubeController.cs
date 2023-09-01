using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{

    // キューブの移動速度
    private float speed = -12;

    // 消滅位置
    private float deadLine = -10;

    // 地面の位置
    private float groundLevel = -3.0f;

    //AudioSourceコンポーネント取得用の変数
    private AudioSource soundEffect;

    //サウンドファイル読み込み用の変数
    public AudioClip sound;


    void Start ()
    {
        //AudioSourceコンポーネント取得
        soundEffect = GetComponent<AudioSource>(); 
    }

    void Update ()
    {
        // キューブを移動させる
        transform.Translate (this.speed * Time.deltaTime, 0, 0);

        // 画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy (gameObject);
        }
    }

    //衝突したとき
    void OnCollisionEnter2D (Collision2D collision)
    {
        //1回音を鳴らす
        //soundEffect.PlayOneShot(sound);

        //ユニティちゃんに当たった時は音量をゼロにする
        if (collision.gameObject.tag == "UnityChanTag")
        {
            GetComponent<AudioSource> ().volume = 0;
        }
        else
        {
            soundEffect.PlayOneShot(sound);
        }
    }
}