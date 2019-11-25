using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    List<int> cards;

    public void Shuffle()
    {
        if (cards == null)
        {
            cards = new List<int>();
        }
        else
        {
            cards.Clear();
        }

        for (int i = 0; i < 52; i++)
        {
            cards.Add(i);
        }
        int n = cards.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1); //kは0~nのランダムな数字
            int temp = cards[k]; //k番目のカードをtempに代入する
            cards[k] = cards[n]; //k番目のインデックスにn番目のインデックスを代入
            cards[n] = temp;     //n番目のインデックスにtempを代入
        }
    }

    void Start()
    {
        Shuffle();
    }
}
