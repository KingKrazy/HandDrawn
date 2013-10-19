//doSimpleAfterImageEffect(100, 1500, false, true, 0.14, 50, 0);

//**simple after image motion blur effect for animated sprites**
//frequency - how often to make after image clones (copies of object that fade out)
//duration - how long the effect will last
//owner visible - if true, the owner stays visible during the entire effect
//                if false, the owner disappears during the effect, and reappears
//                at the end.
//still frames - if true, then the copies are forced to render the same exact frame
//               as the owner had when the particular copy was made. Bit of a hacked
//               solution. Changes the frame back to previous one on an onFrameChange
//               callback.
//increment, speed, goal - all of these parameters are used soly for the fadeOut
//                         function. Increment is the number by which to reduce
//                         the alpha each speed interval which is in milliseconds.
//                         Goal tells the function when to stop fading.
function t2dAnimatedSprite::doSimpleAfterImageEffect(%this, %frequency, %duration, %ownerVisible, %stillFrames, %increment, %speed, %goal)
{
   for(%i = 0; %i < %duration; %i += %frequency)
   {
      %this.schedule(%i, "createAfterImageClone", %stillFrames, %increment, %speed, %goal);
   }
   
   if(!%ownerVisible)
   {
      %this.visible = false;
      %this.schedule(%duration, "setVisible", true);
   }
}

//used by the after image effects to produce copy images.
function t2dAnimatedSprite::createAfterImageClone(%this, %stillFrames, %increment, %speed, %goal)
{
   %clone = new t2dAnimatedSprite()
   {
      scenegraph = %this.getSceneGraph();
      class = "afterImageObject";
      size = %this.getSize();
      position = %this.getPosition();
      layer = (%this.getLayer() + 1);
      flipX = %this.FlipX;
      rotation = %this.getRotation();
      animationName = %this.getAnimation();
   };
   %clone.setAnimationFrame(%this.getAnimationFrame());
   %clone.fadeOut(%increment, %speed, %goal);
   //the next line assumes that your goal is 0. It just automatically computes a safe waiting
   //time for the deletion of the clone. Use the commented line after it to manually control
   //the deletion. Make sure to comment the automated line.
   %clone.schedule(((((1 - %increment) * %speed)/43) * 1500), "safeDelete");
   //%clone.schedule([int in milliseconds] "safeDelete");
   
   if(%stillFrames)
      %clone.setFrameChangeCallback(true);
}

//hacked solution to freeze an animation
function afterImageObject::onFrameChange(%this, %frameIndex)
{
   %this.setAnimationFrame(%frameIndex - 1);  
}

function t2dStaticSprite::doSimpleAfterImageEffect(%this, %frequency, %duration, %ownerVisible, %increment, %speed, %goal)
{
   for(%i = 0; %i < %duration; %i += %frequency)
   {
      %this.schedule(%i, "createAfterImageClone", %increment, %speed, %goal);
   }
   
   if(!%ownerVisible)
   {
      %this.visible = false;
      %this.schedule(%duration, "setVisible", true);
   }
}

function t2dStaticSprite::createAfterImageClone(%this, %increment, %speed, %goal)
{
   %clone = new t2dStaticSprite()
   {
      scenegraph = %this.getSceneGraph();
      class = "afterImageObject";
      size = %this.getSize();
      position = %this.getPosition();
      layer = (%this.getLayer() + 1);
      flipX = %this.FlipX;
      rotation = %this.getRotation();
      imageMap = %this.getImageMap();
   };
   %clone.fadeOut(%increment, %speed, %goal);
   //the next line assumes that your goal is 0. It just automatically computes a safe waiting
   //time for the deletion of the clone. Use the commented line after it to manually control
   //the deletion. Make sure to comment the automated line.
   %clone.schedule(((((1 - %increment) * %speed)/43) * 1500), "safeDelete");
   //%clone.schedule([int in milliseconds] "safeDelete");
}

//This function makes the object gradually disappear.
function t2dSceneObject::fadeOut(%this, %increment, %speed, %goal)
{
    if(isEventPending(%this.fadeInSchedule))
        cancel(%this.fadeInSchedule);
    
    %curAlpha = %this.getBlendAlpha();
    
    %this.setBlendAlpha(%curAlpha - %increment);
    
    if(%this.getBlendAlpha() >= %goal)
        %this.fadeOutSchedule = %this.schedule(%speed, "fadeOut", %increment, %speed, %goal);
    
    else
    {
        %this.setBlendAlpha(%goal);
        cancel(%this.fadeOutSchedule);
    }
}

function testderp()
{
echo("after image reporting.");
}