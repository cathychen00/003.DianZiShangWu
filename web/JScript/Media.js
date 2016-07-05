<!--
function Flash(file, w, h)
{
	document.write("\r\n\
<object classid='clsid:D27CDB6E-AE6D-11cf-96B8-444553540000' codebase='http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0' width='" + w + "' height='" + h + "'>\r\n\
	<param name='movie' value='" + file + "' />\r\n\
	<param name='wmode' value='opaque' />\r\n\
	<param name='menu' value='false' />\r\n\
	<param name='quality' value='autohigh' />\r\n\
	<embed type='application/x-shockwave-flash' pluginspage='http://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash' loop='false' menu='false' quality='autohigh' wmode='opaque' src='" + file + "' width='" + w + "' height='" + h + "'></embed>\r\n\
</object>");
}
function Wmv(file, w, h)
{
	document.write("\r\n\
<object align='middle' classid='CLSID:6BF52A52-394A-11d3-B153-00C04F79FAA6' class='OBJECT' id='MediaPlayer' width='" + w + "' height='" + h + "'>\r\n\
	<param name='autoStart' value='true' />\r\n\
	<param name='ShowStatusBar' value='true' />\r\n\
	<param name='url' value='" + file + "' />\r\n\
	<PARAM name='uiMode' value='full' />\r\n\
	<PARAM name='stretchToFit' value='true' />\r\n\
	<embed type='application/x-oleobject' codebase='http://activex.microsoft.com/activex/controls/mplayer/en/nsmp2inf.cab#Version=5,1,52,701' flename='mp' src='" + file + "' width='" + w +"' height='" + h + "'></embed>\r\n\
</object>");
}
function Wma(file)
{
	document.write("\r\n\
<object align='middle' classid='CLSID:6BF52A52-394A-11d3-B153-00C04F79FAA6' class='OBJECT' id='MediaPlayer' width='320' height='45'>\r\n\
	<param name='ShowStatusBar' value='true' />\r\n\
	<param name='autoStart' value='true' />\r\n\
	<param name='url' value='" + file + "' />\r\n\
	<embed type='application/x-oleobject' codebase='http://activex.microsoft.com/activex/controls/mplayer/en/nsmp2inf.cab#Version=5,1,52,701' flename='mp' src='" + file + "' width='320' height='45'></embed>\r\n\
</object>");
}
function Rm(file, w, h)
{
	document.write("\r\n\
<OBJECT classid='clsid:CFCDAA03-8BE4-11cf-B84B-0020AFBBCCFA' class='OBJECT' id='RAOCX' width='" + w + "' height='" + h + "'>\r\n\
	<PARAM NAME='SRC' VALUE='" + file + "' />\r\n\
	<PARAM NAME='AUTOSTART' VALUE='true' />\r\n\
	<PARAM NAME='CONSOLE' VALUE='Clip1' />\r\n\
	<PARAM NAME='CONTROLS' VALUE='imagewindow' />\r\n\
</OBJECT>\r\n\
<BR />\r\n\
<OBJECT classid='CLSID:CFCDAA03-8BE4-11CF-B84B-0020AFBBCCFA' height='32' id='video2' width='" + w + "'>\r\n\
	<PARAM NAME='SRC' VALUE='" + file + "' />\r\n\
	<PARAM NAME='AUTOSTART' VALUE='true' />\r\n\
	<PARAM NAME='CONTROLS' VALUE='controlpanel' />\r\n\
	<PARAM NAME='CONSOLE' VALUE='Clip1' />\r\n\
</OBJECT>\r\n\
");
}
function Ra(file)
{
	document.write("\r\n\
<OBJECT classid='CLSID:CFCDAA03-8BE4-11CF-B84B-0020AFBBCCFA' height='32' id='video2' width='320'>\r\n\
	<PARAM NAME='SRC' VALUE='" + file + "' />\r\n\
	<PARAM NAME='AUTOSTART' VALUE='true' />\r\n\
	<PARAM NAME='CONTROLS' VALUE='controlpanel' />\r\n\
	<PARAM NAME='CONSOLE' VALUE='Clip1' />\r\n\
</OBJECT>");
}
// -->