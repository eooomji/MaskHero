using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;
public class ResultNameInput : MonoBehaviour
{
    public Text message;
    public static string nickname; 

    public Text warnTxt;
    public InputField inputField;
    public Button button;

    public AudioSource nextBtnA;

    Regex regex = new Regex(@"^[0-9a-zA-Z��-�R]*$");
    Regex Jregex = new Regex(@"[��-����-��]");

    void Start()
    {
        SetFunction_UI();
    }

    public void NextBtn()
    {
        nextBtnA.Play();
        if (regex.IsMatch(message.text) && !Jregex.IsMatch(message.text)) {
            if (message.text.Length >= 2 && message.text.Length <= 12)
            {
                nickname = message.text.ToString();
                // Debug.LogError(nickname);
                SceneManager.LoadScene(3);
            }
            else
            {
                warnTxt.text = "���̸� 2~12�ڷ� �������ּ���!";
                warnTxt.color = Color.blue;
            }
        }
        else
        {
            if (!(message.text.Length >= 2 && message.text.Length <= 12)) warnTxt.text = "���̸� 2~12�ڷ� �������ּ���!";
            else if (Jregex.IsMatch(message.text)) warnTxt.text = "�ùٸ� �ѱ��� �Է����ּ���.";
            else warnTxt.text = "Ư�� ���ڸ� �������ּ���!";
            warnTxt.color = Color.blue;
        }
    }

    private void SetFunction_UI()
    {
        ResetFunction_UI();

        inputField.onValueChanged.AddListener(Function_InputField);
        inputField.onEndEdit.AddListener(Function_InputField_EndEdit);
    }
    
    private void Function_InputField(string _data) // ���� ��
    {
        string txt = _data;
        message.text = _data;
        Debug.Log("InputField Typing!\n" + _data);
    }
    private void Function_InputField_EndEdit(string _data) // ���� ��
    {
        string txt = _data;
        message.text = _data;
        Debug.Log("InputField EndEdit!\n" + _data);
    }

    private void ResetFunction_UI()
    {
        button.onClick.RemoveAllListeners();
        inputField.placeholder.GetComponent<Text>().text = "�г���";
        inputField.onValueChanged.RemoveAllListeners();
        inputField.onEndEdit.RemoveAllListeners();
        inputField.contentType = InputField.ContentType.Standard;
        inputField.lineType = InputField.LineType.MultiLineNewline;

    }
}
