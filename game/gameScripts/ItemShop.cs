function itemShopGui::onWake(%this)
{
itemlist.addRow(PINE, "PineCone", 1);
itemlist.addRow(BPNE, "Burning PineCone", 2);
itemlist.addRow(FPNE, "Frozen PineCone", 3);
itemlist.addRow(PPNE, "Poisoned PineCone", 4);

itemlist.addRow(MPNE, "Multi-PineCone", 5);
itemlist.addRow(MBPN, "Multi-Burning PineCone", 6);
itemlist.addRow(MFPN, "Multi-Frozen PineCone", 7);
itemlist.addRow(MPPN, "Multi-Poisened PineCone", 8);

itemlist.addRow(CRRT, "Carrot", 9);
itemlist.addRow(APPL, "Apple", 10);
itemlist.addRow(SOUP, "Soup", 11);
}

function itemShopGui::setDescText(%this)
{
itemText.setText($ShopText[%this.theNumberOfAwesomeness]);
}

function itemShopGui::getItemShopId(%this)
{
%this.theNumberOfAwesomeness = itemList.getselectedID();

}

$ShopText[0] = "PINE";
$ShopText[1] = "asdsa";
$ShopText[2] = "sdgfdgds";
$ShopText[3] = "dsas";
$ShopText[4] = "sas";
$ShopText[5] = "fff";
$ShopText[6] = "gggsa";
$ShopText[7] = "";
$ShopText[8] = "";
$ShopText[9] = "";
$ShopText[10] = "";
$ShopText[11] = "";