using UnityEngine;

public class SquareBehavior : MonoBehaviour
{
    [SerializeField] string color;
    SpawnManager spawner;
    Rigidbody2D rg;
    bool isSelected;
    int layerMask;
    int columnSpawned;
    float offset = 0.6f;
    private void Awake()
    {
        spawner = GameObject.Find("GameManager").GetComponent<SpawnManager>();
        rg = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        isSelected = false;
        switch (color)
        {
            case "blue":
                layerMask = LayerMask.GetMask("BlueSquare");
                break;
            case "green":
                layerMask = LayerMask.GetMask("GreenSquare");
                break;
            case "red":
                layerMask = LayerMask.GetMask("RedSquare");
                break;
            case "white":
                layerMask = LayerMask.GetMask("WhiteSquare");
                break;
            case "yellow":
                layerMask = LayerMask.GetMask("YellowSquare");
                break;

            default:
                break;
        }
    }
    public void ActivateSquare(int col)
    {
        gameObject.SetActive(true);
        columnSpawned = col;
        rg.simulated = true;
    }
    public void SelectedSquare()
    {
        StartCoroutine(spawner.DeleteSquares());
        DeleteAndCheckAround("");
    }
    public void DisableSquare()
    {
        spawner.Respawn(columnSpawned, gameObject);
        isSelected = false;
        gameObject.SetActive(false);
    }


    public void DeleteAndCheckAround(string dir)
    {
        spawner.AddToDeletePool(gameObject);
        isSelected = true;
        RaycastHit2D hitUp = Physics2D.Raycast((transform.position + new Vector3(0, offset, 0)), transform.TransformDirection(Vector2.up), 0.5f, layerMask);
        RaycastHit2D hitRight = Physics2D.Raycast((transform.position + new Vector3(offset, 0, 0)), transform.TransformDirection(Vector2.right), 0.5f, layerMask);
        RaycastHit2D hitDown = Physics2D.Raycast((transform.position - new Vector3(0, offset, 0)), transform.TransformDirection(Vector2.down), 0.5f, layerMask);
        RaycastHit2D hitLeft = Physics2D.Raycast((transform.position - new Vector3(offset, 0, 0)), transform.TransformDirection(Vector2.left), 0.5f, layerMask);
        if (hitUp.collider != null && dir != "up")
        {
            SquareBehavior targetUp = hitUp.collider.gameObject.GetComponent<SquareBehavior>();
            if (color == targetUp.color)
            {
                if (!targetUp.isSelected)
                    targetUp.DeleteAndCheckAround("down");
            }
        }
        if (hitRight.collider != null && dir != "right")
        {
            SquareBehavior targetRight = hitRight.collider.gameObject.GetComponent<SquareBehavior>();
            if (color == targetRight.color)
            {
                if (!targetRight.isSelected)
                    targetRight.DeleteAndCheckAround("left");
            }
        }
        if (hitDown.collider != null && dir != "down")
        {
            SquareBehavior targetDown = hitDown.collider.gameObject.GetComponent<SquareBehavior>();
            if (color == targetDown.color)
            {
                if (!targetDown.isSelected)
                    targetDown.DeleteAndCheckAround("up");
            }
        }
        if (hitLeft.collider != null && dir != "left")
        {
            SquareBehavior targetLeft = hitLeft.collider.gameObject.GetComponent<SquareBehavior>();
            if (color == targetLeft.color)
            {
                if (!targetLeft.isSelected)
                    targetLeft.DeleteAndCheckAround("right");
            }
        }
    }
    private void OnDisable()
    {
        rg.simulated = false;
    }
}

