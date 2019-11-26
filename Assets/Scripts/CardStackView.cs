﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//同じGameObjectでアタッチされたコンポーネントをチェックして、それがないとビルドでエラーになるようにできます。
//このプログラムがアタッチ（付属）しているオブジェクトのCardDeckTestにコンポーネントのDeckがないとエラーを吐く
[RequireComponent(typeof(CardStack))]

public class CardStackView : MonoBehaviour
{
    CardStack deck; //参照
    List<int> fetchedCards; //取ったカード
    int lastCount; //最初のデッキの枚数

    public Vector3 start;
    public float cardOffset; //カードをずらす幅
    public GameObject cardPrefabs;

    private void Start()
    {
        fetchedCards = new List<int>();
        deck = GetComponent<CardStack>(); //Deckを参照しているよ
        ShowCards();
        lastCount = deck.CardCount; //デッキのカードの総数取得
    }

    private void Update()
    {
        //もし最後のアップデート時からデッキの枚数が変わっていた場合カードの表示
        if (lastCount != deck.CardCount)
        {
            lastCount = deck.CardCount;
            ShowCards();
        }
    }

    void ShowCards()
    {
        int cardCount = 0;

        //デッキが存在していたら
        if (deck.HasCards)
        {
            //foreachとyield return で随時カードを生成する
            foreach (int i in deck.GetCards())
            {
                float co = cardOffset * cardCount; //オフセット幅の計算
                Vector3 temp = start + new Vector3(co, 0f);
                AddCard(temp, i, cardCount);
                cardCount++;
            }
        }
        
    }

    void AddCard(Vector3 position, int cardIndex, int positionalIndex)
    {
        //すでにカードが表示されている場合何もしない
        if (fetchedCards.Contains(cardIndex))
        {
            return;
        }
        //カードプレファブのコピー
        GameObject cardCopy = (GameObject)Instantiate(cardPrefabs);

        cardCopy.transform.position = position;

        //コピーしたカードプレファブのCardModelクラスを取得
        CardModel cardModel = cardCopy.GetComponent<CardModel>();

        cardModel.cardIndex = cardIndex;
        //表表示
        cardModel.ToggleFace(true);

        //カードごとのレイヤーを変える
        //レイヤーの順序が大きいほど上に表示される
        SpriteRenderer spriteRenderer = cardCopy.GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = positionalIndex;

        //取得したカード番号を記憶
        fetchedCards.Add(cardIndex);
    }
}
