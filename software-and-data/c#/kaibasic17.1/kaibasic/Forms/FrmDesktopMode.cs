// Project: MyKai - kaibasic application
// Created by: jsoftz on 01/11/2019
// Copyright (c) 2019-2025 jsoftz. All rights reserved.
//
// This file contains the FrmDesktopMode class, which is part of the kaibasic application.

using System;
using System.Drawing;
using System.Windows.Forms;

using MyKai.Properties;
using MyKai.Gesture;
using MyKai.Manager;
using MyKai.GUI;


namespace kaibasic
{
    public delegate void MainFormCloseActionType();

  
    public partial class FrmDesktopMode : Form, IKaiStatusViewingControl
    {
        MainFormCloseActionType mainFormCloseAction;

        private int initialHeight, shrunkHeight;

        public FrmDesktopMode(MainFormCloseActionType pMainFormCloseAction)
        {
            mainFormCloseAction = pMainFormCloseAction;

            Initializer initializer = new Initializer(this);
            initializer.PerformInitActions();
            
            SetFormSizes();

            this.ActiveControl = null; // Hide the focus rectangle on the form
        }

        private void SetFormSizes() // It is assumed that form size is defined in the designer
        {             
            initialHeight = this.Height;
            shrunkHeight = lbTitle.Height + pnDistanceTop.Height + gbTop.Height + pnBottoom.Height + gbUserGestures.Height + 4; // 4 is the margin at the bottom of the form
        }

        private void HideDetails()
        {
            tcDetails.Visible = false;
            this.Height = shrunkHeight;
            bShowLessMore.Text = ((char)(212)).ToString();
            lbDetailLevelDescription.Text = "Show Details";
            this.ActiveControl = null; // Remove focus from the button
        }

        private void ShowDetails()
        {
            tcDetails.Visible = true;
            this.Height = initialHeight;
            bShowLessMore.Text = ((char)(211)).ToString();
            lbDetailLevelDescription.Text = "Hide Details";
            this.ActiveControl = null; // Remove focus from the button
        }

        private void FrmDesktopMode_Load(object sender, EventArgs e)
        {
            var screen = Screen.PrimaryScreen.WorkingArea;
            this.Location = new Point(screen.Right - this.Width, screen.Top);

            UpdateKaiSDKStatusControls();
            UpdateKaiSensorStatusControls();
        }

        private void bShowLessMore_Click(object sender, EventArgs e)
        {
            bool isExpanded = tcDetails.Visible; // Condition used to avoid an additional boolean variable on the form level

            if (isExpanded)
                HideDetails(); 
            else
                ShowDetails();
        }

        private void bRunSDK_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null; // Remove focus from the button
            RunKaiSDK();
        }

        private void bInitializeAndConnect_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            KaiFacade.Action.InitKaiConnection(MyKaiSettings.Default.kaiManagerKAIDSKProccessName, MyKaiSettings.Default.kaiSDKAuthProcessSecret);
        }

        private void bStartGestureCapture_Click(object sender, EventArgs e)
        {
            ConfigureForGestureCapture();
            StartGestureCapture();
            this.ActiveControl = null;
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            mainFormCloseAction();
        }
    }
}
