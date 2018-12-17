 using UnityEngine;
 using System.Collections;
 
 public class Rope : MonoBehaviour {
 
     public GameObject Base;          // Reference to the first GameObject
     public GameObject Sphere;          // Reference to the second GameObject
 
     public LineRenderer line;                           // Line Renderer
 
     // Use this for initialization
     void Start () {
     }
     
     // Update is called once per frame
     void Update () {
         // Check if the GameObjects are not null
         if (Base != null && Sphere != null)
         {
             // Update position of the two vertex of the Line Renderer
             line.SetPosition(0, Base.transform.position);
             line.SetPosition(1, Sphere.transform.position);
         }
     }
 }