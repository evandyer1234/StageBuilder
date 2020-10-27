using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public static Manager instance;
    SaveData SD;
    public List<GameObject> objectlist;
    public List<GameObject> SpawnPrefab;
    MakeList ml;
    public string file;
    public PlayerSpawn ps;
    public bool play = false;

    void Start()
    {
        ml = GetComponent<MakeList>();
        if (File.Exists(PlayerPrefs.GetString("Level", "None")))
        {
            file = PlayerPrefs.GetString("Level", "None");
        }
        else
        {
            file = "savedata.xml";
        }
        LoadTheData();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene(0);
        }
    }
    void Awake()
    {
        instance = this;
    }
    public void SaveTheData()
    {
        file = PlayerPrefs.GetString("Level", "None");
        SD = new SaveData();
        ml.addobjects();
        foreach (GameObject o in objectlist)
        {
            placeable od = o.GetComponent<placeable>();
            if (od && o.tag != "ghost")
            {
                SD.AddData(od.codex, od.Location, od.Rot);
            }
            Debug.Log(SD.DataStructList.Count);

        }
        string filename = file;

        XmlSerializer x = new XmlSerializer(typeof(SaveData));
        TextWriter writer = new StreamWriter(filename);
        x.Serialize(writer, SD);
        writer.Close();
        Debug.Log("Save Data!");
    }
    public void LoadTheData()
    {
        if (objectlist.Count != 0)
        {
            foreach (GameObject o in objectlist)
            {
                Destroy(o);
            }
            objectlist.Clear();
        }

        SD = new SaveData();

        if (File.Exists(PlayerPrefs.GetString("Level", "None")))
        {
            file = PlayerPrefs.GetString("Level", "None");
        }
        else
        {
            file = "savedata.xml";
        }

        if (File.Exists(file))
        {
            XmlSerializer x = new XmlSerializer(typeof(SaveData));
            FileStream myFileStream = new FileStream(file, FileMode.Open);
            SD = (SaveData)x.Deserialize(myFileStream);
            myFileStream.Close();
            foreach (DataStruct od in SD.DataStructList)
            {
                
                GameObject newGO = Instantiate(SpawnPrefab[od.number], od.Location, od.Rot);
                placeable nOD = newGO.GetComponent<placeable>();
                nOD.codex = od.number;
                nOD.Location = od.Location;               
                nOD.Rot = od.Rot;
                objectlist.Add(newGO);
                PlayerSpawn p = newGO.GetComponent<PlayerSpawn>();
                if (p != null)
                {
                    ps = p;
                    if (play)
                    {
                        ps.Play = true;
                    }
                }
            }
            foreach (GameObject od in objectlist)
            {
                
                if (od.transform.position.y < ps.bottom)
                {
                    ps.bottom = od.transform.position.y;
                }
            }
        }
        else
        {
            Debug.Log("Failed to find file");
        }
    }
}
