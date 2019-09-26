using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPointManager : MonoBehaviour
{
    public static CheckPointManager Instance { get; set; }

    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    public Vector3 Position { get; set; }

    private void Start()
    {
        //PlayerPrefs.DeleteKey("check_point");

        if (PlayerPrefs.HasKey("check_point"))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            string json = PlayerPrefs.GetString("check_point");
            player.transform.position = JsonUtility.FromJson<Vector3>(json);
        }
        else
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Position = player.transform.position;
        }
    }

    public void Respawn(GameObject other, float delay)
    {
        StopAllCoroutines();
        StartCoroutine(RespawnTime(other, delay));
    }

    public IEnumerator RespawnTime(GameObject other, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Instantiate(other, Position, Quaternion.identity);
        //Destroy(other);
    }
}
