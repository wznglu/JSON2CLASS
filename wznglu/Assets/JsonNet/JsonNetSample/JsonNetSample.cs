using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
public class WorldConfig
{
    public Int32 WorldId { get; set; }
    public String WorldName { get; set; }
}
public class JsonNetSample : MonoBehaviour
{
    public Text Output;
    void Start()
    {
        WriteLine("\nStart!\n");
        Jsontext();
        WriteLine("\nDone!");
    }
    private void Jsontext()
    {
        List<WorldConfig> WorldConfigs;
        TextAsset ta = Resources.Load<TextAsset>("world");
        string jsStr = ta.text;
        Hashtable table = JsonConvert.DeserializeObject<Hashtable>(jsStr);
        object tempObj = table["worlds"];
        String tempObjStr = JsonConvert.SerializeObject(tempObj);
        WorldConfigs = JsonConvert.DeserializeObject<List<WorldConfig>>(tempObjStr);

        for (int i = 0; i < WorldConfigs.Count; i++)
        {
            WriteLine(WorldConfigs[i].WorldName);
        }
    }
  void WriteLine(string msg)
    {
        Output.text = Output.text + msg + "\n";
    }
}
