using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class API : MonoBehaviour
{
    private const string ChampionEndpoint = "https://na1.api.riotgames.com/lol/status/v3/shard-data?api_key=RGAPI-56d63040-549d-44c8-beb0-d93fe6feb2ea";
    private const string APIKey = "RGAPI-56d63040-549d-44c8-beb0-d93fe6feb2ea";
    public Text returnText;

    string username;

    public void Start()
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

        returnText.text = req.text;
    }
}
