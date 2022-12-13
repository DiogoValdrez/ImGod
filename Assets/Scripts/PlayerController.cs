using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{
    //Frame rate
    public int testFrameRate = 60;//use this to test limited framerate(-1 for max)

    private void Awake(){
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = testFrameRate;
    }

    //private void FixedUpdate(){
    protected override void Update()
    {
        base.Update();

        float x = 0;
        float y = 0;
        float z = 0;
        float w = 0;
        if(Input.GetKey(KeyCode.A)){
            x = -1;
        }
        if(Input.GetKey(KeyCode.D)){
            x = 1;
        }
        
        if(Input.GetKeyDown(KeyCode.Space)){
            y = 1;
        }else if(Input.GetKey(KeyCode.Space)){
            y = 2;
        }
        if(Input.GetKeyUp(KeyCode.Space)){
            y = 0;
        }
        if(Input.GetKey(KeyCode.W)){
            w = 2;//fix this by using a bigger vector
        }
        if(Input.GetKeyUp(KeyCode.W)){
            w = -2;//fix this by using a bigger vector
        }
        if(Input.GetKey(KeyCode.S)){
            y = -1;
        }

        if(Input.GetKeyDown(KeyCode.Mouse0)){
            z = 1;
        }
        

        UpdateMotor(new Vector4(x, y, z, w)); 
    }
}