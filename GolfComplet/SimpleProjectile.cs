using System;

public class SimpleProjectile : ODE
{
  //  gravitational acceleration.
  public const double G = -9.81;

  public SimpleProjectile(double x0, double y0, double z0, 
                          double vx0, double vy0, double vz0,
                          double time) : base(6) {

    //  Load the initial position, velocity, and time 
    //  values into the s field and q array from the
    //  ODE class.
    this.S = time;
    SetQ(vx0,0);
    SetQ(x0, 1);
    SetQ(vy0,2);
    SetQ(y0, 3);
    SetQ(vz0,4);
    SetQ(z0, 5);
  }

  //  These methods return the location, velocity, 
  //  and time values
  public double GetVx() {
    return GetQ(0);
  }

  public double GetVy() {
    return GetQ(2);
  }

  public double GetVz() {
    return GetQ(4);
  }

  public double GetX() {
    return GetQ(1);
  }

  public double GetY() {
    return GetQ(3);
  }

  public double GetZ() {
    return GetQ(5);
  }

  public double GetTime() {
    return this.S;
  }

/*	//  This method updates the velocity and position
	//  of the projectile according to the gravity-only model.
	public virtual void UpdateLocationAndVelocity(double dt) {
		//  Get current location, velocity, and time values
		//  From the values stored in the ODE class.
		double time = this.S;
		double vx = GetQ(0);
		double x = GetQ(1);
		double vy = GetQ(2);
		double y = GetQ(3);
		double vz = GetQ(4);
		double z = GetQ(5);

		//  Update time;
		time = time + dt;

		//  Update the xyz locations and the z-component
		//  of velocity. The x- and y-velocities don't change.
		x = x + vx*dt;
		y = y + vy*dt;
		vz = vz + G*dt;
		z = z + vz*dt + 0.5*G*dt*dt;

		//  Load new values into ODE arrays and fields.
		this.S = time;
		SetQ(x, 1);
		SetQ(y, 3);
		SetQ(vz,4);
		SetQ(z, 5);
	}
  //  Because SimpleProjectile extends the ODE class,
  //  it must implement the getRightHandSide method.
  //  In this case, the method returns a dummy array.
  public override double[] GetRightHandSide(double s, double[] q, 
               double[] deltaQ, double ds, double qScale) {
    return new double[1];
  }*/

	public virtual void UpdateLocationAndVelocity(double dt) {
		ODESolver.RungeKutta4(this, dt);
	}

	//  The GetRightHandSide() method returns the right-hand
	//  sides of the six first-order projectile ODEs
	//  q[0] = vx = fixa
	//  q[1] = x = vx*dt
	//  q[2] = vy = fixa
	//  q[3] = y = vy*dt
	//  q[4] = vz = g*dt
	//  q[5] = z = vz*dt
	public override double[] GetRightHandSide(double s, double[] q, 
		double[] deltaQ, double ds,
		double qScale) 
	{
		double[] dQ = new double[6];
		double[] newQ = new double[6];

		//  Compute the intermediate values of the 
		//  dependent variables.
		for(int i=0; i<6; ++i) {
			newQ[i] = q[i] + qScale*deltaQ[i];
		}

		//  Declare some convenience variables representing
		//  the intermediate values of velocity.
		double vx = newQ[0];
		double vy = newQ[2];
		double vz = newQ[4];

		dQ[0] = 0;
		dQ[1] = ds*vx;
		dQ[2] = 0;
		dQ[3] = ds*vy;
		dQ[4] = ds*G;
		dQ[5] = ds*vz;

		return dQ;
	}
}
