using UnityEngine;
using Vuforia;
using System.Collections;
public class ModelSwapper : MonoBehaviour
{
    public TrackableBehaviour theTrackable;
    private bool mSwapModel = false;

    private int i = 1;
    // Use this for initialization
    void Start()
    {
        if (theTrackable == null)
        {
            Debug.Log("Warning: Trackable not set !!");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (mSwapModel && theTrackable != null)
        {
            SwapModel();
            mSwapModel = false;
        }
    }
    void OnGUI()
    {
        if (GUI.Button(new Rect(50, 50, 50, 25), "Change"))
        {
            mSwapModel = true;
        }
    }
    private void SwapModel()
    {
        string ModelName = (i % 5).ToString();
        GameObject trackableGameObject = theTrackable.gameObject;
        GameObject scene = Resources.Load("Prefabs\\" + ModelName) as GameObject;
        i++;
        //disable any pre-existing augmentation
        for (int i = 0; i < trackableGameObject.transform.childCount;   i++)
        {
            Transform child = trackableGameObject.transform.GetChild(i);
            child.gameObject.SetActive(false);
        }

        GameObject model = GameObject.Instantiate(scene);

        // Re-parent the cube as child of the trackable gameObject
        model.transform.parent = theTrackable.transform;

        model.transform.localPosition = new Vector3(0f, 0f, 0f);
        model.transform.localRotation = Quaternion.identity;
        model.active = true;
    }
}