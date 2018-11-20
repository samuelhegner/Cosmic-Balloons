using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Site_Finder : MonoBehaviour {

    GameObject[] sites;

    public GameObject closestSite;

    float closestSiteDist;
    public float viewingDistance;

    void Awake(){
        sites = GameObject.FindGameObjectsWithTag("Site");
        closestSiteDist = Vector3.Distance(transform.position, sites[0].transform.position);
    }

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {
        closestSiteDist = float.MaxValue;

        for (int i = 0; i < sites.Length; i++) {

            GameObject site = sites[i];
            site.transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().enabled = false;
            site.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().enabled = false;
            site.transform.GetChild(0).transform.GetChild(0).transform.GetChild(1).GetComponent<Image>().enabled = false;

            if (Vector3.Distance(transform.position, site.transform.position) < closestSiteDist)
            {
                closestSiteDist = Vector3.Distance(transform.position, site.transform.position);
                closestSite = site;
            }
        }

        if (Vector3.Distance(transform.position, closestSite.transform.position) < viewingDistance)
        {
            closestSite.transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().enabled = true;
            closestSite.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().enabled = true;
            closestSite.transform.GetChild(0).transform.GetChild(0).transform.GetChild(1).GetComponent<Image>().enabled = true;
        }
        else {
            closestSite.transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().enabled = false;
            closestSite.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().enabled = false;
            closestSite.transform.GetChild(0).transform.GetChild(0).transform.GetChild(1).GetComponent<Image>().enabled = false;
        }
    }
}
