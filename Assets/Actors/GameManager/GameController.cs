using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject hazardPrefab;

    private bool gameOver = false;

    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnHazards());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnHazards()
    {
        var spawnAmount = Random.Range(1, 4);

        for (int i = 0; i < spawnAmount; i++)
        {
            CreateHazard();
        }

        yield return new WaitForSeconds(1f);

        if (gameOver == false)
        {
            yield return SpawnHazards();
        }
    }

    private void CreateHazard()
    {
        var x = Random.Range(-6, 7);
        var drag = Random.Range(0f, 2f);

        var hazard = Instantiate(hazardPrefab, new Vector3(x, 11, 0), Quaternion.identity);
        hazard.GetComponent<Rigidbody>().drag = drag;
    }

    public void RestartGame()
    {
        gameOver = true;
        FreezeHazards();
        StartCoroutine(ResetScene());
    }

    private void FreezeHazards()
    {
        Hazard[] hazards = FindObjectsOfType<Hazard>();
        foreach (Hazard hazard in hazards)
        {
            hazard.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    private IEnumerator ResetScene()
    {
        yield return new WaitForSecondsRealtime(1);

        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
