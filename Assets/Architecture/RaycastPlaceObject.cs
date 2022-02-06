using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class RaycastPlaceObject : MonoBehaviour
{
    public LayerMask mask;
    public float maxDist = 10000;
    public bool alignWithNormal;
    public float placementHeight = 0;
    public GameObject source;
    private GameObject placementVisual;
    private Ray ray;
    public GameObject placeParent;

    private void AlignObjectToTarget(RaycastHit hit)
    {
        Transform place = placementVisual.transform;
        place.position = hit.point;
        if (alignWithNormal)
        {
            place.up = hit.normal;
            place.position += place.up * placementHeight;
        }
        else
        {
            place.position += Vector3.up * placementHeight;
        }
    }

    private void GetSceneViewRay(SceneView scene)
    {
        Vector3 mousePosition = Event.current.mousePosition;
        mousePosition.y = SceneView.currentDrawingSceneView.camera.pixelHeight - mousePosition.y;
        mousePosition = SceneView.currentDrawingSceneView.camera.ScreenToWorldPoint(mousePosition);
        mousePosition.y = -mousePosition.y;
        ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
    }

    private void PlaceObject(SceneView scene)
    {
        Event e = Event.current;
        switch (e.type)
        {
            case EventType.KeyDown:
                if(e.keyCode == KeyCode.G)
                {
                    GameObject instance = Instantiate(placementVisual);
                    instance.transform.position = placementVisual.transform.position;
                    instance.transform.rotation = placementVisual.transform.rotation;
                    instance.transform.parent = placeParent.transform;
                }
                break;
        }
    }

    private void SelectPlaceObject(SceneView scene)
    {
        Selection.activeGameObject = gameObject;
    }

    private void OnEnable()
    {
        SceneView.duringSceneGui += SelectPlaceObject;
        SceneView.duringSceneGui += GetSceneViewRay;
        SceneView.duringSceneGui += PlaceViewObject;
        SceneView.duringSceneGui += PlaceObject;
    }
    private void OnDisable()
    {
        SceneView.duringSceneGui -= SelectPlaceObject;
        SceneView.duringSceneGui -= GetSceneViewRay;
        SceneView.duringSceneGui -= PlaceViewObject;
        SceneView.duringSceneGui -= PlaceObject;
        DestroyImmediate(placementVisual);
    }

    private void PlaceViewObject(SceneView scene)
    {
        if (placementVisual == null) placementVisual = Instantiate(source);
        RaycastHit[] hits = Physics.RaycastAll(ray, maxDist, mask);
        foreach (RaycastHit hit in hits)
        {
            AlignObjectToTarget(hit);
        }
    }
}
