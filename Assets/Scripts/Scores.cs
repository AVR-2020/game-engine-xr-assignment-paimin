using System.Net;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Http;
using System.Text;

public sealed class Scores
{
    private static readonly Scores  instance = new Scores();
    static Scores()
    {

    }
    private Scores()
    {}
    public static Scores Instance
    {
        get
        {
            return instance;
        }
    }

    [Serializable]
    public class Score
    {
        public int id;
        public string name;
        public double value_score;
    }
    [Serializable]
    public class ScoreList
    {
        public List<Score> scores;
    }
    public void PostScore(String name, double Score)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:3000/score");
        var postData = "name=" + name;
        postData += "&value_score=" + Score;
        var data = Encoding.ASCII.GetBytes(postData);

        request.Method = "POST";
        request.ContentType = "application/x-www-form-urlencoded";
        request.ContentLength = data.Length;
        using (var stream = request.GetRequestStream())
        {
            stream.Write(data, 0, data.Length);
        }
        var response = (HttpWebResponse)request.GetResponse();
        var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
        Debug.Log(responseString);
    }
    public ScoreList GetScore()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:3000/score");
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();
        ScoreList info = JsonUtility.FromJson<ScoreList>(jsonResponse);
        return info;
    }
}
