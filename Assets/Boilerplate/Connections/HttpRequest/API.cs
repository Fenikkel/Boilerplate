using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// https://youtu.be/UUQydC0IimI

// Lol API -> https://developer.riotgames.com/apis
// Lol temp Api key at -> https://developer.riotgames.com/
// REMEMBER TO UPDATE THE KEY!
public class API : MonoBehaviour
{
    public Text resposeText;

    private const string URL = "www.google.com";
    private const string FREECHAMP_ENDPOINT = "https://euw1.api.riotgames.com/lol/platform/v3/champion-rotations";
    private const string API_KEY = "RGAPI-1b4973bd-cc49-4833-b9cf-6711ea3412ae"; // DON'T SHARE PLEASE -> Permanent Key from app https://play.google.com/store/apps/details?id=com.al286752.fenikkel.leagueoffenikkel&gl=ES
    

    public void PostRequest() //Post request with Headers
    {
        /* Headers (key, value) */
        WWWForm form = new WWWForm();

        Dictionary<string, string> headers = form.headers; // get the existing headers
        headers["X-Riot-Token"] = API_KEY; //Add new field in headers

        /* Post fields */
        form.AddField("username", "password");
        byte[] rawFormData = form.data;


        WWW request = new WWW(FREECHAMP_ENDPOINT, rawFormData, headers);
        StartCoroutine(OnResponse(request));
    }

    public void GetRequest()  // Get request with headers
    {
        //Headers (key, value)
        WWWForm form = new WWWForm();

        Dictionary<string, string> headers = form.headers; // get the existing headers
        headers["X-Riot-Token"] = API_KEY;

        //Get request (it detects automatically that you dont have post parameters so it makes a Get request)
        WWW request = new WWW(FREECHAMP_ENDPOINT, null, headers); //Add parameters at the end of the EndPoint
        StartCoroutine(OnResponse(request));
    }

    public void WebRequest() // Simple web request
    {
        WWW request = new WWW(URL);
        StartCoroutine(OnResponse(request));
    }

    private IEnumerator OnResponse(WWW req) 
    {
        yield return req;

        resposeText.text = req.text;
    }

}
