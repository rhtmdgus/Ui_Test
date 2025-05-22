using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldRegister : MonoBehaviour
{

    [Header("Num, Eng, Han, Spec")]
    [SerializeField]
    public List<bool> LanSupport;
    // Num, Eng, Han, Spec
    [SerializeField]
    public int MaxNum;
    TMP_InputField Field;

    private void Awake()
    {
        Field = GetComponent<TMP_InputField>();
        //Field.onSelect.AddListener((_) => Field.ActivateInputField());
        Field.onSelect.AddListener(OnSelect);
        //Field.onDeselect.AddListener(OnDeSelect);
        Field.onValueChanged.AddListener(OnValueChange);
        //Field.onSubmit.AddListener(OnSubmit);
    }

    public void OnSelect(string _)
    {
        KeyboardScript.keyboard.RegisterSelf(Field, LanSupport);
        KeyboardScript.keyboard.gameObject.SetActive(true);
    }
    /*public void OnDeSelect(string _)
    {
        KeyboardScript.keyboard.RegisterSelf(null);
        KeyboardScript.keyboard.gameObject.SetActive(false);
    }*/

    public void OnValueChange(string value)
    {
        //if (Field.text.Length > MaxNum) Field.text = Field.text.Remove(MaxNum);
    }


}
