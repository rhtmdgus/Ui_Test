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
	public bool gender; // 0 : Man, 1 : Woman
	public string id, pw, name;
	public int age, height, weight;
	public UserData() { }
	public UserData(string id, string pw,string name, int age, int height,int weight, bool gender)
	{
		this.id = id;
		this.pw = pw;
		this.name = name;
		this.age = age;
		this.height = height;
		this.weight = weight;
		this.gender = gender;
	}
}