using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardModel : MonoBehaviour
{
    // SpriteRendererクラスを参照します。
    //①（Cardmodelクラスが直接アタッチされているオブジェクトのクラスを参照）

    SpriteRenderer spriteRenderer;

    public Sprite[] faces;
    public Sprite cardBack;
    public int cardIndex; // faces[cardIndex];

    public void ToggleFace(bool showFace)
    {


        if (showFace)
        {
            // 表表示
            //unity側で設定したfacesとcardBackから呼び出し描画
            spriteRenderer.sprite = faces[cardIndex];
        }
        else
        {
            //裏表示
            spriteRenderer.sprite = cardBack;

        }
    }

    void Awake() 
    {
        //ゲームが始まる前の初期化
        //このスクリプトがアタッチされているオブジェクトのインスペクター上のspriteRendererを取得します。
        //①とセット。
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
