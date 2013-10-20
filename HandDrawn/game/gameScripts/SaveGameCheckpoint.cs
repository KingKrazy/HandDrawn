function cp::getcurrent(%this)
{
   return $lastcheckpoint;
}

function cp::setcurrent(%this, %name)
{
   $lastcheckpoint = %name;
}