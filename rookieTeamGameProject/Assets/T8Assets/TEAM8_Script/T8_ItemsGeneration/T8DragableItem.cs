using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class T8DragableItem : MonoBehaviour
{
    [HideInInspector]
    public bool placed = false;
    bool dragging;
    bool holding;
    private Vector3 mOffset;
    private Vector3 originPos;

    [HideInInspector]
    public GameObject holder;
    T8ObjectCenter center;

    private PolygonCollider2D coll;
    public float timer = 4.0f;
    [HideInInspector]
    public bool contactPlayer;

    [HideInInspector]
    public int shapeType;

    [HideInInspector]
    public int materialType;

    [HideInInspector]
    public int powerType;

    public CircleCollider2D objectCenter;
    
    public float attractForce;
    public float repulseForce;

    [Range(1.0f, 4.0f)]
    public float slowDownFactor = 2.5f;

    void Start()
    {
        coll = gameObject.GetComponent<PolygonCollider2D>();
        coll.isTrigger = true;

        center = gameObject.transform.Find("ObjectCenter").GetComponent<T8ObjectCenter>();
        gameObject.transform.Find("ObjectCenter").GetComponent<PointEffector2D>().enabled = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            if(holding)
            {
                rotateItem("up");
            }
        } else if(Input.GetKeyDown(KeyCode.DownArrow)){
            if(holding)
            {
                rotateItem("down");
            }
        } else if(Input.GetKeyDown(KeyCode.RightArrow)){
            if(holding)
            {
                rotateItem("right");
            }
        } else if(Input.GetKeyDown(KeyCode.LeftArrow)){
            if(holding)
            {
                rotateItem("left");
            }
        }
    }

    void FixedUpdate()
    {
        if(placed){
            timer -= Time.deltaTime;
            if(timer <= 0){
                Destroy(gameObject);
            }
        }
    }

    void OnMouseDown()
    {
        // Locked if placed
        if(!placed){
            mOffset = gameObject.transform.position - GetMouseWorldPos();
            holding = true;
            holder.GetComponent<T8ItemSlot>().clearGeneration();

            transform.localScale /=2;
        }
    }
    void OnMouseUp()
    {
        if(!placed && dragging){
            if(contactPlayer){
                Debug.Log("player");
                cancelPlacement();
            } else if(center.inZone1 && (materialType <= 0)){
                Debug.Log("Wrong zone !");
                cancelPlacement();
            } else if(center.inZone2 && materialType <= 1){
                Debug.Log("Wrong zone !");
                cancelPlacement();
            } else if(center.inZone3 && materialType <= 2){
                Debug.Log("Wrong zone !");
                cancelPlacement();
            } else {
                if(!center.inZone1 && !center.inZone2 && !center.inZone3){
                    Debug.Log("Outside the zone !");
                    cancelPlacement();
                } else {
                    mOffset = gameObject.transform.position - GetMouseWorldPos();

                    // change values once placed
                    gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
                    placed = true;
                    holding = false;
                    holder.GetComponent<T8ItemSlot>().readyToGenerate = true;
                    coll.isTrigger = false;
                    center.setActiveSector("");

                    gameObject.transform.Find("ObjectCenter").GetComponent<PointEffector2D>().enabled = true;
                
                    if(powerType == 1){
                        GetComponent<PointEffector2D>().forceMagnitude = 0.0f;
                        GetComponent<PolygonCollider2D>().enabled = false;
                        center.GetComponent<PointEffector2D>().enabled = false;
                        center.GetComponent<CircleCollider2D>().enabled = false;
                    } else if(powerType == 2){
                        GetComponent<PointEffector2D>().forceMagnitude = repulseForce;
                    } else if(powerType == 3){
                        GetComponent<PointEffector2D>().forceMagnitude = attractForce;
                    }
                }
                
            }
            dragging = false;
        }
    }
    
    public void OnMouseDrag()
    {
        if(!placed){
            // Move position with drag
            transform.position = GetMouseWorldPos() + mOffset;
            dragging = true;
        }
    }

    public void defineHolder(GameObject go){
        holder = go;
    }

    public void setOrigin(Vector3 pos)
    {
        originPos = pos;
    }


    private void cancelPlacement()
    {
        transform.position = originPos;
        transform.rotation = Quaternion.AngleAxis(0f, Vector3.forward);
        holding = false;
        placed = false;
        coll.isTrigger = true;
        center.setActiveSector("");
        transform.localScale *=2;

        transform.Find("ObjectCenter").transform.localPosition = new Vector3(0,0,0);

    }

    // Convert screen position to world position
    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void rotateItem(string direction)
    {
        if(direction.Equals("up")){
            gameObject.transform.rotation = Quaternion.AngleAxis(180f, Vector3.forward);
        } else if(direction.Equals("down")){
            gameObject.transform.rotation = Quaternion.AngleAxis(0f, Vector3.forward);
        } else if(direction.Equals("right")){
            gameObject.transform.rotation = Quaternion.AngleAxis(90f, Vector3.forward);
        } else if(direction.Equals("left")){
            gameObject.transform.rotation = Quaternion.AngleAxis(-90f, Vector3.forward);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player" || other.name == "ItemSlot"){
            contactPlayer = true;            
        }
    }

    
    private void OnTriggerStay2D(Collider2D other)
    {
        if(placed && other.name.Contains("Asteroid") && powerType == 1){
            other.GetComponent<Rigidbody2D>().velocity /= slowDownFactor;
            Debug.Log("Slowed down");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.name == "Player" || other.name == "ItemSlot"){
            contactPlayer = false;
        }
        
    }
}
