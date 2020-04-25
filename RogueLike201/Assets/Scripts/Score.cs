using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

	 public Transform score;
	public Transform player;
	public System.DateTime startTime;
	var EndTime : float;
	private int scoreCount;
	function Start(){
		StartTime = Time.time;
	}
     public void UpdateKill(String enemy)
    {
    	if ( enemy == "SmallFlying"){
    		scoreCount += 25;
    	}
    	if( enemy == "Humanoid"){
    		scoreCount+=50;
    	}

    	if( enemy == "Sniper"){
    		scoreCount+= 100;
    	}

    	if( enemy == "Bomber"){

    		scoreCount+= 150;
    	}

    	if ( enemy == "Tank"){

    		scoreCount += 125;
    	}

    	if ( enemy == "Boss"){

    		scoreCount += 500;
    	}
    	score.GetComponent<TextMeshProUGUI>().text = "Score: " + scoreCount;

    }
    public String GameOver(){
    	System.TimeSpan ts = System.DateTime.UtcNow - startTime;
    	scoreCount += 1000000/ts.Seconds;
    	score.GetComponent<TextMeshProUGUI>().text = "Score: " + scoreCount;
    }

    
    
}
