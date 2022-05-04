using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance;
    [SerializeField] private Cell CellPrefab;
    [SerializeField] private Player PlayerPrefab;
    public LayerMask mascara;
    private Grid grid;
    private Player player;
    [SerializeField]
    private float moveSpeed = 2f;

    [SerializeField] private TMP_Text timerText;
    private float timeElapsed;
    private int min, sec, cen;
    //funcion update

    void Update()
    {
        timeElapsed += Time.deltaTime;
        min = (int)(timeElapsed / 60f);
        sec = (int)(timeElapsed - min * 60f);
        cen = (int)((timeElapsed - (int)timeElapsed) * 100f);

        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", min, sec, cen);
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        grid = new Grid(10, 10, 1, CellPrefab, mascara);

        player = Instantiate(PlayerPrefab, new Vector2(9, 9), Quaternion.identity);  
    }

    public void CellMouseClick(int x, int y)
    {
        List<Cell> path = PathManager.Instance.FindPath(grid, (int)player.GetPosition.x, (int)player.GetPosition.y, x, y);

        player.SetPath(path);
    }

}
