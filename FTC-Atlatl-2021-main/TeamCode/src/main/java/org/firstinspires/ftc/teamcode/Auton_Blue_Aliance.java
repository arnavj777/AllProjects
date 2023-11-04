/* Copyright (c) 2017 FIRST. All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without modification,
 * are permitted (subject to the limitations in the disclaimer below) provided that
 * the following conditions are met:
 *
 * Redistributions of source code must retain the above copyright notice, this list
 * of conditions and the following disclaimer.
 *
 * Redistributions in binary form must reproduce the above copyright notice, this
 * list of conditions and the following disclaimer in the documentation and/or
 * other materials provided with the distribution.
 *
 * Neither the name of FIRST nor the names of its contributors may be used to endorse or
 * promote products derived from this software without specific prior written permission.
 *
 * NO EXPRESS OR IMPLIED LICENSES TO ANY PARTY'S PATENT RIGHTS ARE GRANTED BY THIS
 * LICENSE. THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
 * "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO,
 * THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
 * ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE
 * FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
 * DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
 * SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
 * CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
 * OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
 * OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */

package org.firstinspires.ftc.teamcode;

import com.qualcomm.robotcore.eventloop.opmode.Autonomous;
import com.qualcomm.robotcore.eventloop.opmode.LinearOpMode;
import com.qualcomm.robotcore.eventloop.opmode.TeleOp;
import com.qualcomm.robotcore.eventloop.opmode.Disabled;
import com.qualcomm.robotcore.hardware.DcMotor;
import com.qualcomm.robotcore.hardware.DcMotorController;
import com.qualcomm.robotcore.hardware.DcMotorEx;
import com.qualcomm.robotcore.util.ElapsedTime;
import com.qualcomm.robotcore.util.Range;

import org.firstinspires.ftc.teamcode.Auton_methods;


/**
 * This file contains an minimal example of a Linear "OpMode". An OpMode is a 'program' that runs in either
 * the autonomous or the teleop period of an FTC match. The names of OpModes appear on the menu
 * of the FTC Driver Station. When an selection is made from the menu, the corresponding OpMode
 * class is instantiated on the Robot Controller and executed.
 *
 * This particular OpMode just executes a basic Tank Drive Teleop for a two wheeled robot
 * It includes all the skeletal structure that all linear OpModes contain.
 *
 * Use Android Studios to Copy this Class, and Paste it into your team's code folder with a new name.
 * Remove or comment out the @Disabled line to add this opmode to the Driver Station OpMode list
 */

@Autonomous(name="AtlAtl_Auton_Blue_Aliance", group="Linear Opmode")
public class Auton_Blue_Aliance extends LinearOpMode {

    // Declare OpMode members.
    private ElapsedTime runtime = new ElapsedTime();
    private DcMotorEx leftFrontDrive  = null;
    private DcMotorEx rightFrontDrive = null;
    private DcMotorEx leftBackDrive  = null;
    private DcMotorEx rightBackDrive = null;
    private Auton_methods generalAutonMethods = new Auton_methods(runtime, leftFrontDrive, rightFrontDrive,
            leftBackDrive, rightBackDrive);


    @Override
    public void runOpMode() throws InterruptedException {
        telemetry.addData("Status", "Initialized");
        telemetry.update();

        // Initialize the hardware variables. Note that the strings used here as parameters
        // to 'get' must correspond to the names assigned during the robot configuration
        // step (using the FTC Robot Controller app on the phone).
        leftFrontDrive = hardwareMap.get(DcMotorEx.class, "left_front_drive");
        leftBackDrive = hardwareMap.get(DcMotorEx.class, "left_back_drive");
        rightFrontDrive = hardwareMap.get(DcMotorEx.class, "right_front_drive");
        rightBackDrive = hardwareMap.get(DcMotorEx.class, "right_back_drive");

        leftFrontDrive.setMode(DcMotorEx.RunMode.RUN_USING_ENCODER);
        leftBackDrive.setMode(DcMotorEx.RunMode.RUN_USING_ENCODER);
        rightFrontDrive.setMode(DcMotorEx.RunMode.RUN_USING_ENCODER);
        rightBackDrive.setMode(DcMotorEx.RunMode.RUN_USING_ENCODER);

        leftFrontDrive.setZeroPowerBehavior(DcMotorEx.ZeroPowerBehavior.BRAKE);
        rightFrontDrive.setZeroPowerBehavior(DcMotorEx.ZeroPowerBehavior.BRAKE);
        leftBackDrive.setZeroPowerBehavior(DcMotorEx.ZeroPowerBehavior.BRAKE);
        rightBackDrive.setZeroPowerBehavior(DcMotorEx.ZeroPowerBehavior.BRAKE);
        // Most robots need the motor on one side to be reversed to drive forward
        // Reverse the motor that runs backwards when connected directly to the battery
        leftFrontDrive.setDirection(DcMotorEx.Direction.FORWARD);
        leftBackDrive.setDirection(DcMotorEx.Direction.FORWARD);
        rightBackDrive.setDirection(DcMotorEx.Direction.FORWARD);
        rightFrontDrive.setDirection(DcMotorEx.Direction.FORWARD);


        // Wait for the game to start (driver presses PLAY)
        waitForStart();
        runtime.reset();
        double leftBackPower = 0.00;
        double leftFrontPower = 0.00;
        double rightBackPower = 0.00;
        double rightFrontPower = 0.00;
        generalAutonMethods.DriveForwardTime(3500, 5);
        generalAutonMethods.TurnRightTime(2000, 2);
        generalAutonMethods.DriveForwardTime(3500, 2);
        // run until the end of the match (driver presses STOP)
        while (opModeIsActive()) {

            // Setup a variable for each drive wheel to save power level for telemetry




        }
    }

public void DriveForwardDistance(double power,int distance) {
    // Reset Encoders
    leftFrontDrive.setMode(DcMotorEx.RunMode.RESET_ENCODERS);
    leftBackDrive.setMode(DcMotorEx.RunMode.RESET_ENCODERS);
    rightFrontDrive.setMode(DcMotorEx.RunMode.RESET_ENCODERS);
    rightBackDrive.setMode(DcMotorEx.RunMode.RESET_ENCODERS);

    // Set target position
    leftFrontDrive.setTargetPosition(distance);
    leftBackDrive.setTargetPosition(distance);
    rightFrontDrive.setTargetPosition(distance);
    rightBackDrive.setTargetPosition(distance);

    // Set to RUN_TO_POSITION mode
    leftFrontDrive.setMode(DcMotorEx.RunMode.RUN_TO_POSITION);
    leftBackDrive.setMode(DcMotorEx.RunMode.RUN_TO_POSITION);
    rightFrontDrive.setMode(DcMotorEx.RunMode.RUN_TO_POSITION);
    rightBackDrive.setMode(DcMotorEx.RunMode.RUN_TO_POSITION);

    // Setting PID coefficents
    leftFrontDrive.setVelocityPIDFCoefficients(15, 0, 0, 0);
    leftBackDrive.setVelocityPIDFCoefficients(15, 0, 0, 0);
    rightFrontDrive.setVelocityPIDFCoefficients(15, 0, 0, 0);
    leftFrontDrive.setVelocityPIDFCoefficients(15, 0, 0, 0);

    // Set drive power
    Auton_methods methods = new Auton_methods(runtime, leftFrontDrive, rightFrontDrive, leftBackDrive, rightBackDrive);


    methods.driveForward(800);


    // Show the elapsed game time and wheel power.
    telemetry.addData("Status", "Run Time: " + runtime.toString());
    telemetry.addData("Motors", "left (%.2f), right (%.2f)");
    telemetry.update();
    }
}