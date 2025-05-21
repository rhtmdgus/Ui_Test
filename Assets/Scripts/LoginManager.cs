using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
	[Header("Login Field")]
	[SerializeField] GameObject Login;
	[SerializeField] TMP_Text LoginID, LoginPW;

	[Header("Sign Field")]
	[SerializeField] GameObject Sign;
	[SerializeField] TMP_Text SignID, SignPW, SignName,SignAge,SignHeight,SignWeight;

	Users UserDatas;
	private void Awake()
	{
		string path = Path.Combine(Application.persistentDataPath,"User.json");
		if (File.Exists(path)) UserDatas = JsonConvert.DeserializeObject<Users>(File.ReadAllText(path));
		else UserDatas = new Users();
	}

	private void OnApplicationQuit()
	{
		string json = JsonConvert.SerializeObject(UserDatas);
		File.WriteAllText(Path.Combine(Application.persistentDataPath, "User.json"),json);
	}

	public void LoginAct()
	{
		foreach (var j in UserDatas.User) if (j.id.Equals(LoginID.text)) 
			{
				// Login
				return;
			}

		// Error
	}

	public void CompleteSignup()
	{

		foreach(var s in UserDatas.User) if(SignID.text.Equals(s.id))
			{
				//ShowWarning("이미 가입된 아이디입니다.");
				return;
			}
		UserDatas.User.Add(new UserData(SignID.text, SignPW.text, SignName.text, int.Parse(SignAge.text),int.Parse(SignHeight.text),int.Parse(SignWeight.text)));
	}


	[SerializeField] List<Image> GenderImages;
	[SerializeField] List<TMP_Text> GenderTexts;
	Color GenderColor = new Color(0.1725f, 0.1725f, 0.1725f), GenderColor2 = new Color(0.3f,0.3f,0.3f);
	bool CurMan;
	public void GenderToggle(bool IsMan)
	{
		CurMan = IsMan;
		if (IsMan)
		{
			GenderImages[0].color = GenderColor2; GenderImages[1].color = Color.gray; GenderTexts[0].color = Color.gray;
			GenderImages[2].color = GenderColor; GenderImages[3].color = Color.white; GenderTexts[1].color = Color.white;
		}
		else
		{
            GenderImages[2].color = GenderColor2; GenderImages[3].color = Color.gray; GenderTexts[1].color = Color.gray;
            GenderImages[0].color = GenderColor; GenderImages[1].color = Color.white; GenderTexts[0].color = Color.white;
        }
	}

}

