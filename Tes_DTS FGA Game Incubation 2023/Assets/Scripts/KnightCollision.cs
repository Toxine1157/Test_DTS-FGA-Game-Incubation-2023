using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightCollision : MonoBehaviour
{
    public GameManager gameManager;

    public ScoreManager scoreManager;

    public Canvas cnv;

    public Collider2D AttackZn;

    public Timer timer;

    public int spawnController; // harus 0

    public List<GameObject> attackZoneList;

    public List<GameObject> attackZoneCloneList;

    public List<GameObject> TilesList;

    // Start is called before the first frame update
    void Start()
    {
        spawnController = 0;

        attackZoneCloneList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider == AttackZn || collision.gameObject.name == "attackZone(Clone)")
        {
            // game kalah

            cnv.enabled = true;

            for (int i = 0; i < TilesList.Count; i += 1)
            {
                TilesList[i].GetComponent<BoxCollider2D>().enabled = false;
            }

            gameManager.TurnOffAllCollider();

            timer.startTime = false;

            scoreManager.score -= 1;

            Debug.Log("Kena Block");
        }
    }

    public void OnMouseOver()
    {
        if (spawnController == 0) // Horse/Knight
        {
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
    }

    public void OnMouseExit()
    {
        for (int i = 1; i <= attackZoneCloneList.Count; i += 0)
        {
            RemoveAllAttackZone(attackZoneCloneList[0]);
        }
        spawnController = 0;

        AttackZn.enabled = false;

        /*for (int i = 1;i <= attackZoneCloneList.Count;i += 1)
        {
            attackZoneCloneList[0].GetComponent<BoxCollider2D>().enabled = false;
        }*/
        //GetComponent<BoxCollider2D>().enabled = false;
    }

    public void RemoveAllAttackZone(GameObject AttackZone) // (GameObject AttackZone) <- Parameter if needed or no parameter if needed
    {
        attackZoneCloneList.Remove(AttackZone);
        Destroy(AttackZone);

        spawnController = 0;
    }
}
