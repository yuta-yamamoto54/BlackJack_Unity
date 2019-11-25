using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugChangeCard : MonoBehaviour
{
    CardFlipper flipper;
    //CardModelクラスの参照
    CardModel cardModel;
    int cardIndex = 0;

    public GameObject card;

    void Awake()
    {
        //cardにアタッチされているCardModelを取得
        cardModel = card.GetComponent<CardModel>();
        flipper = card.GetComponent<CardFlipper>();
    }

    void OnGUI()
    {
        //Hit meと書かれているボタンを作って押されたら実行
        if (GUI.Button(new Rect(10, 10, 100, 20),"Hit me!!"))
        {
            //もし最後までカードをめくり切ったら裏面を表示する
            if (cardIndex >= cardModel.faces.Length)
            {
                cardIndex = 0;
                flipper.FlipCard(cardModel.faces[cardModel.faces.Length - 1], cardModel.cardBack, -1);
            }
            else
            {
                //前のカードから次のカードに
                if (cardIndex > 0)
                {
                    flipper.FlipCard(cardModel.faces[cardIndex - 1], cardModel.faces[cardIndex], cardIndex);
                }
                //カードの裏面から初めのカードに
                else
                {
                    flipper.FlipCard(cardModel.cardBack, cardModel.faces[cardIndex], cardIndex);
                }
                cardIndex++;
            }

        }
    }
}
