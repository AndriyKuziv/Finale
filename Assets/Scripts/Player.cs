using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int score;
    private Vector2 _direction;
    public List<Transform> _segments;

    private GameObject lastPos;
    private GameManager gameManager;
    public Transform segmentPrefab;

    public int initialLength = 2;

    private void Start(){
        _segments = new List<Transform>();
        lastPos = GameObject.Find("LastPosition");
        gameManager = GameManager.FindObjectOfType<GameManager>();

        _direction = Vector2.down;
        Reset();
    }

    KeyCode previous = KeyCode.None;
    KeyCode current;
    private void Update()
    {
       CurrentBtn();
    }

    private void FixedUpdate() {
        if(current != previous) ChangeDirection(current);

        Move();
    }

    private void inL(){
        for(int i = 1; i < initialLength; i++){
            _segments.Add(Instantiate(segmentPrefab));
        }
    }

    private void CurrentBtn(){
        if(Input.GetKeyDown(KeyCode.A)) current = KeyCode.A;
        else if(Input.GetKeyDown(KeyCode.D)) current = KeyCode.D;
        else if(Input.GetKeyDown(KeyCode.W)) current = KeyCode.W;
        else if(Input.GetKeyDown(KeyCode.S)) current = KeyCode.S;
    }
    private void ChangeDirection(KeyCode key){
        if(Time.timeScale != 0){
        switch(key){
            case KeyCode.W:
            if(previous != KeyCode.S){
                previous = KeyCode.W;
                
                _direction = Vector2.up;
                this.transform.rotation = Quaternion.Euler(new Vector3(0,0,180));
                }
            break;

            case KeyCode.A:
            if(previous != KeyCode.D){
                previous = KeyCode.A;
                
                _direction = Vector2.left;
                this.transform.rotation = Quaternion.Euler(new Vector3(0,0,-90));
                }
            break;
            case KeyCode.D:
            if(previous != KeyCode.A){
                previous = KeyCode.D;
                
                _direction = Vector2.right;
                this.transform.rotation = Quaternion.Euler(new Vector3(0,0,90));
                }
            break;
            case KeyCode.S:
            if(previous != KeyCode.W){
                previous = KeyCode.S;
                
                _direction = Vector2.down;
                this.transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
                }
            break;
        }
        }
    }

    private void Move(){
        lastPos.transform.position = _segments[_segments.Count - 1].position;

        for(int i = _segments.Count - 1; i > 0; i--) {
            _segments[i].position = _segments[i - 1].position;
        }

        this.transform.position = new Vector3(
        Mathf.Round(this.transform.position.x) + _direction.x, 
        Mathf.Round(this.transform.position.y) + _direction.y, 0);
    }

    public void Grow(){
        //Debug.Log("wait wat");
        AddScore();
            
        Transform segment = Instantiate(segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
            
        _segments.Add(segment);
    }

    public int Score(){
        return score;
    }
    public void AddScore(){
        score++;
        // Debug.Log(score);
    }


    public void Die(int t){
        if(t == 1){
            for(int i = 0; i < _segments.Count - 1; i++){
            _segments[i].position = _segments[i + 1].position;
            }
            _segments[_segments.Count - 1].position = lastPos.transform.position;
        }

        gameManager.gameOver();
    }

    private void Reset(){
        score = 0;
        
        for(int i = 1; i < _segments.Count; i++){
            Destroy(_segments[i].gameObject);
        }
        _segments.Clear();
        _segments.Add(this.transform);
        this.transform.position = new Vector3(0,0,0);

        inL();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Wall") Die(1);
    }

}
