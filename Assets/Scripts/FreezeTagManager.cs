using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeTagManager : MonoBehaviour
{


    public List<GameObject> group;

    GameObject chosenOne;
    GameObject chasedOne;

    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, group.Count);
        chosenOne = group[rand];
        group.Remove(chosenOne);
        
        chosenOne.GetComponent<KinematicArriveA>().enabled = true;
        chasedOne = group[Random.Range(0, group.Count)]; 
        chosenOne.GetComponent<KinematicArriveA>().target = chasedOne;

        chasedOne.GetComponent<KinematicC>().enabled = true;
       
        chasedOne.GetComponent<KinematicC>().target = chosenOne;

        group.Add(chosenOne);

        Debug.Log("Name of Chosen One" + chosenOne.name + "and the Chased one is " + chasedOne.name);

        StartCoroutine("NewGameNow", 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void NewGame()
    {

        for(int i = 0; i < group.Count; i++)
        {
            group[i].GetComponent<KinematicC>().enabled = false;
            group[i].GetComponent<KinematicArriveA>().enabled = false;
           
        }
        int rand = Random.Range(0, group.Count);
        chosenOne = group[rand];
        group.Remove(chosenOne);

        chosenOne.GetComponent<KinematicArriveA>().enabled = true;
        chasedOne = group[Random.Range(0, group.Count)];
        chosenOne.GetComponent<KinematicArriveA>().target = chasedOne;

        chasedOne.GetComponent<KinematicC>().enabled = true;

        chasedOne.GetComponent<KinematicC>().target = chosenOne;

        group.Add(chosenOne);

        Debug.Log("Name of Chosen One" + chosenOne.name + "and the Chased one is " + chasedOne.name);
    }

    IEnumerator NewGameNow(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
           NewGame();
        }
    }
}
