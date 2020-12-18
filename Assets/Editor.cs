using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Editor : MonoBehaviour
{
    [SerializeField]
    private Transform move;
    [SerializeField]
    private Transform select;
    [SerializeField]
    private Transform spriteParent;
    [SerializeField]
    private Transform prefabParent;
    public int curID;
    public Vector2Int levelSize;
    public Sprite[] sprites;
    public GameObject[] prefabs;
    private SpriteRenderer[,] grid;
    private int[,] spawnGrid;
    public Vector2Int launchPos;
    public Vector2Int[] paintPos;
    // Start is called before the first frame update
    void Start()
    {
        ChangeImg(curID);
        grid = new SpriteRenderer[levelSize.x, levelSize.y];
        spawnGrid = new int[levelSize.x, levelSize.y];
        levelSize -= Vector2Int.one;
    }

    void Update()
    {
        move.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        move.position = (Vector2)move.position;
        //Vector2Int closestGrid = new Vector2Int(Mathf.RoundToInt(move.position.x), Mathf.RoundToInt(move.position.y));
        Vector2Int closestGrid = Vector2Int.RoundToInt(move.position);
        select.position = (Vector2)closestGrid;
        closestGrid += levelSize/2;
        if (InBounds(closestGrid))
        {
            select.gameObject.SetActive(!grid[closestGrid.x, closestGrid.y]);

            if (Input.GetKey(KeyCode.Mouse0)) Place(curID, closestGrid.x, closestGrid.y);
            if (Input.GetKey(KeyCode.Mouse1)) Remove(closestGrid.x, closestGrid.y);
        }
        else select.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Place(int ID, int x, int y)
    {
        if(grid[x, y]) return;
        grid[x, y] = new GameObject("sprite",typeof(SpriteRenderer)).GetComponent<SpriteRenderer>();
        grid[x, y].transform.position = new Vector2(x, y) - levelSize/2;
        grid[x, y].transform.parent = spriteParent;
        grid[x,y].sprite = sprites[ID];
        spawnGrid[x, y] = ID+1;
    }
    void Remove(int x, int y)
    {
        if (!grid[x, y] || grid[x,y].sprite == sprites[0]) return;
        //if (!grid[x, y]) return; //although you can delete the paint, its funny so i think we should leave it in as a little easter egg.
        Destroy(grid[x, y].gameObject);
        grid[x, y] = null;
        spawnGrid[x, y] = 0;
    }
    public void ChangeImg(int ID)
    {
        move.GetComponent<SpriteRenderer>().sprite = sprites[ID];
        select.GetComponent<SpriteRenderer>().sprite = sprites[ID];
        curID = ID;
    }
    private bool InBounds(Vector2Int p)
    {
        if (Mathf.Clamp(p.x, 0, levelSize.x) == p.x && Mathf.Clamp(p.y, 0, levelSize.y) == p.y) return true;
        else return false;
    }
    public void SetTiles()
    {
        spriteParent.gameObject.SetActive(false);
        prefabParent = new GameObject().transform;
        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                if (grid[x, y] != null && spawnGrid[x, y] != 0)
                {
                    Instantiate(prefabs[spawnGrid[x, y]-1], new Vector2(x, y) - levelSize / 2, Quaternion.identity, prefabParent);
                }
            }
        }
    }
    public void UnsetTiles() //AKA retry
    {
        Destroy(prefabParent);
        spriteParent.gameObject.SetActive(true);
    }
}
