using System;
using System.Windows.Forms;
using System.Drawing;

public class GolfGame4 : Form
{
  private Label vxLabel;
  private Label vyLabel;
  private Label vzLabel;
  private Label distanceLabel;
  private Label axesLabel;
  private Label massLabel;
  private Label areaLabel;
  private Label cdLabel;
  private Label densityLabel;
  private Label windVxLabel;
  private Label windVyLabel;
  private Label rxLabel;
  private Label ryLabel;
  private Label rzLabel;
  private Label omegaLabel;
  private Label radiusLabel;
  private Label spinAxisLabel;

  private TextBox vxTextBox;
  private TextBox vyTextBox;
  private TextBox vzTextBox;
  private TextBox distanceTextBox;
  private TextBox massTextBox;
  private TextBox areaTextBox;
  private TextBox cdTextBox;
  private TextBox densityTextBox;
  private TextBox windVxTextBox;
  private TextBox windVyTextBox;
  private TextBox rxTextBox;
  private TextBox ryTextBox;
  private TextBox rzTextBox;
  private TextBox omegaTextBox;
  private TextBox radiusTextBox;

  private ComboBox axesComboBox;

  private Button fireButton;
  private Button resetButton;

  private Panel drawingPanel;

  //  This field is for the images used in the game.
  private Image golferIcon;
  private Image flagIcon;

  //  The Timer is used to control the execution speed
  //  of the game.
  private Timer gameTimer;

  //  The golf ball is a SpinProjectile
  private SpinProjectile golfball;

  //  The player can control the distance to the hole.
  private double distanceToHole;

  public GolfGame4() {

    //  Create a SpinProjectile object with default values
    //  so the display can be updated the first time.
    golfball = 
        new SpinProjectile(0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0,
                           0.0459, 0.001432, 0.5, 1.225, 0.0, 0.0,
                           0.0, 1.0, 0.0, 300.0, 0.02135);

    //  Set up images
    golferIcon = Image.FromFile("Golfer.jpg");
    flagIcon = Image.FromFile("Hole_Cartoon.jpg");

    //  Initialize the distanceToHole field.
    distanceToHole = 200.0;

    //  Create a Timer object that will be used
    //  to slow the action down.
    gameTimer = new Timer();
    gameTimer.Interval = 50;  //  delay in milliseconds.
    gameTimer.Tick += new EventHandler(ActionPerformed);

    //  Create some Labels
    vxLabel = new Label();
    vxLabel.Text = "Initial x-velocity, m/s";
    vxLabel.Font = new Font(vxLabel.Font, FontStyle.Bold);
    vxLabel.Top = 50;
    vxLabel.Left = 10;
    vxLabel.Width = 130;

    vyLabel = new Label();
    vyLabel.Text = "Initial y-velocity, m/s";
    vyLabel.Font = new Font(vyLabel.Font, FontStyle.Bold);
    vyLabel.Top = 80;
    vyLabel.Left = 10;
    vyLabel.Width = 130;

    vzLabel = new Label();
    vzLabel.Text = "Initial z-velocity, m/s";
    vzLabel.Font = new Font(vzLabel.Font, FontStyle.Bold);
    vzLabel.Top = 110;
    vzLabel.Left = 10;
    vzLabel.Width = 130;

    distanceLabel = new Label();
    distanceLabel.Text = "Distance to hole, m";
    distanceLabel.Font = new Font(distanceLabel.Font, FontStyle.Bold);
    distanceLabel.Top = 140;
    distanceLabel.Left = 10;
    distanceLabel.Width = 120;

    massLabel = new Label();
    massLabel.Text = "mass, kg";
    massLabel.Font = new Font(massLabel.Font, FontStyle.Bold);
    massLabel.Top = 50;
    massLabel.Left = 210;
    massLabel.Width = 110;

    areaLabel = new Label();
    areaLabel.Text = "area, m^2";
    areaLabel.Font = new Font(areaLabel.Font, FontStyle.Bold);
    areaLabel.Top = 80;
    areaLabel.Left = 210;
    areaLabel.Width = 110;

    cdLabel = new Label();
    cdLabel.Text = "drag coefficient";
    cdLabel.Font = new Font(cdLabel.Font, FontStyle.Bold);
    cdLabel.Top = 110;
    cdLabel.Left = 210;
    cdLabel.Width = 110;

    densityLabel = new Label();
    densityLabel.Text = "density, kg/m^3";
    densityLabel.Font = new Font(densityLabel.Font, FontStyle.Bold);
    densityLabel.Top = 140;
    densityLabel.Left = 210;
    densityLabel.Width = 110;

    axesLabel = new Label();
    axesLabel.Text = "View axes";
    axesLabel.Font = new Font(axesLabel.Font, FontStyle.Bold);
    axesLabel.Top = 170;
    axesLabel.Left = 10;
    axesLabel.Width = 70;

    windVxLabel = new Label();
    windVxLabel.Text = "Wind x-velocity, m/s";
    windVxLabel.Font = new Font(windVxLabel.Font, FontStyle.Bold);
    windVxLabel.Top = 170;
    windVxLabel.Left = 210;
    windVxLabel.Width = 120;

    windVyLabel = new Label();
    windVyLabel.Text = "Wind y-velocity, m/s";
    windVyLabel.Font = new Font(windVyLabel.Font, FontStyle.Bold);
    windVyLabel.Top = 200;
    windVyLabel.Left = 210;
    windVyLabel.Width = 120;

    omegaLabel = new Label();
    omegaLabel.Text = "Angular velocity, rad/s";
    omegaLabel.Font = new Font(omegaLabel.Font, FontStyle.Bold);
    omegaLabel.Top = 50;
    omegaLabel.Left = 400;
    omegaLabel.Width = 120;

    radiusLabel = new Label();
    radiusLabel.Text = "Sphere radius, m";
    radiusLabel.Font = new Font(radiusLabel.Font, FontStyle.Bold);
    radiusLabel.Top = 80;
    radiusLabel.Left = 400;
    radiusLabel.Width = 120;

    spinAxisLabel = new Label();
    spinAxisLabel.Text = "Spin Axes";
    spinAxisLabel.Font = new Font(spinAxisLabel.Font, FontStyle.Bold);
    spinAxisLabel.Top = 110;
    spinAxisLabel.Left = 400;
    spinAxisLabel.Width = 120;

    rxLabel = new Label();
    rxLabel.Text = "rx";
    rxLabel.Font = new Font(rxLabel.Font, FontStyle.Bold);
    rxLabel.Top = 140;
    rxLabel.Left = 400;
    rxLabel.Width = 50;

    ryLabel = new Label();
    ryLabel.Text = "ry";
    ryLabel.Font = new Font(ryLabel.Font, FontStyle.Bold);
    ryLabel.Top = 170;
    ryLabel.Left = 400;
    ryLabel.Width = 50;

    rzLabel = new Label();
    rzLabel.Text = "rz";
    rzLabel.Font = new Font(rzLabel.Font, FontStyle.Bold);
    rzLabel.Top = 200;
    rzLabel.Left = 400;
    rzLabel.Width = 50;

    //  Create TextBox objects to display the inputs.
    vxTextBox = new TextBox();
    vxTextBox.Width = 50;
    vxTextBox.Text = String.Format("{0}", 31.0m);
    vxTextBox.AutoSize = true;
    vxTextBox.Top = vxLabel.Top;
    vxTextBox.Left = 150;

    vyTextBox = new TextBox();
    vyTextBox.Width = 50;
    vyTextBox.Text = String.Format("{0}", 0.0m);
    vyTextBox.AutoSize = true;
    vyTextBox.Top = vyLabel.Top;
    vyTextBox.Left = 150;

    vzTextBox = new TextBox();
    vzTextBox.Width = 50;
    vzTextBox.Text = String.Format("{0}", 35.0m);
    vzTextBox.AutoSize = true;
    vzTextBox.Top = vzLabel.Top;
    vzTextBox.Left = 150;

    distanceTextBox = new TextBox();
    distanceTextBox.Width = 50;
    distanceTextBox.Text = String.Format("{0}", 200.0m);
    distanceTextBox.AutoSize = true;
    distanceTextBox.Top = distanceLabel.Top;
    distanceTextBox.Left = 150;

    massTextBox = new TextBox();
    massTextBox.Width = 60;
    massTextBox.Text = String.Format("{0}", 0.0459);
    massTextBox.AutoSize = true;
    massTextBox.Top = massLabel.Top;
    massTextBox.Left = 330;

    areaTextBox = new TextBox();
    areaTextBox.Width = 60;
    areaTextBox.Text = String.Format("{0}", 0.001432);
    areaTextBox.AutoSize = true;
    areaTextBox.Top = areaLabel.Top;
    areaTextBox.Left = 330;

    cdTextBox = new TextBox();
    cdTextBox.Width = 60;
    cdTextBox.Text = String.Format("{0}", 0.25);
    cdTextBox.AutoSize = true;
    cdTextBox.Top = cdLabel.Top;
    cdTextBox.Left = 330;

    densityTextBox = new TextBox();
    densityTextBox.Width = 60;
    densityTextBox.Text = String.Format("{0}", 1.225);
    densityTextBox.AutoSize = true;
    densityTextBox.Top = densityLabel.Top;
    densityTextBox.Left = 330;

    windVxTextBox = new TextBox();
    windVxTextBox.Width = 50;
    windVxTextBox.Text = String.Format("{0}", 10.0);
    windVxTextBox.AutoSize = true;
    windVxTextBox.Top = windVxLabel.Top;
    windVxTextBox.Left = 330;

    windVyTextBox = new TextBox();
    windVyTextBox.Width = 50;
    windVyTextBox.Text = String.Format("{0}", 0.0m);
    windVyTextBox.AutoSize = true;
    windVyTextBox.Top = windVyLabel.Top;
    windVyTextBox.Left = 330;

    omegaTextBox = new TextBox();
    omegaTextBox.Width = 60;
    omegaTextBox.Text = String.Format("{0}", 300.0);
    omegaTextBox.AutoSize = true;
    omegaTextBox.Top = omegaLabel.Top;
    omegaTextBox.Left = 530;

    radiusTextBox = new TextBox();
    radiusTextBox.Width = 60;
    radiusTextBox.Text = String.Format("{0}", 0.02135);
    radiusTextBox.AutoSize = true;
    radiusTextBox.Top = radiusLabel.Top;
    radiusTextBox.Left = 530;

    rxTextBox = new TextBox();
    rxTextBox.Width = 60;
    rxTextBox.Text = String.Format("{0}", 0.0m); 
    rxTextBox.AutoSize = true;
    rxTextBox.Top = rxLabel.Top;
    rxTextBox.Left = 530;

    ryTextBox = new TextBox();
    ryTextBox.Width = 50;
    ryTextBox.Text = String.Format("{0}", 1.0m);
    ryTextBox.AutoSize = true;
    ryTextBox.Top = ryLabel.Top;
    ryTextBox.Left = 530;

    rzTextBox = new TextBox();
    rzTextBox.Width = 50;
    rzTextBox.Text = String.Format("{0}", 0.0m);
    rzTextBox.AutoSize = true;
    rzTextBox.Top = rzLabel.Top;
    rzTextBox.Left = 530;

    //  Create a ComboBox to select the view axes.
    axesComboBox = new ComboBox();
    axesComboBox.Items.Add("XZ");
    axesComboBox.Items.Add("XY");
    axesComboBox.SelectedIndex = 0;
    axesComboBox.Left = 80;
    axesComboBox.Top = axesLabel.Top;

    //  Create Button objects 
    int buttonHeight = 30;
    int buttonWidth = 50;
    int buttonLeft = 20;

    fireButton = new Button();
    fireButton.Text = "Fire";
    fireButton.Height = buttonHeight;
    fireButton.Width = buttonWidth;
    fireButton.Top = 200;
    fireButton.Left = buttonLeft;
    fireButton.Click += new EventHandler(FireButtonClicked);

    resetButton = new Button();
    resetButton.Text = "Reset";
    resetButton.Height = buttonHeight;
    resetButton.Width = buttonWidth;
    resetButton.Top = 250;
    resetButton.Left = buttonLeft;
    resetButton.Click += new EventHandler(ResetButtonClicked);

    //  Create a drawing panel.
    drawingPanel = new Panel();
    drawingPanel.Width = 501;
    drawingPanel.Height = 201;
    drawingPanel.Left = 20;
    drawingPanel.Top = 300;
    drawingPanel.BorderStyle = BorderStyle.FixedSingle;

    //  Add the GUI components to the Form
    this.Controls.Add(vxLabel);
    this.Controls.Add(vyLabel);
    this.Controls.Add(vzLabel);
    this.Controls.Add(distanceLabel);
    this.Controls.Add(axesLabel);
    this.Controls.Add(massLabel);
    this.Controls.Add(areaLabel);
    this.Controls.Add(cdLabel);
    this.Controls.Add(densityLabel);
    this.Controls.Add(windVxLabel);
    this.Controls.Add(windVyLabel);
    this.Controls.Add(omegaLabel);
    this.Controls.Add(radiusLabel);
    this.Controls.Add(spinAxisLabel);
    this.Controls.Add(rxLabel);
    this.Controls.Add(ryLabel);
    this.Controls.Add(rzLabel);
    this.Controls.Add(vxTextBox);
    this.Controls.Add(vyTextBox);
    this.Controls.Add(vzTextBox);
    this.Controls.Add(distanceTextBox);
    this.Controls.Add(massTextBox);
    this.Controls.Add(areaTextBox);
    this.Controls.Add(cdTextBox);
    this.Controls.Add(densityTextBox);
    this.Controls.Add(windVxTextBox);
    this.Controls.Add(windVyTextBox);
    this.Controls.Add(omegaTextBox);
    this.Controls.Add(radiusTextBox);
    this.Controls.Add(rxTextBox);
    this.Controls.Add(ryTextBox);
    this.Controls.Add(rzTextBox);
    this.Controls.Add(axesComboBox);
    this.Controls.Add(fireButton);
    this.Controls.Add(resetButton);
    this.Controls.Add(drawingPanel);

    // Set the size and title of the form
    this.Width = 620;
    this.Height = 550;
    this.Text = "Golf Game version 4";

    //  Center the form on the screen and make
    //  it visible.
    this.StartPosition = FormStartPosition.CenterScreen;
    this.Visible = true;

    //  Update the GUI display
    UpdateDisplay();
  }

  //  Event handling method for the "Fire" button
  public void FireButtonClicked(object source, EventArgs e) {

    //  Get the initial values from the textfield
    double vx0 = Convert.ToDouble(vxTextBox.Text);
    double vy0 = Convert.ToDouble(vyTextBox.Text);
    double vz0 = Convert.ToDouble(vzTextBox.Text);
    distanceToHole = Convert.ToDouble(distanceTextBox.Text);
    double mass = Convert.ToDouble(massTextBox.Text);
    double area = Convert.ToDouble(areaTextBox.Text);
    double cd = Convert.ToDouble(cdTextBox.Text);
    double density = Convert.ToDouble(densityTextBox.Text);
    double windVx = Convert.ToDouble(windVxTextBox.Text);
    double windVy = Convert.ToDouble(windVyTextBox.Text);
    double rx = Convert.ToDouble(rxTextBox.Text);
    double ry = Convert.ToDouble(ryTextBox.Text);
    double rz = Convert.ToDouble(rzTextBox.Text);
    double omega = Convert.ToDouble(omegaTextBox.Text);
    double radius = Convert.ToDouble(radiusTextBox.Text);

    //  Create a SpinProjectile object representing the golf ball.
    golfball = new SpinProjectile(0.0, 0.0, 0.0, vx0, vy0, vz0, 
         0.0, mass, area, density, cd, windVx, windVy,
         rx, ry, rz, omega, radius);

    //  Update the display
    UpdateDisplay();

    //  Fire the golf ball using a Timer object
    //  to slow down the action.
    gameTimer.Start();
  }

  //  Event handling method for the "Reset" button
  public void ResetButtonClicked(object source, EventArgs e) {
    //  stop the timer.
    gameTimer.Stop();

    //  Reset the time, location, and velocity of ball;
    golfball.S = 0.0;       //  time
    golfball.SetQ(0.0,0);   //  vx0
    golfball.SetQ(0.0,1);   //  x0
    golfball.SetQ(0.0,2);   //  vy0
    golfball.SetQ(0.0,3);   //  y0
    golfball.SetQ(0.0,4);   //  vz0
    golfball.SetQ(0.0,5);   //  z0

    //  Reset the distance to hole.
    distanceToHole = Convert.ToDouble(distanceTextBox.Text);
 
    //  Update the display.
    UpdateDisplay();
  }

  //  This method redraws the GUI display.
  private void UpdateDisplay() {
    Graphics g = drawingPanel.CreateGraphics();
    int width = drawingPanel.Width - 1;
    int height = drawingPanel.Height - 1;

    //  Clear the current display.
//    g.Clear(drawingPanel.BackColor);
    g.Clear(Color.White);

    //  Update the position of the golfball on the screen.
    SolidBrush brush = new SolidBrush(Color.Black);
    Pen blackPen = new Pen(Color.Black, 1);

    //  Draw picture based on whether the XZ or 
    //  XY axes are selected.
    string axes = (string)axesComboBox.SelectedItem;
    if ( String.Equals(axes, "XZ") ) {

      //  Draw the golfer.
      int zLocation = height - 50;
      g.DrawImage(golferIcon, 0, zLocation, 34, 50);

      //  Draw the flag
      zLocation = height - 62;
      g.DrawImage(flagIcon, (int)(2.0*distanceToHole), 
                  zLocation, 55, 62);

      //  Update the position of the golfball
      //  on the screen.
      int xPosition = (int)(2.0*golfball.GetX() + 14);
      int zPosition = (int)(height - 5 - 2.0*golfball.GetZ());
      g.FillEllipse(brush, xPosition, zPosition, 5, 5);
    }
    else {
      //  Draw location of green.
      g.DrawEllipse(blackPen, (int)(2.0*distanceToHole - 20), 80, 40, 40);
      g.FillEllipse(brush, (int)(2.0*distanceToHole - 4), 96, 8, 8);

      //  Update the position of the golfball
      //  on the screen.
      int xPosition = (int)(2.0*golfball.GetX());
      int yPosition = (int)(100 - 2 - 2.0*golfball.GetY());
      g.FillEllipse(brush, xPosition, yPosition, 5, 5);
    }

    //  Clean up the Graphics object.
    g.Dispose();
  }

  //  This method is called by the Timer every 0.05 seconds.
  public void ActionPerformed(object source, EventArgs e) {

    //  Update the time and compute the new position
    //  of the golfball. 
    double timeIncrement = 0.07;
    golfball.UpdateLocationAndVelocity(timeIncrement);

    //  Update the display
    UpdateDisplay();

    //  Access the Graphics object of the drawing panel.
    Graphics g = drawingPanel.CreateGraphics();

    //  When the golfball hits the ground, stop the simulation
    //  and see where ball has landed.
    if ( golfball.GetZ() <= 0.0 ) {

Console.WriteLine("time="+(float)golfball.GetTime()+
"  x="+(float)golfball.GetX()+
"  y="+(float)golfball.GetY()+"  z="+(float)golfball.GetZ());

      //  Stop the simulation
      gameTimer.Stop();

        //  Determine if ball is on the green.
      SolidBrush brush = new SolidBrush(Color.Black);
      Font font = new Font("Arial", 12);
      if ( golfball.GetX() > distanceToHole - 10.0 &&
           golfball.GetX() < distanceToHole + 10.0 &&
           golfball.GetY() < 10.0) {
        g.DrawString("You're on the green", font, brush, 100, 30);

      }
      else {
        g.DrawString("You missed", font, brush, 100, 30);
      }
    }
  }

  static void Main() {
    Application.Run(new GolfGame4());
  }
}
