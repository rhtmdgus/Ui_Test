using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class KeyboardScript : MonoBehaviour
{
    public TMP_Text tester;
    public TMP_InputField TextField;
    public GameObject KorLayout, KorLayoutBig, EngLayoutSml, EngLayoutBig, SymbLayout;

    private readonly string[] choseong = { "ㄱ", "ㄲ", "ㄴ", "ㄷ", "ㄸ", "ㄹ", "ㅁ", "ㅂ", "ㅃ", "ㅅ", "ㅆ", "ㅇ", "ㅈ", "ㅉ", "ㅊ", "ㅋ", "ㅌ", "ㅍ", "ㅎ" };
    private readonly string[] jungseong = { "ㅏ", "ㅐ", "ㅑ", "ㅒ", "ㅓ", "ㅔ", "ㅕ", "ㅖ", "ㅗ", "ㅘ", "ㅙ", "ㅚ", "ㅛ", "ㅜ", "ㅝ", "ㅞ", "ㅟ", "ㅠ", "ㅡ", "ㅢ", "ㅣ" };

    private readonly string[] jongseong = {
        "","ㄱ","ㄲ","ㄳ","ㄴ","ㄵ","ㄶ","ㄷ","ㄹ","ㄺ","ㄻ","ㄼ","ㄽ","ㄾ","ㄿ","ㅀ","ㅁ","ㅂ","ㅄ","ㅅ","ㅆ","ㅇ","ㅈ","ㅊ","ㅋ","ㅌ","ㅍ","ㅎ"
    };


    int HangulSub = 0;
    int[] sub = { 0,0, 0 };
    public void HangulFunction(string input)
    {
        if (HangulSub == 0)
        {
            int i = Array.IndexOf(choseong, input);
            tester.text += input;
            if (i >= 0)
            {
                sub[0] = i;
                HangulSub = 1;
            }
        }
        else if (HangulSub == 1)
        {
            int j = Array.IndexOf(jungseong, input);
            if (j >= 0)
            {
                tester.text = tester.text.Remove(tester.text.Length - 1);
                sub[1] = j;
                tester.text += (char)(0xAC00 + sub[0] * 588 + j * 28);
                HangulSub = 2;
            }
            else
            {
                tester.text += choseong[sub[0]];
                HangulSub = 0;
                HangulFunction(input); // 재시도
            }
        }
        else if (HangulSub == 2)
        {
            int k = Array.IndexOf(jungseong, input);

            char composed;
            bool DoubleMedial = false;

            if (sub[1] == 8)
            {
                if (k == 0) { sub[1] = 9;DoubleMedial = true; }
                else if (k == 1) {sub[1] = 10; DoubleMedial = true; }
                else if (k == 20){sub[1] = 11; DoubleMedial = true; }
            }
            else if (sub[1] == 13)
            {
                if (k == 4) {sub[1] = 14; DoubleMedial = true; }
                else if (k == 5) {sub[1] = 15; DoubleMedial = true;}
                else if (k == 20) {sub[1] = 16; DoubleMedial = true; }
            }
            else if (sub[1] == 18 && k == 20) {sub[1] = 19; DoubleMedial = true; }

            if (DoubleMedial)
            {
                tester.text = tester.text.Remove(tester.text.Length - 1);
                tester.text += (char)(0xAC00 + sub[0] * 588 + sub[1] * 28);
                return;
            }

            k = Array.IndexOf(jongseong, input);
            if (k >= 0)
            {
                HangulSub = 0;
                tester.text = tester.text.Remove(tester.text.Length - 1);
                sub[2] = k;
                composed = (char)(0xAC00 + sub[0] * 588 + sub[1] * 28 + sub[2]);
                tester.text += composed;
            }
            else
            {
                HangulSub = 0;
                HangulFunction(input); // 다음 글자 다시 시도
            }
        }
    }

    public void alphabetFunction(string alphabet)
    {
    }

    public void RegisterSelf(TMP_InputField sc)
    {
        TextField = sc;
    }

    public void BackSpace()
    {

        if(TextField.text.Length>0) TextField.text= TextField.text.Remove(TextField.text.Length-1);

    }

    public void CloseAllLayouts()
    {

        KorLayout.SetActive(false);
        KorLayoutBig.SetActive(false);
        EngLayoutSml.SetActive(false);
        EngLayoutBig.SetActive(false);
        SymbLayout.SetActive(false);

    }

    public void ShowLayout(GameObject SetLayout)
    {

        CloseAllLayouts();
        SetLayout.SetActive(true);

    }

}
