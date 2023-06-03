using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public DragonCollision dragonCollision;

    public int BlockValue;

    public List<GameObject> BlockList;

    public List<GameObject> NextBlockList;

    public List<GameObject> PlacedDragonList;

    public List<GameObject> PlacedHorseList;

    public List<GameObject> PlacedRookList;

    public List<GameObject> PlacedBishopList;

    // Start is called before the first frame update
    void Start()
    {
        BlockValue = 5;

        NextBlockList = new List<GameObject>();
        PlacedDragonList = new List<GameObject>();
        PlacedHorseList = new List<GameObject>();
        PlacedRookList = new List<GameObject>();
        PlacedBishopList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BlockRandomizer()
    {
        BlockValue = Random.Range(0, 4); // 0= Dragon, 1=Horse/Knight, 2=Rook, 3=Bishop
        Debug.Log("Block Value : " + BlockValue);

        if (BlockValue == 0)
        {
            GameObject BlockObject = Instantiate(BlockList[BlockValue].gameObject, new Vector3(6, 0, -3), Quaternion.identity);
            NextBlockList.Add(BlockObject);
        }

        if (BlockValue == 1)
        {
            GameObject BlockObject = Instantiate(BlockList[BlockValue].gameObject, new Vector3(6, 0, -4), Quaternion.identity);
            NextBlockList.Add(BlockObject);
        }

        if (BlockValue == 2)
        {
            GameObject BlockObject = Instantiate(BlockList[BlockValue].gameObject, new Vector3(6, 0, -5), Quaternion.identity);
            NextBlockList.Add(BlockObject);
        }

        if (BlockValue == 3)
        {
            GameObject BlockObject = Instantiate(BlockList[BlockValue].gameObject, new Vector3(6, 0, -6), Quaternion.identity);
            NextBlockList.Add(BlockObject);
        }
    }

    public void TurnOffAllCollider()
    {
        for (int i = 0; i < PlacedDragonList.Count; i += 1)
        {
            PlacedDragonList[i].GetComponent<BoxCollider2D>().enabled = false;
        }

        for (int i = 0; i < PlacedHorseList.Count; i += 1)
        {
            PlacedHorseList[i].GetComponent<BoxCollider2D>().enabled = false;
        }

        for (int i = 0; i < PlacedRookList.Count; i += 1)
        {
            PlacedRookList[i].GetComponent<BoxCollider2D>().enabled = false;
        }

        for (int i = 0; i < PlacedBishopList.Count; i += 1)
        {
            PlacedBishopList[i].GetComponent<BoxCollider2D>().enabled = false;
        }

        for (int i = 0; i < NextBlockList.Count; i += 1)
        {
            NextBlockList[i].GetComponent<BoxCollider2D>().enabled = false; // Hapus Next Block
        }
    }

    public void TurnOnPlacedBlockCollider()
    {
        for (int i = 0; i < PlacedDragonList.Count; i += 1)
        {
            PlacedDragonList[i].GetComponent<BoxCollider2D>().enabled = true;
        }

        for (int i = 0; i < PlacedHorseList.Count; i += 1)
        {
            PlacedHorseList[i].GetComponent<BoxCollider2D>().enabled = true;
        }

        for (int i = 0; i < PlacedRookList.Count; i += 1)
        {
            PlacedRookList[i].GetComponent<BoxCollider2D>().enabled = true;
        }

        for (int i = 0; i < PlacedBishopList.Count; i += 1)
        {
            PlacedBishopList[i].GetComponent<BoxCollider2D>().enabled = true;
        }

        for (int i = 0; i < NextBlockList.Count; i += 1)
        {
            NextBlockList[i].GetComponent<BoxCollider2D>().enabled = true; // Hapus Next Block
        }
    }

    public void RemoveNextBlock(GameObject NextBlock)
    {
        NextBlockList.Remove(NextBlock);
        Destroy(NextBlock);
    }

    public void DeleteThreeDragonBlock() //GameObject ThreeBlock
    {
        if(PlacedDragonList.Count == 3)
        {
            for (int i = 1; i <= PlacedDragonList.Count; i += 0)
            {
                Destroy(PlacedDragonList[0]);
                PlacedDragonList.Remove(PlacedDragonList[0]); // potensi crash
                //Destroy(PlacedDragonList[0]);
            }
            /*PlacedDragonList.Remove(PlacedDragonList[2]); // potensi crash
            Destroy(PlacedDragonList[2]);

            PlacedDragonList.Remove(PlacedDragonList[1]); // potensi crash
            Destroy(PlacedDragonList[1]);

            PlacedDragonList.Remove(PlacedDragonList[0]); // potensi crash
            Destroy(PlacedDragonList[0]);*/
        }
    }

    public void DeleteThreeHorseBlock() //GameObject ThreeBlock
    {
        if (PlacedHorseList.Count == 3)
        {
            for (int i = 1; i <= PlacedHorseList.Count; i += 0)
            {
                Destroy(PlacedHorseList[0]);
                PlacedHorseList.Remove(PlacedHorseList[0]); // potensi crash
            }
        }
    }

    public void DeleteThreeRookBlock() //GameObject ThreeBlock
    {
        if (PlacedRookList.Count == 3)
        {
            for (int i = 1; i <= PlacedRookList.Count; i += 0)
            {
                Destroy(PlacedRookList[0]);
                PlacedRookList.Remove(PlacedRookList[0]); // potensi crash
            }
        }
    }

    public void DeleteThreeBishopBlock() //GameObject ThreeBlock
    {
        if (PlacedBishopList.Count == 3)
        {
            for (int i = 1; i <= PlacedBishopList.Count; i += 0)
            {
                Destroy(PlacedBishopList[0]);
                PlacedBishopList.Remove(PlacedBishopList[0]); // potensi crash
                //Destroy(PlacedDragonList[0]);
            }
        }
    }
}
