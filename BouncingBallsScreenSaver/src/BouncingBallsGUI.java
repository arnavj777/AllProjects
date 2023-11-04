


import mickel.anim.Stage;
import mickel.image.ImageFile;
import mickel.io.Key;

import java.awt.Color;

import javax.swing.JFrame;


/** The primary GUI window of the BouncingBalls application.
 */
public class BouncingBallsGUI
{
	// FIELDS
	// ------------------------------------------------------------
	public Stage myStage;			// The base window for the app.
	

	// CONSTRUCTORS
	// ------------------------------------------------------------
	/** Constructs and initializes each of the components for this
	 *  GUI window.
	 *
	 *  postcondition: The primary GUI window is initialized and
	 *                   its animation cycle is started.
	 *      algorithm: Initialize a new Stage to have a title of
	 *                   "Bouncing Balls", a width of 400, and a
	 *                   height of 400.
	 *                 Set the background of myStage to be a new
	 *                   Color of your choice, preferably with a
	 *                   low alpha value. For example, translucent
	 *                   orange would be new Color(200,100,0,66)
	 *                 Optionally, set the background of myStage
	 *                   to be an image (GIF, JPEG, or PNG)
	 *                   of your choice. For example, the Duke.png
	 *                   file has been provided for you. Construct
	 *                   it using new ImageFile("Duke.png")
	 *                 Set the location of myStage such that it
	 *                   will be centered on a 1280 x 1024 screen.
	 *                   HINT: Use a mathematical expression to
	 *                   automatically calculate the appropriate
	 *                   x and y coordinate the upper left corner
	 *                   of myStage.
	 *                 Invoke this object's addSprites() method.
	 *                 Tell myStage to open its window.
	 *                 Tell myStage to start its animation cycle.
	 */
	
	
	public BouncingBallsGUI(){
		
		setMyStage(new Stage("BouncingBalls",400,400));
		getMyStage().setBackground(new Color(0,0,0,30));
		getMyStage().setBackground(new ImageFile("Windows7.jpg"));
		getMyStage().setLocation(1280/2, 1024/2);
		this.addSprites();
		getMyStage().openWindow();
		getMyStage().start();
		
		
	}


	// METHODS
	// ------------------------------------------------------------
	/** Constructs and adds multiple Ball objects to the Stage.
	 *
	 *  postcondition: Constructs and adds one Ball object for each
	 *                   of the 3 Ball constructors to the Stage.
	 *      algorithm: Declare a Ball variable called b1 and assign
	 *                   to it a new Ball object with no parameters.
	 *                 Declare a Ball variable called b2 and assign
	 *                   to it a new Ball object with 2 specific
	 *                   parameters (width and height of myStage).
	 *                 Declare a Ball variable called b3 and assign
	 *                   to it a new Ball object with 4 specific
	 *                   parameters (x-location, y-location, size,
	 *                   color) of your choice and add it to myStage.
	 *                 Add b1 to myStage.
	 *                 Add b2 to myStage.
	 *                 Add b3 to myStage.
	 *                
	 */
	void addSprites()
	{
		Ball b1 = new Ball();
		Ball b2 = new Ball(getMyStage().getWidth(), getMyStage().getHeight());
		Ball b3 = new Ball(1000,50,50, new Color(0,50,100));
		Ball b4 = new Ball(600,200,150, Color.ORANGE);
		getMyStage().add(b1);
		getMyStage().add(b2);
		getMyStage().add(b3);
		getMyStage().add(b4);
		
	}


	public Stage getMyStage() {
		return myStage;
	}


	public void setMyStage(Stage myStage) {
		this.myStage = myStage;
	}
}
