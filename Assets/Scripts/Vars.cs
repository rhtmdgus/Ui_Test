using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Users 
{
	[SerializeField]
	public List<UserData> User;
	public Users()
	{
		User = new List<UserData>();
	}
}


[System.Serializable]
public class UserData
{
	public string id, pw, name;
	public int age, height, weight;
	public UserData() { }
	public UserData(string id, string pw,string name, int age, int height,int weight)
	{
		this.id = id;
		this.pw = pw;
		this.name = name;
		this.age = age;
		this.height = height;
		this.weight = weight;
	}
}