//-----------------------------------------------------------------------------
//HandDrawn  
//-----------------------------------------------------------------------------

if ( !isObject( LifePickupBehavior ) )
{
    %template = new BehaviorTemplate( LifePickupBehavior );
    
    %template.friendlyName = "Life Pick Up";
    %template.behaviorType = "Collectable";
    %template.description  = "Adds an extra life.";
}

function LifePickupBehavior::confirmPickup( %this, %targetObject, %inventoryItem )
{
    // Add Life
    %targetObject.lives += 1;
    %targetObject.updateExtraLivesGui();
                              
    // Play the sound
    if ( isObject( ExtraLifePickupSound ) )
    {
        playSound( ExtraLifePickupSound );
    }
    

    %TextSprite = new t2dTextObject()
    {
        SceneGraph    = Scenewindow2D.getSceneGraph();
      canSaveDynamicFields = "1";
      Position = %TargetObject.Position;
      size = "14.758 4.920";
      text = "+100";
      font = "OCR A Std";
      wordWrap = "1";
      hideOverflow = "1";
      textAlign = "Left";
      lineHeight = "4.91946";
      aspectRatio = "1.15903";
      lineSpacing = "0";
      characterSpacing = "0";
      autoSize = "0";
      fontSizes = "42";
      BlendColor = "0 0 1 1";
      bilinearFilter = "1";
      snapToInteger = "0";
      noUnicode = "0";
         hideOverlap = "0";
         mountID = "794";
         snapToIntegerPos = "0";
      _behavior0 = "ScaleBehavior	xWidthMin	0.001	yWidthMin	0.001	xWidthMax	15	yWidthMax	5	DeleteObject	1";
         ConstantForce = "0 -50";
    };

 
    %impactSprite = new t2dStaticSprite()
    {
        SceneGraph    = Scenewindow2D.getSceneGraph();
        Class         = "PencilLifeImpactEffect";
        ImageMap      = "PencilLifeImageMap";
        Layer         = %this.Owner.Layer - 1;
        Position      = %this.Owner.Position;
        Rotation      = %this.Owner.Rotation;
        AutoRotation  = $PencilAutoRotation[getRandom(0,1)];
        Lifetime = 2.0;
        ConstantForce = "0 50";
        Size          = "10 10";
        _behavior0 = "ScaleBehavior\txWidthMin\t0\tyWidthMin\t0\txWidthMax\t7.5\tyWidthMax\t7.5\tTime\t1\tDelayStart\t0.5";
    };


return true;
}