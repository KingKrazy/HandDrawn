//-----------------------------------------------------------------------------
// Torque Game Builder - Scale Effect behaviour
// Version: 1.0
// mike@saikosystems.co.uk (Saiko)
//-----------------------------------------------------------------------------

if (!isObject(ScaleBehavior))
{
   %template = new BehaviorTemplate(ScaleBehavior);
   
   %template.friendlyName = "Scale Effect";
   %template.behaviorType = "Effects";
   %template.description  = "Scale the object an object over time";

   //Customization Options

   %template.addBehaviorField(xWidthMin, "Minimum x width", float, 5.0);
   %template.addBehaviorField(yWidthMin, "Minimum y width", float, 5.0);
   %template.addBehaviorField(xWidthMax, "Maximum x width", float, 50.0);
   %template.addBehaviorField(yWidthMax, "Maximum y width", float, 50.0);

   %template.addBehaviorField(Time, "The time (in seconds) to scale", float, 2.0);
   %template.addBehaviorField(DelayStart, "The time (in seconds) to delay scale starting", float, 0);
   %template.addBehaviorField(Increment, "Set the number of increments per second (0 defaults 31 steps per second)", int, 0);   

   %template.addBehaviorField(Pulse, "Continously scale up and down (Pulse)", bool, false);
   %template.addBehaviorField(Grow, "Should object grow from original size to maximum? (Grow)", bool, false);

   %template.addBehaviorField(AutoRotate, "Rotate", float, 0);

   %template.addBehaviorField(DeleteObject, "Delete the object when scale is finished", bool, false);

}

function ScaleBehavior::onBehaviorAdd(%this)
{
    %this.startSize = %this.xWidthMin SPC %this.yWidthMin;
    %this.endSize = %this.xWidthMax SPC %this.yWidthMax;
	if(%this.Increment == 0)
	{
		%this.stepIncrement = 31;
	}
	else
	{
		%this.stepIncrement = %this.Increment;
	}
   
	%this.xStepIncrement = (%this.xWidthMax - %this.xWidthMin) / (%this.Time * %this.stepIncrement);
	%this.yStepIncrement = (%this.yWidthMax - %this.yWidthMin) / (%this.Time * %this.stepIncrement);
	%this.direction = false;
	if (%this.AutoRotate != 0)
	{
	   %this.owner.setAngularVelocity(%this.AutoRotate);
	}

	if (%this.DelayStart > 0)
	{
		%this.schedule(%this.DelayStart * 1000, "startScale");
	}
	else
	{
		%this.startScale();
	}
 
}

function ScaleBehavior::startScale(%this)
{
   if (%this.Grow)
   {
	   %this.owner.size = %this.startSize;
	   %this.direction = true;
   }
   else
   {
	   %this.owner.size = %this.endSize;
	   %this.direction = false;
   }
  // enable our update callaback
  %this.owner.enableUpdateCallback();
}

function ScaleBehavior::endScale(%this)
{
	if(%this.Pulse)
	{
		// swap direction
		if (%this.direction)
		{
			%this.direction = false;
		}
		else
		{
			%this.direction = true;
		}
	}
	else
	{
		// if we are not pulsing we drop the update callback
		%this.owner.disableUpdateCallback();
		if(%this.DeleteObject)
		{
			%this.owner.safeDelete();
		}
	}
}

function ScaleBehavior::onUpdate(%this)
{
	
   if(%this.direction)
   {
	   %newX = %this.owner.size.x + %this.xStepIncrement;
	   %newY = %this.owner.size.y + %this.yStepIncrement;
	   %this.owner.size = %newX SPC %newY;
	   if((%this.owner.size.x > %this.xWidthMax) || (%this.owner.size.y > %this.yWidthMax))
	   {
		   %this.owner.size = %this.endSize;
		   %this.endScale();
	   }
   }
   else
   {
	   %newX = %this.owner.size.x - %this.xStepIncrement;
	   %newY = %this.owner.size.y - %this.yStepIncrement;
	   %this.owner.size = %newX SPC %newY;

	   if((%this.owner.size.x < %this.xWidthMin) || (%this.owner.size.y < %this.yWidthMin))
	   {
		   %this.owner.size = %this.startSize;
		   %this.endScale();
	   }
   }
}
