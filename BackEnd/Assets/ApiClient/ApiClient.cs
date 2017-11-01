using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ApiClient : MonoBehaviour
{
	public Text name;
	public Text description;
	public Text race;
	public Text age;

	const string baseUrl = "http://localhost:58728/API";

	// Use this for initialization
	void Start()
	{
		//StartCoroutine(PostCharacterApiAsync());
		StartCoroutine(GetCharactersApiAsync());
	}

	private IEnumerator PostCharacterApiAsync()
	{
		WWWForm form = new WWWForm();

		form.AddField("Id", "Id test 2");
		form.AddField("Name", "ItemFromUnity 2");
		form.AddField("Description", "Item enviado por POST para Unity3d (2)");
		form.AddField("Race", "50");
		form.AddField("Age", "9");

		using (UnityWebRequest request = UnityWebRequest.Post(baseUrl + "/Characters", form))
		{
			// obsoleto (Unity 2017.1)
			yield return request.Send();

			// (Unity 2017.2)
			//yield return request.SendWebRequest();


			if (request.isNetworkError || request.isHttpError)
			{
				Debug.Log(request.error);
			}
			else
			{
				Debug.Log("Envio do item efetuado com sucesso");
			}

		}
	}

	IEnumerator GetCharactersApiAsync()
	{
		UnityWebRequest request = UnityWebRequest.Get(baseUrl + "/Characters");

		// obsoleto (Unity 2017.1)
		yield return request.Send();

		// (Unity 2017.2)
		//yield return request.SendWebRequest();

		if (request.isNetworkError || request.isHttpError)
		{
			Debug.Log(request.error);
		}
		else
		{
			string response = request.downloadHandler.text;
			Debug.Log(response);

			byte[] bytes = request.downloadHandler.data;

			Character[] characters = JsonHelper.getJsonArray<Character>(response);

			foreach (Character i in characters)
			{
				PrintCharacter(i);
			}

		}
	}

	private void PrintCharacter(Character i)
	{
		Debug.Log("======= Character Data ==========");

		Debug.Log("Id: " + i.CharacterID);

		Debug.Log("Name: " + i.Name);
		name.text = i.Name;

		Debug.Log("Description: " + i.Description);
		description.text = i.Description;

		Debug.Log("Race: " + i.Race);
		race.text = i.Race;

		Debug.Log("Age: " + i.Age);
		age.text = i.Age.ToString();
	}
}