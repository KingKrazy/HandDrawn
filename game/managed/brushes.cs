$brushSet = new SimSet() {
   canSaveDynamicFields = "1";
   internalName = "Brushes";
      setType = "Brushes";

   new ScriptObject(_) {
      canSaveDynamicFields = "1";
      class = "TileBrush";
         customData = "None";
         displayName = "_";
         frame = "0";
         image = "grass_br_IImageMap";
         script = "None";
   };
   new ScriptObject(Ground_M) {
      canSaveDynamicFields = "1";
      class = "TileBrush";
         collision = "-1";
         customData = "None";
         displayName = "Ground_M";
         FlipX = "-1";
         FlipY = "-1";
         frame = "0";
         image = "Ground_MImageMap";
         script = "None";
   };
   new ScriptObject(Corner_Black) {
      canSaveDynamicFields = "1";
      class = "TileBrush";
         collision = "0";
         customData = "None";
         displayName = "Corner_Black";
         FlipX = "1";
         FlipY = "0";
         frame = "0";
         image = "Ground_CORNER2ImageMap";
         script = "None";
   };
   new ScriptObject(Corner_Green) {
      canSaveDynamicFields = "1";
      class = "TileBrush";
         collision = "0";
         customData = "None";
         displayName = "Corner_Green";
         FlipX = "1";
         FlipY = "0";
         frame = "0";
         image = "Ground_CORNER3ImageMap";
         script = "None";
   };
   new ScriptObject(Corner_Cro) {
      canSaveDynamicFields = "1";
      class = "TileBrush";
         collision = "0";
         customData = "None";
         displayName = "Corner_Cro";
         FlipX = "1";
         FlipY = "0";
         frame = "0";
         image = "Ground_CORNERImageMap";
         script = "None";
   };
};
