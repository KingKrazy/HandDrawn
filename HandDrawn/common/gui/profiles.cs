//---------------------------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//---------------------------------------------------------------------------------------------

$Gui::fontCacheDirectory = expandFilename("~/data/fonts");

//---------------------------------------------------------------------------------------------
// GuiDefaultProfile is a special profile that all other profiles inherit defaults from. It
// must exist.
//---------------------------------------------------------------------------------------------
//---------------------------------------------------------------------------------------------
// GuiDefaultProfile is a special profile that all other profiles inherit defaults from. It
// must exist.
//---------------------------------------------------------------------------------------------
if(!isObject(GuiDefaultProfile)) new GuiControlProfile (GuiDefaultProfile)
{
   tab = false;
   canKeyFocus = false;
   hasBitmapArray = false;
   mouseOverSelected = false;

   // fill color
   opaque = false;
   fillColor = "255 255 255";
   fillColorHL = "244 244 244";
   fillColorNA = "244 244 244";

   // border color
   border = 0;
   borderColor   = "40 40 40 100";
   borderColorHL = "128 128 128";
   borderColorNA = "64 64 64";

   // font
   fontType = "Lucida Grande";
   fontSize = 16;

   fontColor = "0 0 100";
   fontColorHL = "0 255 255";
   fontColorNA = "255 0 0";
   fontColorSEL= "255 255 255";

   // bitmap information
   bitmap = "./images/window";
   bitmapBase = "";
   textOffset = "0 0";

   // used by guiTextControl
   modal = true;
   justify = "left";
   autoSizeWidth = false;
   autoSizeHeight = false;
   returnTab = false;
   numbersOnly = false;
   cursorColor = "0 0 0 255";

   // sounds
   soundDown = "";
   soundOver = "";
};

if(!isObject(GuiDefaultBorderProfile)) new GuiControlProfile (GuiDefaultBorderProfile)
{
   tab = false;
   canKeyFocus = false;
   hasBitmapArray = false;
   mouseOverSelected = false;

   // fill color
   opaque = false;
   fillColor = "255 255 255";
   fillColorHL = "244 244 244";
   fillColorNA = "244 244 244";

   // border color
   border = 0;
   borderColor   = "0 0 0 75";
   borderColorHL = "128 128 128";
   borderColorNA = "64 64 64";

   // font
   fontType = "Lucida Grande";
   fontSize = 16;

   fontColor = "0 0 0";
   fontColorHL = "0 255 255";
   fontColorNA = "255 0 0";
   fontColorSEL= "255 255 255";

   // bitmap information
   bitmap = "./images/window";
   bitmapBase = "";
   textOffset = "0 0";

   // used by guiTextControl
   modal = true;
   justify = "left";
   autoSizeWidth = false;
   autoSizeHeight = false;
   returnTab = false;
   numbersOnly = false;
   cursorColor = "0 0 0 255";

   // sounds
   soundDown = "";
   soundOver = "";
};


if(!isObject(GuiBlackProfile)) new GuiControlProfile (GuiBlackProfile)
{
   tab = false;
   canKeyFocus = false;
   hasBitmapArray = false;
   mouseOverSelected = false;

   // fill color
   opaque = false;
   fillColor = "0 0 0";
   fillColorHL = "25 25 25";
   fillColorNA = "25 25 25";

   // border color
   border = 0;
   borderColor   = "40 40 40 100";
   borderColorHL = "128 128 128";
   borderColorNA = "64 64 64";

   // font
   fontType = "Lucida Grande";
   fontSize = 16;

   fontColor = "0 0 0";
   fontColorHL = "32 100 100";
   fontColorNA = "0 0 0";
   fontColorSEL = "200 200 200";

   // bitmap information
   bitmap = "./images/window";
   bitmapBase = "";
   textOffset = "0 0";

   // used by guiTextControl
   modal = true;
   justify = "left";
   autoSizeWidth = false;
   autoSizeHeight = false;
   returnTab = false;
   numbersOnly = false;
   cursorColor = "0 0 0 255";

   // sounds
   soundDown = "";
   soundOver = "";
};

if(!isObject(GuiWhiteProfile)) new GuiControlProfile (GuiWhiteProfile)
{
   tab = false;
   canKeyFocus = false;
   hasBitmapArray = false;
   mouseOverSelected = false;

   // fill color
   opaque = false;
   fillColor = "0 0 0";
   fillColorHL = "25 25 25";
   fillColorNA = "25 25 25";

   // border color
   border = 0;
   borderColor   = "40 40 40 100";
   borderColorHL = "128 128 128";
   borderColorNA = "64 64 64";

   // font
   fontType = "Lucida Grande";
   fontSize = 16;

   fontColor = "255 255 255";
   fontColorHL = "32 100 100";
   fontColorNA = "0 0 0";
   fontColorSEL = "200 200 200";

   // bitmap information
   bitmap = "./images/window";
   bitmapBase = "";
   textOffset = "0 0";

   // used by guiTextControl
   modal = true;
   justify = "left";
   autoSizeWidth = false;
   autoSizeHeight = false;
   returnTab = false;
   numbersOnly = false;
   cursorColor = "0 0 0 255";

   // sounds
   soundDown = "";
   soundOver = "";
};

if(!isObject(GuiRedProfile)) new GuiControlProfile (GuiRedProfile)
{
   tab = false;
   canKeyFocus = false;
   hasBitmapArray = false;
   mouseOverSelected = false;

   // fill color
   opaque = true;
   fillColor = "255 0 0";
   fillColorHL = "25 25 25";
   fillColorNA = "25 25 25";

   // border color
   border = 0;
   borderColor   = "40 40 40 100";
   borderColorHL = "128 128 128";
   borderColorNA = "64 64 64";

   // font
   fontType = "Lucida Grande";
   fontSize = 16;

   fontColor = "255 255 255";
   fontColorHL = "32 100 100";
   fontColorNA = "0 0 0";
   fontColorSEL = "200 200 200";

   // bitmap information
   bitmap = "./images/window";
   bitmapBase = "";
   textOffset = "0 0";

   // used by guiTextControl
   modal = true;
   justify = "left";
   autoSizeWidth = false;
   autoSizeHeight = false;
   returnTab = false;
   numbersOnly = false;
   cursorColor = "0 0 0 255";

   // sounds
   soundDown = "";
   soundOver = "";
};


if(!isObject(GuiSolidDefaultProfile)) new GuiControlProfile (GuiSolidDefaultProfile)
{
   opaque = true;
   border = true;
};

if(!isObject(GuiTransparentProfile)) new GuiControlProfile (GuiTransparentProfile)
{
   opaque = false;
   border = false;
};


if(!isObject(GuiToolTipProfile)) new GuiControlProfile (GuiToolTipProfile)
{
   // fill color
   fillColor = "0 0 0";

   // border color
   borderColor   = "138 134 122";

   // font
   fontType = "Lucida Grande";
   fontSize = 16;
   fontColor = "120 120 0";

};

if(!isObject(GuiModelessDialogProfile)) new GuiControlProfile("GuiModelessDialogProfile")
{
   modal = false;
};

if(!isObject(GuiFrameSetProfile)) new GuiControlProfile (GuiFrameSetProfile)
{
   fillColor = "239 237 222";
   borderColor   = "138 134 122";
   opaque = true;
   border = true;
};


if(!isObject(GuiWindowProfile)) new GuiControlProfile (GuiWindowProfile)
{
   opaque = true;
   border = 1;
   fillColor = "255 255 255";
   fillColorHL = "190 255 255";
   fillColorNA = "255 255 255";
   fontColor = "0 0 100";
   fontColorHL = "0 255 255";
   text = "untitled";
   bitmap = "./images/window";
   textOffset = "5 5";
   hasBitmapArray = true;
   justify = "center";
};

if(!isObject(GuiContentProfile)) new GuiControlProfile (GuiContentProfile)
{
   opaque = true;
   fillColor = "0 0 0";
};

if(!isObject(GuiBlackContentProfile)) new GuiControlProfile (GuiBlackContentProfile)
{
   opaque = true;
   fillColor = "0 0 0";
};

if(!isObject(GuiInputCtrlProfile)) new GuiControlProfile( GuiInputCtrlProfile )
{
   tab = true;
   canKeyFocus = true;
};

if(!isObject(GuiTextProfile)) new GuiControlProfile (GuiTextProfile)
{
   fontColor = "0 0 0";
};

if(!isObject(GuiMediumTextProfile)) new GuiControlProfile (GuiMediumTextProfile : GuiTextProfile)
{
   fontSize = 24;
};

if(!isObject(GuiBigTextProfile)) new GuiControlProfile (GuiBigTextProfile : GuiTextProfile)
{
   fontSize = 36;
};

if(!isObject(GuiLargeBlackProfile)) new GuiControlProfile (GuiLargeBlackProfile)
{
   tab = false;
   canKeyFocus = false;
   hasBitmapArray = false;
   mouseOverSelected = false;

   // fill color
   opaque = false;
   fillColor = "0 0 0";
   fillColorHL = "25 25 25";
   fillColorNA = "25 25 25";

   // border color
   border = 0;
   borderColor   = "40 40 40 100";
   borderColorHL = "128 128 128";
   borderColorNA = "64 64 64";

   // font
   fontType = "Arial Rounded MT Bold";
   fontSize = 40;

   fontColor = "0 0 0";
   fontColorHL = "32 100 100";
   fontColorNA = "0 0 0";
   fontColorSEL = "200 200 200";

   // bitmap information
   bitmap = "./images/window";
   bitmapBase = "";
   textOffset = "0 0";

   // used by guiTextControl
   modal = true;
   justify = "left";
   autoSizeWidth = false;
   autoSizeHeight = false;
   returnTab = false;
   numbersOnly = false;
   cursorColor = "0 0 0 255";

   // sounds
   soundDown = "";
   soundOver = "";
};

if(!isObject(GuiMLTextProfile)) new GuiControlProfile ("GuiMLTextProfile")
{
   fontColorLink = "255 96 96";
   fontColorLinkHL = "0 0 255";
   autoSizeWidth = true;
   autoSizeHeight = true;  
   border = false;
};

if(!isObject(GuiMLText2Profile)) new GuiControlProfile ("GuiMLText2Profile")
{
   fontSize = 16;
   fontColor = "0 0 0";
   fontColorLink = "255 96 96";
   fontColorLinkHL = "0 0 255";
   autoSizeWidth = true;
   autoSizeHeight = true;  
   border = false;
};

if(!isObject(GuiMLText3Profile)) new GuiControlProfile ("GuiMLText3Profile")
{
   fontSize = 72;
   fontColor = "255 255 255";
   fontColorLink = "255 96 96";
   fontColorLinkHL = "0 0 255";
   fontType = "Arial Rounded MT Bold";
   autoSizeWidth = true;
   autoSizeHeight = true;  
   border = false;
};

if(!isObject(GuiMLText4Profile)) new GuiControlProfile ("GuiMLText4Profile")
{
   fontSize = 36;
   fontColor = "0 0 0";
   fontColorLink = "255 96 96";
   fontColorLinkHL = "0 0 255";
   fontType = "Arial Rounded MT Bold";
   autoSizeWidth = true;
   autoSizeHeight = true;  
   border = false;
};

if(!isObject(GuiMLText5Profile)) new GuiControlProfile ("GuiMLText5Profile")
{
   fontSize = 36;
   fontColor = "250 250 250";
   fontColorLink = "255 96 96";
   fontColorLinkHL = "0 0 255";
   fontType = "Arial Rounded MT Bold";
   autoSizeWidth = true;
   autoSizeHeight = true;  
   border = false;
};


if(!isObject(GuiTextArrayProfile)) new GuiControlProfile (GuiTextArrayProfile : GuiTextProfile)
{
   fontColorHL = "32 100 100";
   fillColorHL = "200 200 200";
};

if(!isObject(GuiTextListProfile)) new GuiControlProfile (GuiTextListProfile : GuiTextProfile)
{
   opaque = true;
   fontColor = "0 0 0";
   fontColorHL = "0 255 255";
   fontColorNA = "255 0 0";
   tab = true;
   canKeyFocus = true;
};

if(!isObject(GuiTextEditProfile)) new GuiControlProfile (GuiTextEditProfile)
{
   opaque = true;
   fillColor = "0 0 0";
   fillColorHL = "128 128 128";
   border = -2;
   bitmap = "./images/textEdit";
   borderColor = "40 40 40 100";
   fontColor = "0 0 100";
   fontColorHL = "0 255 255";
   fontColorNA = "255 0 0";
   textOffset = "4 2";
   autoSizeWidth = false;
   autoSizeHeight = true;
   tab = true;
   canKeyFocus = true;
   
};

if(!isObject(GuiNewTextEditProfile)) new GuiControlProfile (GuiNewTextEditProfile)
{
   opaque = true;
   fillColor = "0 0 0";
   fillColorHL = "128 128 128";
   border = -2;
   bitmap = "./images/textEdit";
   borderColor = "40 40 40 100";
   fontType = "Arial Rounded MT Bold";
   fontColor = "0 0 100";
   fontColorHL = "0 255 255";
   fontColorNA = "255 0 0";
   fontSize = "60";
   textOffset = "4 2";
   autoSizeWidth = false;
   autoSizeHeight = false;
   tab = true;
   canKeyFocus = true;
   
};

if(!isObject(GuiProgressAIProfile)) new GuiControlProfile ("GuiProgressAIProfile")
{
   opaque = false;
   fillColor = "255 0 0 180";
   border = false;
   borderColor   = "78 88 120";
};


if(!isObject(GuiProgressDoneProfile)) new GuiControlProfile ("GuiProgressDoneProfile")
{
   opaque = false;
   fillColor = "0 225 0 180";
   border = false;
   borderColor   = "78 88 120";
};

if(!isObject(GuiProgressProfile)) new GuiControlProfile ("GuiProgressProfile")
{
   opaque = false;
   fillColor = "66 222 225 180";
   border = false;
   borderColor   = "78 88 120";
};

if(!isObject(GuiProgressTextProfile)) new GuiControlProfile ("GuiProgressTextProfile")
{
   fontColor = "0 0 0";
   justify = "center";
};

if(!isObject(GuiButtonProfile)) new GuiControlProfile (GuiButtonProfile)
{
   opaque = true;
   border = -1;
   bordercolor = "50 50 50";
   fontSize = 16;
   fontColor = "0 0 0";
   fontColorHL = "0 255 255";
   fixedExtent = true;
   justify = "center";
   canKeyFocus = false;
   bitmap = "./images/button";
};

if(!isObject(GuiCheckBoxProfile)) new GuiControlProfile (GuiCheckBoxProfile)
{
   opaque = false;
   fillColor = "232 232 232";
   border = false;
   borderColor = "0 0 0";
   fontSize = 16;
   fontColor = "0 0 100";
   fontColorHL = "0 255 255";
   fixedExtent = true;
   justify = "left";
   bitmap = "./images/checkBox";
   hasBitmapArray = true;
};

if(!isObject(GuiRadioProfile)) new GuiControlProfile (GuiRadioProfile)
{
   fontSize = 16;
   fontColor = "0 0 100";
   fontColorHL = "0 255 255";
   fontColorNA = "255 0 0";
   fixedExtent = true;
   bitmap = "./images/radioButton";
   hasBitmapArray = true;
};

if(!isObject(GuiScrollProfile)) new GuiControlProfile (GuiScrollProfile)
{
   opaque = true;
   fontColor = "0 0 100";
   fontColorHL = "0 255 255";
   fontColorNA = "255 0 0";
   fillColor = "255 255 255";
   border = 1;
   borderThickness = 2;
   bitmap = "./images/scrollBar";
   hasBitmapArray = true;
};

if(!isObject(GuiBlackScrollProfile)) new GuiControlProfile (GuiBlackScrollProfile)
{
   opaque = true;
   fillColor = "0 0 0";
   border = 1;
   borderThickness = 2;
   bitmap = "./images/scrollBar";
   hasBitmapArray = true;
};

if(!isObject(GuiTransparentScrollProfile)) new GuiControlProfile (GuiTransparentScrollProfile)
{
   opaque = false;
   fillColor = "0 0 0";
   border = false;
   borderThickness = 2;
   borderColor = "0 0 0";
   bitmap = "./images/scrollBar";
   hasBitmapArray = true;
};
 
if(!isObject(GuiSliderProfile)) new GuiControlProfile (GuiSliderProfile)
{
   bitmap = "~/images/slider";
};

if(!isObject(GuiPaneProfile)) new GuiControlProfile(GuiPaneProfile)
{
   bitmap = "./images/popupMenu";
   hasBitmapArray = true;
};



if(!isObject(GuiPopupMenuItemBorder)) new GuiControlProfile ( GuiPopupMenuItemBorder : GuiButtonProfile )
{
   borderColor = "51 51 53 200";
   borderColorHL = "51 51 53 200";

};
if(!isObject(GuiPopUpMenu)) new GuiControlProfile (GuiPopUpMenuDefault : GuiDefaultProfile )
{
   opaque = true;
   mouseOverSelected = true;
   textOffset = "3 3";
   border = 4;
   borderThickness = 2;
   fixedExtent = true;
   bitmap = "./images/scrollBar";
   hasBitmapArray = true;
   profileForChildren = GuiPopupMenuItemBorder;
   fillColor = "255 255 255 200";
   fontColorHL = "0 255 255";
   borderColor = "151 151 153 175";
   borderColorHL = "151 151 153 175";

};


if(!isObject(GuiPopUpMenuProfile)) new GuiControlProfile (GuiPopUpMenuProfile : GuiPopUpMenuDefault)
{
   textOffset         = "6 3";
   bitmap             = "./images/dropDown";
   hasBitmapArray     = true;
   border             = -3;
   profileForChildren = GuiPopUpMenuDefault;
};

if(!isObject(GuiPopUpMenuEditProfile)) new GuiControlProfile (GuiPopUpMenuEditProfile : GuiPopUpMenuDefault)
{
   textOffset         = "6 3";
   canKeyFocus        = true;
   bitmap             = "./images/dropDown";
   hasBitmapArray     = true;
   border             = -3;
   profileForChildren = GuiPopUpMenuDefault;
};

if(!isObject(GuiListBoxProfile)) new GuiControlProfile (GuiListBoxProfile)
{
   tab = true;
   canKeyFocus = true;
   opaque = false;
   fillColor = "0 0 0";
   fontColor = "0 0 100";
   fontColorHL = "0 255 255";
   fontColorNA = "255 0 0";
   fontColorSEL= "255 255 255";
};

if(!isObject(GuiTabBookProfile)) new GuiControlProfile (GuiTabBookProfile)
{
   fillColor = "0 0 0";
   fillColorHL = "64 150 150";
   fillColorNA = "150 150 150";
   fontColor = "0 0 100";
   fontColorHL = "0 255 255";
   fontColorNA = "255 0 0";
   fontType = "Bank Gothic Medium";
   fontSize = 16;
   justify = "center";
   bitmap = "./images/tab";
   tabWidth = 64;
   tabHeight = 24;
   tabPosition = "Top";
   tabRotation = "Horizontal";
   textOffset = "0 -2";
   tab = true;
   cankeyfocus = true;
};

if(!isObject(GuiTabBook2Profile)) new GuiControlProfile (GuiTabBook2Profile)
{
   fillColor = "0 0 0";
   fillColorHL = "64 150 150";
   fillColorNA = "150 150 150";
   fontColor = "0 0 100";
   fontColorHL = "0 255 255";
   fontColorNA = "255 0 0";
   fontType = "Bank Gothic Medium";
   fontSize = 16;
   justify = "center";
   bitmap = "~/images/tab";
   tabWidth = 64;
   tabHeight = 24;
   tabPosition = "Top";
   tabRotation = "Horizontal";
   textOffset = "0 -2";
   tab = true;
   cankeyfocus = true;
};

if(!isObject(GuiTabPageProfile)) new GuiControlProfile (GuiTabPageProfile : GuiTransparentProfile )
{
   fillColor = "0 0 0";
   opaque = true;
};

if(!isObject(GuiMenuBarProfile)) new GuiControlProfile (GuiMenuBarProfile)
{
   fontType = "Lucida Grande";
   fontSize = 15;
   opaque = true;
   fillColor = "0 0 0";
   fillColorHL = "102 153 204";
   borderColor = "138 134 122";
   borderColorHL = "0 51 153";
   border = 5;
   fontColor = "0 0 100";
   fontColorHL = "0 255 255";
   fontColorNA = "255 0 0";
   fixedExtent = true;
   justify = "center";
   canKeyFocus = false;
   mouseOverSelected = true;
   bitmap = "./images/menu";
   hasBitmapArray = true;
};

if(!isObject(GuiConsoleProfile)) new GuiControlProfile (GuiConsoleProfile)
{
   fontType = ($platform $= "macos") ? "Monaco" : "Lucida Console";
   fontSize = ($platform $= "macos") ? 13 : 12;
   fontColor = "0 255 0";
   fontColorHL = "0 255 255";
   fontColorNA = "255 126 0";
   fontColors[6] = "50 50 50";
   fontColors[7] = "126 126 0";  
   fontColors[8] = "0 0 50"; 
   fontColors[9] = "0 50 0";   
};

if(!isObject(GuiConsoleTextEditProfile)) new GuiControlProfile (GuiConsoleTextEditProfile : GuiTextEditProfile)
{
   fontType = ($platform $= "macos") ? "Monaco" : "Lucida Console";
   fontSize = ($platform $= "macos") ? 13 : 12;
   fontColor = "0 0 100";
};

if (!isObject(GuiTreeViewProfile)) new GuiControlProfile (GuiTreeViewProfile)
{
   fillColorHL = "0 60 150";
   fontSize = 16;
   fontColor = "0 0 100";
   fontColorHL = "0 255 255";
   fontColorNA = "255 0 0";
   fontColorSEL= "255 255 255";
   bitmap = "./images/treeView";
   canKeyFocus = true;
   autoSizeHeight = true;
};

//*** DAW:
if(!isObject(GuiText24Profile)) new GuiControlProfile (GuiText24Profile : GuiTextProfile)
{
   fontSize = 24;
};

if(!isObject(GuiRSSFeedMLTextProfile)) new GuiControlProfile ("GuiRSSFeedMLTextProfile")
{
   fontColorLink = "55 55 255";
   fontColorLinkHL = "255 55 55";
};