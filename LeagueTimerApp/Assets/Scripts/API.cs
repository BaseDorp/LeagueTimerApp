using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class API : MonoBehaviour
{
    private const string ChampionEndpoint = "https://na1.api.riotgames.com/lol/summoner/v4/summoners/by-name/";
    private const string APIKey = "RGAPI-f396e752-33a4-46ff-a8d5-8b12f4b04f24";

    public void Request()
    {
        WWWForm form = new WWWForm();

        Dictionary<string, string> headers = form.headers;
        headers["X-Riot-Token"] = APIKey;

        WWW request = new WWW(ChampionEndpoint, null, headers);
        StartCoroutine(OnResponse(request));
    }

    private IEnumerator OnResponse(WWW req)
    {
        yield return req;
    }
}
