using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [Header("- StartPnl")]
    [SerializeField] private GameObject startPnl;

    [Header("- GamePnl")]
    [SerializeField] private GameObject gamePnl;
    [SerializeField] private TMP_Text gasTxt;

    [Header("- EndPnl")]
    [SerializeField] private GameObject endPnl;

    [Header("- Preferences")]
    public float gas;
    [SerializeField] private float gasConsumptionRate;
    [SerializeField] private bool isGameRunning = false;

    [Space(10), SerializeField] private GameObject gasObj;

    private void Start()
    {
        ShowStartPnl();
    }

    private void Update()
    {
        if (isGameRunning)
        {
            HandleGas();
            UpdateGasDisplay();
        }
    }

    private void ShowStartPnl()
    {
        startPnl.SetActive(true);
        gamePnl.SetActive(false);
        endPnl.SetActive(false);
    }

    public void StartGame()
    {
        startPnl.SetActive(false);
        gamePnl.SetActive(true);
        isGameRunning = true;

        StartCoroutine(SpawnGasItem());
    }

    private void EndGame()
    {
        StopCoroutine(SpawnGasItem());

        isGameRunning = false;
        gamePnl.SetActive(false);
        endPnl.SetActive(true);
    }

    private void HandleGas()
    {
        gas -= gasConsumptionRate * Time.deltaTime;

        if (gas <= 0)
        {
            gas = 0;
            EndGame();
        }
    }

    private void UpdateGasDisplay()
    {
        gasTxt.text = "Gas: " + gas.ToString("F1");
    }

    private IEnumerator SpawnGasItem()
    {
        while (isGameRunning)
        {
            Vector3 spawnPosition = new(Random.Range(-2, 2), 10, 0);
            Instantiate(gasObj, spawnPosition, gasObj.transform.rotation);

            yield return new WaitForSeconds(3f);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
