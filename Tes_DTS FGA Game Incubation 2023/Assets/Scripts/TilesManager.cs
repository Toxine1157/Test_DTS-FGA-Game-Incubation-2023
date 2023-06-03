using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesManager : MonoBehaviour
{
    public Canvas startCanvas;

    public GameManager gameManager;

    public Timer timer;

    public ScoreManager scoreManager;

    //public DragonCollision dragonCollision;

    Color MouseHover = Color.green;

    Color OriginalColor;

    SpriteRenderer s_Renderer;

    public int spawnController; // harus 0

    public List<GameObject> attackZoneList;

    public List<GameObject> attackZoneCloneList;

    public Collider2D Attack_Zn;

    // Start is called before the first frame update
    void Start()
    {
        s_Renderer = GetComponent<SpriteRenderer>();

        OriginalColor = s_Renderer.color;

        //BlockValue = 5; // Never 0-3
        spawnController = 0; // harus 0

        attackZoneCloneList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown()
    {
        /*for (int i = 1; i <= attackZoneCloneList.Count; i += 0)
        {
            RemoveAllAttackZone(attackZoneCloneList[0]);
        }*/
        startCanvas.enabled = false;
        timer.startTime = true;

        for (int i = 1; i <= gameManager.NextBlockList.Count; i += 0) // ganti next block
        {
            gameManager.RemoveNextBlock(gameManager.NextBlockList[0]);
        }

        if (gameManager.BlockValue == 0) // Dragon
        {
            //collider attackzn on?
            Attack_Zn.enabled = true;

            GameObject PlayingBlock = Instantiate(gameManager.BlockList[gameManager.BlockValue], new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), Quaternion.identity);
            gameManager.PlacedDragonList.Add(PlayingBlock);
            gameManager.DeleteThreeDragonBlock();

            scoreManager.score += 1;

            timer.timeLeft = 10;
            timer.transform.localScale = new Vector3(3, 0.5f, 1);
        }

        if (gameManager.BlockValue == 1) // Horse
        {
            Attack_Zn.enabled = true;

            GameObject PlayingBlock = Instantiate(gameManager.BlockList[gameManager.BlockValue], new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), Quaternion.identity);
            gameManager.PlacedHorseList.Add(PlayingBlock);
            gameManager.DeleteThreeHorseBlock();

            scoreManager.score += 1;

            timer.timeLeft = 10;
            timer.transform.localScale = new Vector3(3, 0.5f, 1);
        }

        if (gameManager.BlockValue == 2) // Rook
        {
            Attack_Zn.enabled = true;

            GameObject PlayingBlock = Instantiate(gameManager.BlockList[gameManager.BlockValue], new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), Quaternion.identity);
            gameManager.PlacedRookList.Add(PlayingBlock);
            gameManager.DeleteThreeRookBlock();

            scoreManager.score += 2;

            timer.timeLeft = 10;
            timer.transform.localScale = new Vector3(3, 0.5f, 1);
        }

        if (gameManager.BlockValue == 3) // Bishop
        {
            Attack_Zn.enabled = true;

            GameObject PlayingBlock = Instantiate(gameManager.BlockList[gameManager.BlockValue], new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), Quaternion.identity);
            gameManager.PlacedBishopList.Add(PlayingBlock);
            gameManager.DeleteThreeBishopBlock();

            scoreManager.score += 2;

            timer.timeLeft = 10;
            timer.transform.localScale = new Vector3(3, 0.5f, 1);
        }

        gameManager.BlockRandomizer();

        //collisionDetection.OnTriggerEnter2D();
        //GetComponent<BoxCollider2D>().enabled = false;
    }

    public void OnMouseOver()
    {
        s_Renderer.color = MouseHover;
        MouseHover.a = 0.42f;

        if (spawnController == 0 && gameManager.BlockValue == 0) //Dragon GetBlockValue
        {
            Attack_Zn.enabled = false;

            GameObject AttackZone = Instantiate(attackZoneList[0], new Vector3(transform.position.x, transform.position.y + 1.1f, -3), Quaternion.identity);
            attackZoneCloneList.Add(AttackZone);

            AttackZone = Instantiate(attackZoneList[0], new Vector3(transform.position.x + 1.1f, transform.position.y + 1.1f, -3), Quaternion.identity);
            attackZoneCloneList.Add(AttackZone);

            AttackZone = Instantiate(attackZoneList[0], new Vector3(transform.position.x + 1.1f, transform.position.y, -3), Quaternion.identity);
            attackZoneCloneList.Add(AttackZone);

            AttackZone = Instantiate(attackZoneList[0], new Vector3(transform.position.x + 1.1f, transform.position.y - 1.1f, -3), Quaternion.identity);
            attackZoneCloneList.Add(AttackZone);

            AttackZone = Instantiate(attackZoneList[0], new Vector3(transform.position.x, transform.position.y - 1.1f, -3), Quaternion.identity);
            attackZoneCloneList.Add(AttackZone);

            AttackZone = Instantiate(attackZoneList[0], new Vector3(transform.position.x - 1.1f, transform.position.y - 1.1f, -3), Quaternion.identity);
            attackZoneCloneList.Add(AttackZone);

            AttackZone = Instantiate(attackZoneList[0], new Vector3(transform.position.x - 1.1f, transform.position.y, -3), Quaternion.identity);
            attackZoneCloneList.Add(AttackZone);

            AttackZone = Instantiate(attackZoneList[0], new Vector3(transform.position.x - 1.1f, transform.position.y + 1.1f, -3), Quaternion.identity);
            attackZoneCloneList.Add(AttackZone);

            spawnController++;
            //Debug.Log("OnMouseOver executed");
        }

        if (spawnController == 0 && gameManager.BlockValue == 1) // Horse/Knight
        {
            Attack_Zn.enabled = false;

            GameObject AttackZone = Instantiate(attackZoneList[0], new Vector3(transform.position.x + 1.1f, transform.position.y + 2.2f, -3), Quaternion.identity);
            attackZoneCloneList.Add(AttackZone);

            AttackZone = Instantiate(attackZoneList[0], new Vector3(transform.position.x + 2.2f, transform.position.y + 1.1f, -3), Quaternion.identity);
            attackZoneCloneList.Add(AttackZone);

            AttackZone = Instantiate(attackZoneList[0], new Vector3(transform.position.x + 2.2f, transform.position.y - 1.1f, -3), Quaternion.identity);
            attackZoneCloneList.Add(AttackZone);

            AttackZone = Instantiate(attackZoneList[0], new Vector3(transform.position.x + 1.1f, transform.position.y - 2.2f, -3), Quaternion.identity);
            attackZoneCloneList.Add(AttackZone);

            AttackZone = Instantiate(attackZoneList[0], new Vector3(transform.position.x - 1.1f, transform.position.y - 2.2f, -3), Quaternion.identity);
            attackZoneCloneList.Add(AttackZone);

            AttackZone = Instantiate(attackZoneList[0], new Vector3(transform.position.x - 2.2f, transform.position.y - 1.1f, -3), Quaternion.identity);
            attackZoneCloneList.Add(AttackZone);

            AttackZone = Instantiate(attackZoneList[0], new Vector3(transform.position.x - 2.2f, transform.position.y + 1.1f, -3), Quaternion.identity);
            attackZoneCloneList.Add(AttackZone);

            AttackZone = Instantiate(attackZoneList[0], new Vector3(transform.position.x - 1.1f, transform.position.y + 2.2f, -3), Quaternion.identity);
            attackZoneCloneList.Add(AttackZone);

            spawnController++;
            //Debug.Log("OnMouseOver executed");
        }

        if (spawnController == 0 && gameManager.BlockValue == 2) // Rook
        {
            Attack_Zn.enabled = false;

            GameObject AttackZone = Instantiate(attackZoneList[0], new Vector3(transform.position.x, transform.position.y + 2.2f, -3), Quaternion.identity);
            attackZoneCloneList.Add(AttackZone);

            AttackZone = Instantiate(attackZoneList[0], new Vector3(transform.position.x, transform.position.y + 1.1f, -3), Quaternion.identity);
            attackZoneCloneList.Add(AttackZone);

            AttackZone = Instantiate(attackZoneList[0], new Vector3(transform.position.x + 2.2f, transform.position.y, -3), Quaternion.identity);
            attackZoneCloneList.Add(AttackZone);

            AttackZone = Instantiate(attackZoneList[0], new Vector3(transform.position.x + 1.1f, transform.position.y, -3), Quaternion.identity);
            attackZoneCloneList.Add(AttackZone);

            AttackZone = Instantiate(attackZoneList[0], new Vector3(transform.position.x, transform.position.y - 2.2f, -3), Quaternion.identity);
            attackZoneCloneList.Add(AttackZone);

            AttackZone = Instantiate(attackZoneList[0], new Vector3(transform.position.x, transform.position.y - 1.1f, -3), Quaternion.identity);
            attackZoneCloneList.Add(AttackZone);

            AttackZone = Instantiate(attackZoneList[0], new Vector3(transform.position.x - 2.2f, transform.position.y, -3), Quaternion.identity);
            attackZoneCloneList.Add(AttackZone);

            AttackZone = Instantiate(attackZoneList[0], new Vector3(transform.position.x - 1.1f, transform.position.y, -3), Quaternion.identity);
            attackZoneCloneList.Add(AttackZone);

            spawnController++;
            //Debug.Log("OnMouseOver executed");
        }

        if (spawnController == 0 && gameManager.BlockValue == 3) // Bishop
        {
            Attack_Zn.enabled = false;

            GameObject AttackZone = Instantiate(attackZoneList[0], new Vector3(transform.position.x + 2.2f, transform.position.y + 2.2f, -3), Quaternion.identity);
            attackZoneCloneList.Add(AttackZone);

            AttackZone = Instantiate(attackZoneList[0], new Vector3(transform.position.x + 1.1f, transform.position.y + 1.1f, -3), Quaternion.identity);
            attackZoneCloneList.Add(AttackZone);

            AttackZone = Instantiate(attackZoneList[0], new Vector3(transform.position.x + 2.2f, transform.position.y - 2.2f, -3), Quaternion.identity);
            attackZoneCloneList.Add(AttackZone);

            AttackZone = Instantiate(attackZoneList[0], new Vector3(transform.position.x + 1.1f, transform.position.y - 1.1f, -3), Quaternion.identity);
            attackZoneCloneList.Add(AttackZone);

            AttackZone = Instantiate(attackZoneList[0], new Vector3(transform.position.x - 2.2f, transform.position.y - 2.2f, -3), Quaternion.identity);
            attackZoneCloneList.Add(AttackZone);

            AttackZone = Instantiate(attackZoneList[0], new Vector3(transform.position.x - 1.1f, transform.position.y - 1.1f, -3), Quaternion.identity);
            attackZoneCloneList.Add(AttackZone);

            AttackZone = Instantiate(attackZoneList[0], new Vector3(transform.position.x - 2.2f, transform.position.y + 2.2f, -3), Quaternion.identity);
            attackZoneCloneList.Add(AttackZone);

            AttackZone = Instantiate(attackZoneList[0], new Vector3(transform.position.x - 1.1f, transform.position.y + 1.1f, -3), Quaternion.identity);
            attackZoneCloneList.Add(AttackZone);

            spawnController++;
            //Debug.Log("OnMouseOver executed");
        }
    }

    public void OnMouseExit()
    {
        // Reset the color of the GameObject back to normal
        s_Renderer.color = OriginalColor;
        //Destroy (AttackZone);
        //RemoveAllAttackZone(attackZoneCloneList[0]);
        //RemoveAllAttackZone(attackZoneCloneList[0]);
        for (int i = 1; i <= attackZoneCloneList.Count; i+=0)
        {
            RemoveAllAttackZone(attackZoneCloneList[0]);
        }
        //RemoveAllAttackZone();
        //RemoveAllAttackZone();
        spawnController = 0;
        //Debug.Log("OnMouseExit executed");
    }

    public void RemoveAllAttackZone(GameObject AttackZone) // (GameObject AttackZone) <- Parameter if needed or no parameter if needed
    {
        /*while (attackZoneCloneList.Count > 0)
        {
            attackZoneCloneList.Remove(AttackZone);
            Destroy(AttackZone);

            Debug.Log("Despawned");

            spawnController = 0;
        }*/
        attackZoneCloneList.Remove(AttackZone);
        Destroy(AttackZone);

        //Debug.Log("Despawned");
        //Destroy(AttackZone);
        spawnController = 0;
        //Debug.Log("RAAZ Ran");
    }
}
