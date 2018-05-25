using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour {

    [SerializeField] GameObject gridObject;
    private bool gridObjectExists;
    public int gridsToGenerate = 15;
    private const float GRID_SPACE_HEIGHT = 50f;

    //The grid transforms we want to change;
    private List<Transform> gridTransforms;
    public float zToLerp = 11.4f;
    public float gridSpeed = 2f;
    public float maxDistanceOfCamera;

    public int currentGridHeader = 0;
    public int lastGridElement = 0;

    public Color startColor, endColor;

    private void Awake()
    {
        gridTransforms = new List<Transform>();
        gridObjectExists = gridObject != null;

        if (gridObjectExists)
        {
            GameObject previousGo = gridObject;
            for(int i = 0; i < gridsToGenerate; i++)
            {
                GameObject go = Instantiate(gridObject);
                go.transform.position = previousGo.transform.position;
                go.transform.position = new Vector3(previousGo.transform.position.x, previousGo.transform.position.y, previousGo.transform.position.z - GRID_SPACE_HEIGHT);

                MeshRenderer[] rs = go.GetComponentsInChildren<MeshRenderer>();
                for (int j = 0; j < rs.Length; j++)
                {
                    rs[j].material.color = endColor;
                }
                gridTransforms.Add(go.transform);

                previousGo = go;
            }
        }
    }

    private void Update()
    {
        for(int i = 0; i < gridTransforms.Count; i++)
        {
            Transform grid = gridTransforms[i];
            grid.position = Vector3.MoveTowards(grid.position, new Vector3(grid.position.x, grid.position.y, zToLerp - (GRID_SPACE_HEIGHT * i )), Time.deltaTime * gridSpeed);

            float dist = Vector3.Distance(Camera.main.transform.position, gridTransforms[i].position);

            MeshRenderer[] rs = gridTransforms[i].GetComponentsInChildren<MeshRenderer>();
            for (int j = 0; j < rs.Length; j++)
            {
                rs[j].material.color = Color.Lerp(rs[j].material.color, endColor, Time.deltaTime * (dist/maxDistanceOfCamera)/ 1000);
            }

            Vector3 toTarget = (Camera.main.transform.position - gridTransforms[i].position).normalized;
            if(Vector3.Dot(toTarget, transform.forward) > 0)
            {
                Transform t = gridObject.transform;
                gridTransforms[i].position = new Vector3(t.position.x, t.position.y, t.position.z - GRID_SPACE_HEIGHT);
                currentGridHeader++;

                for(int j = 0; j < rs.Length; j++)
                {
                    rs[j].material.color = startColor;
                }

                if ( currentGridHeader > gridTransforms.Count)
                {
                    currentGridHeader = 0;
                }
            }
        }


    }
}
