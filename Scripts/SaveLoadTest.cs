using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadTest : MonoBehaviour
{
    public string m_FileName;

    public int m_Lives = 5;

    public void Save()
    {
        PlayerData data = new PlayerData();
        data.position[0] = transform.position.x;
        data.position[1] = transform.position.y;
        data.position[2] = transform.position.z;
        data.lives = m_Lives;

        PersistenceFile.Save<PlayerData>(data, m_FileName);
    }

    public void Load()
    {
        PlayerData data = PersistenceFile.Load<PlayerData>(m_FileName);

        transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);
        m_Lives = data.lives;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            Save();
        }
        if(Input.GetKey(KeyCode.L))
        {
            Load();
        }
    }
}
