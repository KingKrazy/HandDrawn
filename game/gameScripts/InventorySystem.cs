//
//global arrays for initial content to be displayed
//

$FOOD      = 0;
$WEAPON  = 1;
$SPELLS    = 2;
$ARMOUR  = 3;

$FZeroAmmount = 200000;

//
//Give each of our buttons a function to call
//

%btn = new GuiButtonCtrl(Test) 
         {
            canSaveDynamicFields = "0";
            isContainer = "0";
            Profile = "GuiButtonProfile";
            HorizSizing = "right";
            VertSizing = "bottom";
            Position = "0 2";
            Extent = "136 136";
            MinExtent = "8 2";
            canSave = "1";
            Visible = "1";
            Command = "InventoryGui.btn1();";
            tooltipprofile = "GuiDefaultProfile";
            hovertime = "1000";
            text = "Kloo";
            groupNum = "-1";
            buttonType = "PushButton";
            UseMouseEvents = "0";
         };


function inventoryGui::btn1()
{
   //set the title text 
   lblInvTitle.setValue("FOOD");
   
   //clear the list box of previous content
   lstInventory.clearItems();

   //iterate through our array adding items to our list
   for(%i = 0;%i < 5;%i++)
   { 
      lstInventory.addItem( $aInv[ $FOOD,%i ]);
   }   
}

function inventoryGui::btn2()
{
   lblInvTitle.setValue("WEAPONS");
   lstInventory.clearItems();
   for(%i = 0;%i < 13;%i++)
   { 
      lstInventory.addItem( $aInv[ $WEAPON,%i ]);
   }   
}

function inventoryGui::btn3()
{
   lblInvTitle.setValue("SPELLS");
   lstInventory.clearItems();
   for(%i = 0;%i < 5;%i++)
   { 
      lstInventory.addItem( $aInv[ $SPELLS,%i ]);
   }   
}

function inventoryGui::btn4()
{
   lblInvTitle.setValue("ARMOUR");
   lstInventory.clearItems();
   for(%i = 0;%i < 4;%i++)
   { 
      lstInventory.addItem( $aInv[ $ARMOUR,%i ]);
   }   
}

function newInventoryGui::onWake()
{
//$InvTxt = "<br><br>Apples: <br>Carrots: <br>Soup Dishes: <br>Carrot Cakes: <br>Apple Pies: <br>Plain Beans: <br>Magic Beans: <br>Pastas: <br><br><br>Pine Cones: " @ $WZeroAmmount @ "<br>Burning Pine Cones: " @ $WOneAmmount @ "<br>Multi-Cones: <br>Burning Multi-Cones: <br>Jump-Slams: <br>Power Kicks: <br>Flaming Power Kicks: <br>Flaming Jump-Slams: <br>Frosty Pine Cones: <br>Frosty Multi-Cones: <br>Poison Cones: <br>Posion Multi-Cones: <br><br><br>Scale Powerups: <br>Shrink Powerups: <br>Collateral Damage Powerups: <br>Kamikazi Powerups: <br>Smash Powerups: <br><br><br>Health Regenerations (30 secs) <br>Player Damage Decrease (30 secs) <br>Damage Increases (25 secs) <br>Enemy Health Sabatoges <br>Enemy Health Drains (35 secs) <br>Enemy Speed Drains (35 secs) ";

//inventoryText.setText($InvTxt);

canvas.showCursor();


//Let's get all the inventory items...

Normal.setText($NormAmmount);
Burning.setText($BurnAmmount);
Frozen.setText($FrozeAmmount);
Poisened.setText($PoisAmmount);

Freeze();
}

function newInventoryGui::onSleep()
{
canvas.hideCursor();

UnFreeze();
}

function W1()
{
    if($NormAmmount > 0)
    {
    $NormAmmount = $NormAmmount - 1;
    $game::player.setActiveWeapon( PineConeLauncherWeapon );
    $playerAmmo = $playerAmmo + 100;
    $PineConeType = "Normal";
    echo($playerAmmo);
    Normal.setText($FrozeAmmount);
    }
    else
    {
          Canvas.PushDialog(AreYouSure2Gui);
      $AYSText = "<just:center>Sorry, you don't have any more of these items!";
      $AYSWindowText = "Slot Empty!";

      AYSWindowText.setText($AYSWindowText);
      AYSText.setText($AYSText);
    }
}

function W2()
{
    if($BurnAmmount > 0)
    {
    $BurnAmmount = $BurnAmmount - 1;
    $game::player.setActiveWeapon( BurningPineConeLauncherWeapon );
    $playerAmmo = $playerAmmo + 100;
    $PineConeType = "Burning";
    echo($playerAmmo);
    Burning.setText($BurnAmmount);
    }
    else
    {
          Canvas.PushDialog(AreYouSure2Gui);
      $AYSText = "<just:center>Sorry, you don't have any more of these items!";
      $AYSWindowText = "Slot Empty!";

      AYSWindowText.setText($AYSWindowText);
      AYSText.setText($AYSText);
    }
}

function W3()
{
    if($FrozeAmmount > 0)
    {
    $FrozeAmmount = $FrozeAmmount - 1;
    $game::player.setActiveWeapon( FrozenPineConeLauncherWeapon );
    $PineConeType = "Frozen";
    $playerAmmo = $playerAmmo + 25;
    echo($playerAmmo);
    Frozen.setText($FrozeAmmount);
    }
    else
    {
          Canvas.PushDialog(AreYouSure2Gui);
      $AYSText = "<just:center>Sorry, you don't have any more of these items!";
      $AYSWindowText = "Slot Empty!";

      AYSWindowText.setText($AYSWindowText);
      AYSText.setText($AYSText);
    }
}

function W4()
{
    if($PoisAmmount > 0)
    {
    $PoisAmmount = $PoisAmmount - 1;
    $game::player.setActiveWeapon( PoisenedPineConeLauncherWeapon );
    $PineConeType = "Poisened";
    $playerAmmo = $playerAmmo + 25;
    echo($playerAmmo);
    Poisened.setText($PoisAmmount);
    }
    else
    {
          Canvas.PushDialog(AreYouSure2Gui);
      $AYSText = "<just:center>Sorry, you don't have any more of these items!";
      $AYSWindowText = "Slot Empty!";

      AYSWindowText.setText($AYSWindowText);
      AYSText.setText($AYSText);
    }
}


function W5()
{
    if($WTwoAmmount > 0)
    {
    $WTwoAmmount -= 1;
    $game::player.setActiveWeapon( MultiConeLauncherWeapon );
    $playerAmmo = $playerAmmo + 25;
    $PineConeType = "Burning";
    echo($playerAmmo);
    }
    else
    {
          Canvas.PushDialog(AreYouSure2Gui);
      $AYSText = "<just:center>Sorry, you don't have any more of these items!";
      $AYSWindowText = "Slot Empty!";

      AYSWindowText.setText($AYSWindowText);
      AYSText.setText($AYSText);
    }
}

function W6()
{
    if($WThreeAmmount > 0)
    {
    $WThreeAmmount -= 1;
    $game::player.setActiveWeapon( BurningMultiConeLauncherWeapon );
    $playerAmmo = $playerAmmo + 25;
    $PineConeType = "Burning";
    echo($playerAmmo);
    }
}
