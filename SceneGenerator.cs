using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneGenerator : MonoBehaviour
{
    [Header("Forest")]
    public int sizeOfForest;

    [Header("Pyramid")]
    public float cubeAmount;

    private void Start()
    {
        CreateGround();
        CreateForest();
        CreatePyramid();
    }

    private void InitializeVariables()
    {

    }

    private void CreateGround()
    {
        // Create the ground cube.
        GameObject ground = GameObject.CreatePrimitive(PrimitiveType.Cube);

        // Names the ground cube.
        ground.name = "Ground";

        // Set the grounds position and scale.
        ground.transform.position = new Vector3(0, -0.5f, 0);
        ground.transform.localScale = new Vector3(20, 1, 20);

        // Change the grounds color.
        ground.GetComponent<MeshRenderer>().material.color = Color.red;
    }

    private void CreatePyramid()
    {
        // Set up pyramid holder.
        GameObject pyramidHolder = new GameObject();
        pyramidHolder.name = "Pyramid";
        pyramidHolder.transform.position = new Vector3(5, 1f, 0);

        float decreaseCubeAmount = cubeAmount;

        // Creates pyramid layer by layer.
        for(int i=0; i<cubeAmount; i++)
        {
            for(int j=0; j<decreaseCubeAmount; j++)
            {
                // Assign new color per row.
                Color rowColor = new Color(0, 0, (1 / cubeAmount) * i, 1);

                for(int k=0; k<decreaseCubeAmount; k++)
                {
                    // Create new cube.
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.localPosition = new Vector3(.5f * i + 1.05f * j, 1.05f * i + 0.5f, .5f * i + 1.05f * k);

                    // Set cube color.
                    cube.GetComponent<MeshRenderer>().material.color = rowColor;

                    // Set cube parent.
                    cube.transform.parent = pyramidHolder.transform;
                }
                
            }
            decreaseCubeAmount--;
        }
    }

    private void CreateForest()
    {
        // Create forest holder.
        GameObject forestHolder = new GameObject();
        forestHolder.name = "Forest";
        forestHolder.transform.position = new Vector3(-5, 0, 0);

        // Loop through sizeOfForest and create trees.
        for(int i=0; i<sizeOfForest; i++)
        {
            /// Creates new tree object.
            GameObject tree = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            tree.name = "Tree " + i;

            // Sets the parent to forestHolder.
            tree.transform.parent = forestHolder.transform;

            // Set the tree scale and position.
            tree.transform.localScale = new Vector3(Random.Range(.1f, 1f), Random.Range(.1f, 1f), Random.Range(.1f, 1f));
            tree.transform.localPosition = new Vector3(Random.Range(-2f, 2f), tree.transform.localScale.y, Random.Range(-2f, 2f));

            // Set the tree color.
            tree.GetComponent<MeshRenderer>().material.color = new Color(0, Random.Range(.08f, .95f), 0, 1);
        }
    }
}
